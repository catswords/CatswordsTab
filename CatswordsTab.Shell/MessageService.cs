﻿using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatswordsTab.Shell
{
    static class MessageService
    {
        private static Queue<string> TxQueue;
        private static Queue<string> RxQueue;
        private static bool status = false;

        static MessageService() {
            TxQueue = new Queue<string>();
            RxQueue = new Queue<string>();
        }

        public static void Push(string message)
        {
            TxQueue.Enqueue(message);
        }

        public static string Pull()
        {
            string message = null;
            while (RxQueue.Count > 0)
            {
                if (message == null)
                {
                    message = "";
                }
                message += RxQueue.Dequeue();
            }
            return message;
        }

        public static void Commit() {
            Push("Commit");

            using (RequestSocket client = new RequestSocket(">tcp://localhost:26112"))  // connect
            {
                string s = "Ping";
                if (client.TrySendFrame(TimeSpan.FromSeconds(1), s))
                {
                    if (client.TryReceiveFrameString(TimeSpan.FromSeconds(1), out s))
                    {
                        status = true;
                    }
                    else
                    {
                        RxQueue.Enqueue("Failed to receive the response.");
                    }
                } else
                {
                    RxQueue.Enqueue("Failed to send the request.");
                }

                if (status == true)
                {
                    try
                    {
                        while (TxQueue.Count > 0)
                        {
                            string message = TxQueue.Dequeue();
                            client.SendFrame(message);

                            string received = client.ReceiveFrameString();
                            RxQueue.Enqueue(received);
                        }
                    }
                    catch (Exception e)
                    {
                        Push("Exception");
                        Push(e.StackTrace);
                        Commit();
                    }
                }
                else
                {
                    RxQueue.Enqueue("No connection.");
                }
            }
        }

        public static bool GetStatus()
        {
            return status;
        }

        public static string GetLocale()
        {
            string locale = "en";
            string culture = CultureInfo.CurrentUICulture.Name;
            string[] terms = culture.Split('-');

            if (terms.Length > 0)
            {
                locale = terms[0];
            }

            return locale;
        }
    }
}
