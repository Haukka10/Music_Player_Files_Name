using Music_Player_Disk.Fileloader;
using Music_Player_Disk.DeleteFiles;
using Music_Player_Disk.GenerateFiles;
using Music_Player_Disk.SettingsLoader;

namespace Music_Player_Disk.MainApp
{
    public class MainFun
    {
        public static void Main()
        {
            string RootPath = Directory.GetCurrentDirectory();

            FileGenerate fileGenerate = new FileGenerate();
            DeleteFile deleteFiles = new DeleteFile();
            Loader loader = new Loader(RootPath);
            Settings settings = new Settings();

            RootPath += @"\FilesPlayer";

            settings.SetSettings();

            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
                Console.WriteLine("New Folder is make");

            }else
            Console.WriteLine("EXISTS");

            Thread.Sleep(1500);
            string[] Text = loader.LoaderFromFiles().ToArray();

            if(settings.maxFiles == 0 || settings.maxFiles > Text.Length)
            {
                settings.maxFiles = Text.Length;
            }

            fileGenerate.Generate(Text, RootPath, settings.maxFiles, settings.SleepTime);

            Console.WriteLine("You wanna delete all files ? Press any button");
            Console.ReadKey();

            deleteFiles.Delete(RootPath);
        }
    }

}