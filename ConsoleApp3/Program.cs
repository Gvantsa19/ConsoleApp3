using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string currFolderName = Directory.GetCurrentDirectory();
            string destFolderName = Path.Combine(currFolderName, "SecondFolder");

            Directory.CreateDirectory(destFolderName);

            string fileName = Path.GetRandomFileName();

            destFolderName = Path.Combine(destFolderName, fileName);

            Console.WriteLine("Path to my file: {0}\n", destFolderName);

            if (!File.Exists(destFolderName))
            {
                using (FileStream fs = File.Create(destFolderName)) 
                {
                    for (byte i = 0; i < 20; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            try
            {
                byte[] readBuffer = File.ReadAllBytes(destFolderName);
                foreach (byte b in readBuffer)
                {
                    Console.WriteLine(b + " ");
                }
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }


            ///////////////////////////////////////////////////////////////////////

              string currPath = @"C:\Users\DiMKa\Desktop\gvantsa\ConsoleApp3\ConsoleApp3\bin\Debug\net5.0\SecondFolder";
              string destinationFolder = @"C:\Users\DiMKa\Desktop\gvantsa\New folder (2)";

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string[] sourcefiles = Directory.GetFiles(currPath);

            foreach (string sourcefile in sourcefiles)
            {
                string filesName = Path.GetFileName(sourcefile);
                string destFile = Path.Combine(destinationFolder, filesName);

                File.Copy(sourcefile, destFile);
            }

        }
    }
}
