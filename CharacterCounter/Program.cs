using static System.Net.Mime.MediaTypeNames;

namespace CharacterCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String kalimat = "soal ini mudah dan ini tidak akan menghentikan langkah saya di sini";
            String removespace = kalimat.Replace(" ", "");

            // Huruf
            string[] hurufArr = removespace.ToCharArray().Select(c => c.ToString()).ToArray();

            // Kata
            string[] kataArr = kalimat.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Input: ");
            String textinputed = Console.ReadLine();

            if (textinputed.Length > 1)
            {
                var countstring = kataArr.Where(x => x.Contains(textinputed.ToLower()));

                Console.WriteLine("Jumlah: " + countstring.Count());

                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
            else
            {
                var countstring = hurufArr.Where(x => x.Equals(textinputed.ToLower()));
                Console.WriteLine("Jumlah: " + countstring.Count());

                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }


        }
    }
}