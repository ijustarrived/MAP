using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.C_.Ball.Services
{
    class FileManager
    {
        public FileManager()
        {
            LocalPath = string.Empty;

            FileName = string.Empty;

            StoredValue = string.Empty;
        }

        public string LocalPath
        {
            get;

            set;
        }

        public string FileName
        {
            get;

            set;
        }

        public string StoredValue
        {
            get;

            set;
        }

        public static string GetLocalStoragePath(string fileName)
        {
            //persistentDataPath instead of dataPath for android.
            //return string.Format("{0}/{1}", Application.dataPath, fileName);

            return string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        }

        public static void Write(string value, string fileName)
        {
            string path = GetLocalStoragePath(fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(value);
                }
            }
        }

        public static string Read(string fileName)
        {
            string path = GetLocalStoragePath(fileName);

            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadLine();
                    }
                }
            }

            else
            {
                return string.Empty;
            }
        }
    }
}
