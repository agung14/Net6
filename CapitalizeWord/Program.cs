using System.Globalization;

namespace CapitalizeWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kalimat = "saya dapat menyelesaikan soal ini dengan baik";

            TextInfo textinfo = CultureInfo.CurrentCulture.TextInfo;

            Console.WriteLine(textinfo.ToTitleCase(kalimat));
            
            Console.WriteLine("Press enter to close...");
			Console.ReadLine();


        }
    }
}