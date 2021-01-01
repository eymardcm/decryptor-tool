using System;
using decryptor.model;

namespace decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n*************   Decryptor Tool   **************\n\n");

            bool resume = true;
            while (resume)
            {
                SecuredData securedData;

                Console.WriteLine("\nEnter the securedData you want decrypted:");
                securedData.CipherText = Console.ReadLine().ToString();

                Console.WriteLine("\nEnter the base64-encoded 256-bit encryption key that was used to encrypt the data (aka: The Wrapping Key):");
                securedData.Base64EncodedAESWrappingKey = Console.ReadLine().ToString();

                Console.WriteLine($"\n{securedData.Decrypt()}");

                Console.WriteLine("\nPress the Enter key to continue, or  [Ctrl + c] to exit.\n");

                string response = Console.ReadLine();

                resume = response.ToLower() == "x" ? false : true;
            }

        }

    }
}
