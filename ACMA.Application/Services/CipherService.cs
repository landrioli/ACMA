using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.Application.Services
{
    public class CipherService
    {
        /// <summary>
        /// Vetor de inicialização.
        /// </summary>
        public string Vector { get; set; }

        /// <summary>
        /// Chave de criptografia.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Padrão de criptografia.
        /// </summary>
        private RijndaelManaged rijndaelManaged;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public CipherService()
        {
            rijndaelManaged = new RijndaelManaged();
            SetKeys();
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="vector">Vetor de inicialização.</param>
        /// <param name="key">Chave de criptografia.</param>
        public CipherService(string vector, string key)
        {
            rijndaelManaged = new RijndaelManaged();
            Vector = vector;
            Key = key;
            GetKeys();
        }

        /// <summary>
        /// Realiza a geração de chaves.
        /// </summary>
        public void GenerateKeys()
        {
            rijndaelManaged.GenerateIV();
            rijndaelManaged.GenerateKey();
            SetKeys();
        }

        /// <summary>
        /// Cifra um texto.
        /// </summary>
        /// <param name="text">Texto a ser cifrado.</param>
        /// <returns>Texto cifrado.</returns>
        public string Encipher(string text)
        {
            string cipherText = string.Empty;
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            GetKeys();
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                }
                cipherText = Convert.ToBase64String(msEncrypt.ToArray());
            }

            return cipherText;
        }

        /// <summary>
        /// Decifra um texto cifrado.
        /// </summary>
        /// <param name="cipherText">Texto cifrado.</param>
        /// <returns>Texto decifrado, retorna vazio quando a chave é inválida.</returns>
        public string Decipher(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            string text;
            GetKeys();
            try
            {
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            text = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                text = string.Empty;
            }

            return text;
        }

        /// <summary>
        /// Define as chaves da classe com base nas chaves criptograficas.
        /// </summary>
        private void SetKeys()
        {
            Vector = Convert.ToBase64String(rijndaelManaged.IV);
            Key = Convert.ToBase64String(rijndaelManaged.Key);
        }

        /// <summary>
        /// Define as chaves criptograficas com base nas chaves da classe.
        /// </summary>
        private void GetKeys()
        {
            rijndaelManaged.IV = Convert.FromBase64String(Vector);
            rijndaelManaged.Key = Convert.FromBase64String(Key);
        }
    }
}
