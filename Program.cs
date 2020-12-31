using System;
using Chilkat;

namespace decryptor
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Decryptor Tool");

            Console.WriteLine("\nEnter the base64-encoded 256-bit encryption key that was used to encrypt the data (aka: The Wrapping Key):");

            string wrappingKey = Console.ReadLine();

            Console.WriteLine("\nEnter the securedData you want decrypted:");
            string jwe = Console.ReadLine();

            string decryptedValue = Decrypt(jwe, wrappingKey);

            Console.WriteLine("\n");
            Console.WriteLine(decryptedValue);
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
