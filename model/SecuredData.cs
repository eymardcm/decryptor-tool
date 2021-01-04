//<ItemGroup >
//    <PackageReference Include = "ChilkatDnCore" Version = "9.5.0.84" />
//</ItemGroup >
using Chilkat;

namespace Decryptor.Model
{
    public struct SecuredData
    {
      
        public static string CipherText;                    // this is the value of securedData
        public static string Base64EncodedAESWrappingKey;   // this is the b64Encoded 256-bit encryption key    
        public static string Decrypt()
        {
            bool success;

            Jwe jwe = new Jwe();

            //  1. Load the JWE..
            success = jwe.LoadJwe(CipherText);
            if (success != true) return jwe.LastErrorText;

            //  2. Set the AES wrap key for the recipient index.
            jwe.SetWrappingKey(0, Base64EncodedAESWrappingKey, "base64url");
            if (jwe.LastMethodSuccess != true) return jwe.LastErrorText;
            
            //  3. Decrypt       
            return jwe.Decrypt(0, "utf-8");

        }
        public static void Clear()
        {
            CipherText = string.Empty;
            Base64EncodedAESWrappingKey = string.Empty;
        }
    }
}
