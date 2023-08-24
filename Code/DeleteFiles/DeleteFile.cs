using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player_Disk.DeleteFiles
{
    internal class DeleteFile
    {
        public void Delete(string GetCurrentDirectory)
        {
            string[] AllFiles = Directory.GetFiles(GetCurrentDirectory);

            //Delete all files
            foreach (string file in AllFiles)
            {
                Console.WriteLine("Delete Files of name {0}",file);
                Thread.Sleep(25);
                File.Delete(file);
            }
        }
    }
}
