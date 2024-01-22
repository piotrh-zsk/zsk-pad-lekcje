namespace Lekcja_01_delegaty_Przyklad_4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("START\n");

            await DataPresenter.StartProgramAsync();

            Console.WriteLine("\nKONIEC\n");
            Console.ReadLine();
        }
    }
}