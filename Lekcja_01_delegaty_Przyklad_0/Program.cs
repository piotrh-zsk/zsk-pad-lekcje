namespace Lekcja_01_delegaty_Przyklad_0
{
    public delegate void MySampleDelegate(int number);

    internal class Program
    {
        public static MySampleDelegate mySampleDelegate;

        static void Main(string[] args)
        {
            mySampleDelegate += SampleMethod;

            mySampleDelegate?.Invoke(10);
        }

        public static void SampleMethod(int number)
        {
            Console.WriteLine("Podana liczba: " + number);
        }
    }
}