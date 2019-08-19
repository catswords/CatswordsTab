﻿using BencodeNET.Parsing;
using BencodeNET.Torrents;
using Force.Crc32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.App
{
    class ComputeService
    {
        public static Dictionary<string, string> Compute(string filename)
        {
            string extension = GetExtension(filename);
            return new Dictionary<string, string>
            {
                { "extension", extension },
                { "md5",       GetMD5(filename) },
                { "sha1",      GetSHA1(filename) },
                { "head32",    GetHEAD32(filename) },
                { "crc32",     GetCRC32(filename) },
                { "sha256",    GetSHA256(filename) },
                { "infohash",  GetInfoHash(filename, extension) },
                { "locale",    GetSystemLocale() }
            };
        }

        private static string GetExtension(string filename)
        {
            return Path.GetExtension(filename).Substring(1).ToUpper();
        }

        private static string GetMD5(string filename)
        {
            string checksum = "";

            using (MD5 hasher = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        private static string GetSHA1(string filename)
        {
            string checksum = "";

            using (SHA1 hasher = SHA1.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        private static string GetCRC32(string filename)
        {
            string checksum = "";

            using (FileStream stream = File.OpenRead(filename))
            {
                checksum = string.Format("{0:x}", Crc32Algorithm.Compute(stream));
            }

            return checksum;
        }

        private static string GetSHA256(string filename)
        {
            string checksum = "";

            using (SHA256 hasher = SHA256.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public static byte[] GetFileBytes(string filename, int count=32)
        {
            byte[] buffer = new byte[count];

            using (var stream = File.OpenRead(filename)) {
                int offset = 0;
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count - offset);
                    if (read == 0)
                        throw new System.IO.EndOfStreamException();
                    offset += read;
                }

                System.Diagnostics.Debug.Assert(offset == count);
            }

            return buffer;
        }

        private static string GetHEAD32(string filename)
        {
            byte[] buffer = GetFileBytes(filename, 32);
            return Convert.ToBase64String(buffer);
        }

        private static string GetInfoHash(string filename, string extension)
        {
            string checksum = "";

            if(extension == "TORRENT")
            {
                BencodeParser parser = new BencodeParser();
                Torrent torrent = parser.Parse<Torrent>(filename);
                checksum = BitConverter.ToString(torrent.GetInfoHashBytes()).Replace("-", "").ToLowerInvariant();
            }

            return checksum;
        }

        private static string GetSystemLocale()
        {
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        public static string GetHexView(byte[] Data)
        {
            string output = "";

            StringBuilder strb = new StringBuilder();
            StringBuilder text = new StringBuilder();
            char[] ch = new char[1];
            for (int x = 0; x < Data.Length; x += 16)
            {
                text.Length = 0;
                strb.Length = 0;
                for (int y = 0; y < 16; ++y)
                {
                    if ((x + y) > (Data.Length - 1))
                        break;
                    ch[0] = (char)Data[x + y];
                    strb.AppendFormat("{0,0:X2} ", (int)ch[0]);
                    if (((int)ch[0] < 32) || ((int)ch[0] > 127))
                        ch[0] = '.';
                    text.Append(ch);
                }
                text.Append("\r\n");
                while (strb.Length < 52)
                    strb.Append(" ");
                strb.Append(text.ToString());
                output += strb.ToString();
            }

            return output;
        }
    }}