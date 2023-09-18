namespace Lekcja_01_delegaty_Przyklad_2
{
    public delegate List<DataItem> FilterDelegate(List<DataItem> l);

    public static class Filtering
    {
        public static void StartProgram()
        {
            DataItem d1 = new() { A = "A", B = 4 };
            DataItem d2 = new() { A = "B", B = 2 };
            DataItem d3 = new() { A = "C", B = 1 };
            DataItem d4 = new() { A = "D", B = 3 };
            List<DataItem> dataItems = new() { d4, d2, d1, d3 };

            DisplayData("Order alphabetical:", dataItems, Alphabetical);
            DisplayData("Order by number:", dataItems, Ascending);
            DisplayData("Order by number desc:", dataItems, Descending);
        }


        // ========= Metody
        public static void DisplayData(string title, List<DataItem> list, FilterDelegate filter)
        {
            Console.WriteLine(title);

            var items = filter(list);
            foreach (DataItem item in items)
                Console.WriteLine("{0}, {1}", item.A, item.B);

            Console.Write("\n");
        }

        static List<DataItem> Alphabetical(List<DataItem> p)
        {
            return p.OrderBy(x => x.A).ToList();
        }

        static List<DataItem> Ascending(List<DataItem> p)
        {
            return p.OrderBy(x => x.B).ToList();
        }

        static List<DataItem> Descending(List<DataItem> p)
        {
            return p.OrderByDescending(x => x.B).ToList();
        }
    }
}
