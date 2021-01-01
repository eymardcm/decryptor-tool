using Chilkat;

namespace decryptor.model
{
    public struct SecuredData
    {
        public string CipherText;
        public string Base64EncodedAESWrappingKey;

        
        public string Decrypt()
        {
            //  First, load the JWE..
            bool success;
            Jwe jwe = new Jwe();
            success = jwe.LoadJwe(CipherText);
            if (success != true)
            {
                return jwe.LastErrorText;
            }

            //  Set the AES wrap key for the recipient index.
            // This is the base64 encoded 256-bit encryption key
            jwe.SetWrappingKey(0, Base64EncodedAESWrappingKey, "base64url");

            //  Decrypt
            string clearText = jwe.Decrypt(0, "utf-8");
            if (jwe.LastMethodSuccess != true)
            {
                return jwe.LastErrorText;
            }

            return clearText;
        }
    }
}
