using System;
using decryptor.model;

namespace decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\n\n*************   Decryptor Tool   **************\n\n");

            while (true)
            {
                SecuredData.Clear();

                Console.WriteLine("\nEnter the securedData you want decrypted:");
                SecuredData.CipherText = Console.ReadLine().ToString();

                Console.WriteLine("\nEnter the base64-encoded 256-bit encryption key that was used to encrypt the data (aka: The Wrapping Key):");
                SecuredData.Base64EncodedAESWrappingKey = Console.ReadLine().ToString();

                Console.WriteLine($"\n{SecuredData.Decrypt()}");

                Console.WriteLine("\nPress any key to continue, or [Ctrl + c] to exit.\n");
                Console.ReadKey();
            }

        }

    }
}
