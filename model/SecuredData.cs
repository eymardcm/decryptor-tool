using Chilkat;

namespace Decryptor.Model
{
    public struct SecuredData
    {
        public static string CipherText;
        public static string Base64EncodedAESWrappingKey;       
        public static string Decrypt()
        {
            
            Jwe jwe = new Jwe();
            
            //  1. Load the JWE..
            bool success = jwe.LoadJwe(CipherText);

            if (success != true) return jwe.LastErrorText;

            //  2. Set the AES wrap key for the recipient index.
            //     This is the base64 encoded 256-bit encryption key
            jwe.SetWrappingKey(0, Base64EncodedAESWrappingKey, "base64url");

            //  3. Decrypt
            return jwe.LastMethodSuccess != true ? jwe.LastErrorText : jwe.Decrypt(0, "utf-8");

        }
        public static void Clear()
        {
            CipherText = string.Empty;
            Base64EncodedAESWrappingKey = string.Empty;
        }
    }
}
