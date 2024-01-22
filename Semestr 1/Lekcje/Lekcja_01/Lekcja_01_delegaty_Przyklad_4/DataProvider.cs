namespace Lekcja_01_delegaty_Przyklad_4
{
    public static class DataProvider
    {
        // ========= PRZYKŁAD 2
        public static Action<List<DataItem>> printMethod;

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
    }
}
