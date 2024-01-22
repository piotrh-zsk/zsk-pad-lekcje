namespace Lekcja_01_delegaty_Przyklad_1
{
    public delegate void PrintDataDelegate(List<DataItem> dataList);

    public static class DataPresenter
    {
        // ========= PRZYKŁAD 1 - synchroniczny
        public static void StartProgramSync()
        {
            Console.WriteLine("Zlecenie utworzenia danych...");

            var dataItems = DataProvider.GenerateDataSync();
            PrintMethod(dataItems);

            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
        }


        // ========= PRZYKŁAD 2 - asynchroniczny, delegat w parametrze
        public static async Task StartProgramWithParameterAsync()
        {
            Console.WriteLine("Zlecenie utworzenia danych...");

            DataProvider.GenerateDataAsync(PrintMethod);

            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
        }


        // ========= PRZYKŁAD 3 - asynchroniczny, delegat zdefiniowany w klasie
        public static async Task StartProgramAsync()
        {
            Console.WriteLine("Zlecenie utworzenia danych...");

            DataProvider.printMethod += PrintMethod;
            DataProvider.printMethod += PrintMethod2;
            DataProvider.GenerateDataAsync();

            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
            Console.WriteLine("Inne ważne zadania, które dzieją się na interfejsie...");
        }


        // ========= PRZYKŁAD 4 - delegat zamieniony na event
        public static async Task StartProgramWithEventAsync()
        {
            Console.WriteLine("Zlecenie utworzenia danych...");

            DataProvider.OnDataPrepared += PrintMethod;
            DataProvider.GenerateDataWithEventAsync();

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
        public static void PrintMethod2(List<DataItem> dataList)
        {
            Console.WriteLine("Drukowanie danych...");

            foreach (DataItem p in dataList)
                Console.WriteLine("asdasasdf A: {0}, B: {1}", p.A, p.B);

            Console.WriteLine("Drukowanie zakończone!");
        }
    }
}
