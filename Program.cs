using System;
using Chilkat;

namespace decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resume = true;

            Console.WriteLine("Decryptor Tool");

            while (resume) {
                Console.WriteLine("\nEnter the base64-encoded 256-bit encryption key that was used to encrypt the data (aka: The Wrapping Key):");

                string wrappingKey = Console.ReadLine();

                Console.WriteLine("\nEnter the securedData you want decrypted:");
                string jwe = Console.ReadLine();

                string decryptedValue = Decrypt(jwe, wrappingKey);

                Console.WriteLine("\n");

                Console.WriteLine(decryptedValue);

                Console.WriteLine("\nPress the Enter key to continue, or  type 'x' to exit\n");

                string response = Console.ReadLine();

                resume = response.ToLower() == "x" ? false : true;
            }
            
        }

        static string Decrypt(string securedData, string base64EncodedAESWrappingKey)
        {
            //  First, load the JWE..
            bool success;
            Jwe jwe = new Jwe();
            success = jwe.LoadJwe(securedData);
            if (success != true)
            {
                //Console.WriteLine(jwe2.LastErrorText);
                //return;
                return jwe.LastErrorText;
            }

            //  Set the AES wrap key for the recipient index.
            // This is the base64 encoded 256-bit encryption key
            jwe.SetWrappingKey(0, base64EncodedAESWrappingKey, "base64url");

            //  Decrypt
            string originalPlaintext = jwe.Decrypt(0, "utf-8");
            if (jwe.LastMethodSuccess != true)
            {
                //Console.WriteLine(jwe.LastErrorText);
                //return;
                return jwe.LastErrorText;
            }

            //Console.WriteLine("original text decrypted with AES key wrap key: ");
            //Console.WriteLine(originalPlaintext);
            return originalPlaintext;
        }
    }
}
