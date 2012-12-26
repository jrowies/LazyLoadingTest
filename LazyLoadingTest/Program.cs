namespace LazyLoadingTest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Make sure that a TestNH db exists
            //NHHelper.InitNHData(); 
            NHHelper.ShowAllDataUsingNh();

            //EFHelper.InitEFData();
            EFHelper.ShowAllDataUsingEf();

            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
