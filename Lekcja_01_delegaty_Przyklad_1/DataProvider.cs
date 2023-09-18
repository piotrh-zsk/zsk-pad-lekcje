namespace Lekcja_01_delegaty_Przyklad_1
{
    public static class DataProvider
    {
        // ========= PRZYKŁAD 1 - synchroniczny
        public static List<DataItem> GenerateDataSync()
        {
            DataItem d1 = new() { A = "A", B = 1 };
            DataItem d2 = new() { A = "B", B = 2 };
            DataItem d3 = new() { A = "C", B = 3 };
            DataItem d4 = new() { A = "D", B = 4 };
            List<DataItem> dataItems = new() { d1, d2, d3, d4 };

            Thread.Sleep(5000);

            Console.WriteLine("Dane utworzone!");

            return dataItems;
        }


        // ========= PRZYKŁAD 2 - asynchroniczny, delegat w parametrze
        public static async Task GenerateDataAsync(PrintDataDelegate inputPrintMethod)
        {
            DataItem d1 = new() { A = "A", B = 1 };
            DataItem d2 = new() { A = "B", B = 2 };
            DataItem d3 = new() { A = "C", B = 3 };
            DataItem d4 = new() { A = "D", B = 4 };
            List<DataItem> dataItems = new() { d1, d2, d3, d4 };

            await Task.Delay(5000);

            Console.WriteLine("Dane utworzone!");

            inputPrintMethod?.Invoke(dataItems);
        }


        // ========= PRZYKŁAD 3 - asynchroniczny, delegat zdefiniowany w klasie
        public static PrintDataDelegate printMethod;

        public static async Task GenerateDataAsync()
        {
            DataItem d1 = new() { A = "A", B = 1 };
            DataItem d2 = new() { A = "B", B = 2 };
            DataItem d3 = new() { A = "C", B = 3 };
            DataItem d4 = new() { A = "D", B = 4 };
            List<DataItem> dataItems = new() { d1, d2, d3, d4 };

            await Task.Delay(5000);

            Console.WriteLine("Dane utworzone!");

            printMethod?.Invoke(dataItems);
        }


        // ========= PRZYKŁAD 4 - delegat zamieniony na event
        public static event PrintDataDelegate OnDataPrepared;

        public static async Task GenerateDataWithEventAsync()
        {
            DataItem d1 = new() { A = "A", B = 1 };
            DataItem d2 = new() { A = "B", B = 2 };
            DataItem d3 = new() { A = "C", B = 3 };
            DataItem d4 = new() { A = "D", B = 4 };
            List<DataItem> dataItems = new() { d1, d2, d3, d4 };

            await Task.Delay(5000);

            Console.WriteLine("Dane utworzone!");

            OnDataPrepared?.Invoke(dataItems);
        }
    }
}
