namespace Music_Player_Disk.GenerateFiles
{
    internal class FileGenerate
    {
        public void Generate(string[] Text, string Path,int maxFilesToGen,int SleppTime)
        {
            for (int i = 0; i < maxFilesToGen; i++)
            {
                Thread.Sleep(SleppTime);
                var PathFiles = Path + "\\" + Text[i];

                using (File.Create(PathFiles))
                {
                    Console.WriteLine("Files Makes {0}", Text[i]);
                }

                PathFiles.Clone();

            }
        }

    }
}
