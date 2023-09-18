namespace Lekcja_01_delegaty_Przyklad_3
{
    public class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; }

        public FileFoundArgs(string fileName) => FoundFile = fileName;
    }

    public class FileSearcher
    {
        public event EventHandler<FileFoundArgs>? FileFound;

        public void Search(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
                RaiseFileFound(file);
        }

        private void RaiseFileFound(string file) => FileFound?.Invoke(this, new FileFoundArgs(file));
    }

    public class Files
    {
        public Files()
        {
            var fileLister = new FileSearcher();
            int filesFound = 0;

            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.FoundFile);
                filesFound++;
            };

            fileLister.FileFound += onFileFound;

            fileLister.Search("C:\\", "*.dll");
        }
    }
}
