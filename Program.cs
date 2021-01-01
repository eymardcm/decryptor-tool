using Decryptor.Model;
using static System.Console;

namespace Decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            WriteLine("\n\n*************   Decryptor Tool   **************\n\n");

            while (true)
            {
                
                SecuredData.Clear();

                WriteLine("\nEnter the securedData you want decrypted:");
                SecuredData.CipherText = ReadLine().ToString();

                WriteLine("\nEnter the base64-encoded 256-bit encryption key that was used to encrypt the data (aka: The Wrapping Key):");
                SecuredData.Base64EncodedAESWrappingKey = ReadLine().ToString();

                WriteLine($"\n{SecuredData.Decrypt()}");

                WriteLine("\nPress any key to continue, or [Ctrl + c] to exit.\n");
                ReadKey();

            }

        }

    }

}
