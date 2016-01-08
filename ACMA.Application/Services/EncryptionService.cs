using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.Application.Services
{
    public class EncryptionService : IDisposable
    {
        protected const string SaltSenha = "4gSjRYCJkvp8SGl406x2fYJcRjoKu1LLpwLQIRnD";

        //protected static RepositorioConfiguracao RepositorioConfiguracao = new RepositorioConfiguracao();

        //public string Vector { get; set; }

        //public string Key { get; set; }

        //private RijndaelManaged rijndaelManaged;

        public static string CriptografarMd5(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CriptografarSenha(string senha, string saltRandomico = null)
        {
            if (saltRandomico == null)
            {
                saltRandomico = GerarStringRandomica(7);
            }
            return saltRandomico + "$" + CriptografarMd5(saltRandomico + senha + SaltSenha);
        }

        //public static string CriptografarRinjndael(string conteudo)
        //{
        //    CipherService cipherService = new CipherService(RepositorioConfiguracao.ObterValorConfiguracaoPorChave(ChavesDeConfiguracao.CHAVE_CRIPTOGRAFIA_1),
        //        RepositorioConfiguracao.ObterValorConfiguracaoPorChave(ChavesDeConfiguracao.CHAVE_CRIPTOGRAFIA_2));
        //    string conteudoCriptografado = cipherService.Encipher(conteudo);
        //    return conteudoCriptografado;
        //}

        //public static string DecriptografarRinjndael(string conteudo)
        //{
        //    CipherService cipherService = new CipherService(RepositorioConfiguracao.ObterValorConfiguracaoPorChave(ChavesDeConfiguracao.CHAVE_CRIPTOGRAFIA_1),
        //        RepositorioConfiguracao.ObterValorConfiguracaoPorChave(ChavesDeConfiguracao.CHAVE_CRIPTOGRAFIA_2));
        //    string conteudoDecriptografado = cipherService.Decipher(conteudo);
        //    return conteudoDecriptografado;
        //}

        public static string GerarStringRandomica(int tamanho)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, tamanho).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
