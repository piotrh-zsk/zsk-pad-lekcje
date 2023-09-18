namespace Lekcja_01_delegaty_Przyklad_4
{
    public static class DataPresenter
    {
        public static async Task StartProgramAsync()
        {
            Console.WriteLine("Zlecenie utworzenia danych...");

            DataProvider.printMethod += PrintMethod;
            //DataProvider.printMethod += PrintMethod;
            DataProvider.GenerateDataAsync();

            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
        }


        // ========= Metody
        public static void PrintMethod(List<DataItem> dataList)
        {
            Console.WriteLine("Drukowanie danych...");

            foreach (DataItem p in dataList)
                Console.WriteLine("A: {0}, B: {1}", p.A, p.B);

            Console.WriteLine("Drukowanie zakończone!");
        }
    }
}
