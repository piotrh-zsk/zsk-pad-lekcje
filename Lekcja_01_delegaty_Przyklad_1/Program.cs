namespace Lekcja_01_delegaty_Przyklad_1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nSTART\n");

            // Przykład 1 - synchroniczny:
            DataPresenter.StartProgramSync();

            // Przykład 2 - asynchroniczny, delegat w parametrze:
            //await DataPresenter.StartProgramWithParameterAsync();
            
            // Przykład 3 - asynchroniczny, delegat zdefiniowany w klasie:
            //await DataPresenter.StartProgramAsync();
            
            // Przykład 4 - delegat zamieniony na event:
            //await DataPresenter.StartProgramWithEventAsync();
            
            Console.WriteLine("\nKONIEC\n");
            Console.ReadLine();
        }
    }
}