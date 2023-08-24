using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player_Disk.SettingsLoader
{
    internal class Settings
    {
        List<string> files = new List<string>();
        public int SleepTime = 97;
        public int maxFiles;
        public string? MF;
        public string? sleep;

        public void SetSettings()
        {
            Console.WriteLine("Set Setting (Max Files to generate and pause for each files)");
            MF = Console.ReadLine();
            sleep = Console.ReadLine();
            if (MF == null || sleep == null) { return; }

            files.Add(MF);
            files.Add(sleep);

            try
            {
                Converst(files); 
            }
            catch (Exception)
            {
                Console.WriteLine("Pls type number!");
                MF = Console.ReadLine();
                sleep = Console.ReadLine();

                if (MF == null || sleep == null) { return; }
                files.Add(MF);
                files.Add(sleep);
                Converst(files);
            }
        }
        private void Converst(List<string> value)
        {
            maxFiles = int.Parse(value[0]);
            SleepTime = int.Parse(value[1]);
        }
    }
}
