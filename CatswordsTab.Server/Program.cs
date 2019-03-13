﻿using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using CatswordsTab.Server.Winform;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CatswordsTab.Server.Response;

namespace CatswordsTab.Server
{
    public class Program
    {
        private static Writer writerForm;
        private static List<string> flags = new List<string>();
        private static int flag = -1;

        private static string fileMd5;
        private static string fileSha1;
        private static string fileCrc32;
        private static string fileHead32;
        private static string fileSha256;
        private static string fileExtension;
        private static string userLanguage = "en";

        private static string GetResponseString(string message)
        {
            string response = "Hello";

            switch(message)
            {
                case "SetLanguage":
                    flags.Add("SetLanguage");
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd":
                    Task taskA = new Task(() => ShowWriterForm());
                    taskA.Start();
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised":
                    flags.Add("OnPropertyPageInitialised");
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply":
                    Exit();
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK":
                    Exit();
                    break;

                default:
                    // Get Response
                    flag = flags.IndexOf("OnPropertyPageInitialised");
                    if(flag > -1)
                    {
                        response = GetResponse(message);
                        ResetFlag(flag);
                    }

                    // Set Language
                    flag = flags.IndexOf("SetLanguage");
                    if(flag > -1)
                    {
                        userLanguage = message;
                        ResetFlag(flag);
                    }
                    break;
            }
            
            return response;
        }

        private static void ShowWriterForm()
        {
            writerForm = new Writer();
            writerForm.ShowDialog();
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ResetFlag(int flag)
        {
            flags.RemoveAt(flag);
            flag = -1;
        }

        private static string GetResponse(string message)
        {
            Analyze analyzer = new Analyze();
            fileMd5 = analyzer.GetMD5(message);
            fileSha1 = analyzer.GetSHA1(message);
            fileCrc32 = analyzer.GetCRC32(message);
            fileSha256 = analyzer.GetSHA256(message);
            fileHead32 = analyzer.GetHEAD32(message);
            fileExtension = analyzer.GetExtension(message);

            JObject obj = new JObject
            {
                { "hash_md5", fileMd5 },
                { "hash_sha1", fileSha1 },
                { "hash_crc32", fileCrc32 },
                { "hash_sha256", fileSha256 },
                { "hash_head32", fileHead32 },
                { "extension", fileExtension },
                { "language", userLanguage }
            };
            string response = Communicate.RequestPost("/portal/?route=tab", obj.ToString());

            return message;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Start...!");
            using (var server = new ResponseSocket("@tcp://localhost:26112")) // bind
            {
                while (true)
                {
                    string received = server.ReceiveFrameString();
                    Console.WriteLine("Received: {0}", received);

                    server.SendFrame(GetResponseString(received));
                    Thread.Sleep(1);
                }
            }
        }
    }
}
