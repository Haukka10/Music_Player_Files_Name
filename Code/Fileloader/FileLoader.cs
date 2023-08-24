namespace Music_Player_Disk.Fileloader
{
    public class Loader
    {
        private string FilesPath;
        private string LoaderFiles;
        private List<string> AllWorld = new List<string>();
        private int FilesIndex = 0;
        public Loader(string Path) => FilesPath = Path ?? throw new ArgumentNullException(nameof(Path));

        public string Finder()
        {
            var Files = Directory.GetFiles(FilesPath);
            LoaderFiles = FilesPath + @"\MusicText.txt";

            foreach (var item in Files)
            {
                if (item.ToLower() == LoaderFiles.ToLower())
                    return item;
                else
                    continue;
            }
            return null;
        }

        public List<string> LoaderFromFiles()
        {
            if (Guard() != true)
            {
                Console.WriteLine("Folder not faind!!");
                return new List<string> { null };
            }

            string FilesToLoader = Finder();

            using (StreamReader sr = new StreamReader(FilesToLoader))
            {
                var buffor = File.ReadAllLines(FilesToLoader).ToList();

                List<string> bufforWorld = new List<string>();
                string[] Worlds = new string[buffor.Count];

                int IndexBuffor = 0;

                for (int i = 0; i < buffor.Count(); i++)
                {
                    //make list of 1 line 
                    char[] a = buffor[i].ToArray();

                    for (int j = 0; j < a.Length; j++)
                    {
                        bufforWorld.Add(a[j].ToString());
                        //check if name of has ? , \ , / , * , < , > , :
                        if(IsInvalit(bufforWorld) == true)
                        {
                            Console.WriteLine("Is invalite!");
                            bufforWorld.Remove(a[j].ToString().ToLower());
                            bufforWorld.Add(".");
                        }
                        //add to list and them set to name of file
                        if (bufforWorld[IndexBuffor] == " " || j >= a.Length - 1)
                        {
                            bufforWorld.Insert(0, FilesIndex.ToString());
                            Worlds.SetValue(ConnectString(bufforWorld.ToArray()), 0);
                            AllWorld.Add(Worlds[0]);

                            Worlds = new string[bufforWorld.Count + 2];
                            bufforWorld.Clear();
                            IndexBuffor = -1;
                            FilesIndex++;
                        }
                        IndexBuffor++;
                    }
                }
                return AllWorld;
            }
        }

        private bool Guard()
        {
            if (Finder() == null)
            {
                using (File.Create(LoaderFiles))
                {
                    Console.WriteLine("Files Makes");
                }
            }

            return true;
        }

        private bool IsInvalit(List<string> checklist)
        {
            foreach (var item in checklist)
            {
                if (item == "?" || item == "*" || item == "/" || item == ":" || item == "<" || item == ">" || item == "|" || item == "\\")
                {
                    return true;
                }
                else
                    continue;
            }
            return false;
        }

        private string ConnectString(string[] str)
        {
            var Fstr = String.Concat(str);
            return Fstr;
        }
    }
}
