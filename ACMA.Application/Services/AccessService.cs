using ACMA.Domain.Entities.Access;
using ACMA.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Application.Services
{
    public class AccessService : IDisposable
    {

        public void RegisterNewUser(User user)
        {
            user.Active = true;
            user.Blocked = false;
            user.DateRegistration = DateTime.Now;

            user.Password = EncryptionService.CriptografarSenha(user.Password);

            using (var accessRepository = new AccessRepository())
            {
                accessRepository.SaveUser(user);
            }
        }

        public bool Login(User user)
        {
            using (var accessRepository = new AccessRepository())
            {
                //Retorna password do usuário para buscar o salt da conta
                var password = accessRepository.GetUserPasswordBy(user.UserName);
                var saltRandonPassword = password != null ? password.Split('$').FirstOrDefault() : null;

                user.Password = EncryptionService.CriptografarSenha(user.Password, saltRandonPassword);
                return accessRepository.GetUserBy(user.UserName, user.Password) == null ? false : true;
            }
        }

        public void RecoveryPassword(string email)
        {
            //Criar nova senha
            string password = EncryptionService.GerarStringRandomica(12);
            //Cadastrar nova senha
            UpdatePassword(email, password);
            //Enviar email com nvoa senha

        }

        public void UpdatePassword(string email, string password) {           
            using (var accessRepository = new AccessRepository()){
                accessRepository.UpdatePassword(email, password);
            }
        }

        public void UpdateUser(User user) {
            user.Password = EncryptionService.CriptografarSenha(user.Password);

            using (var accessRepository = new AccessRepository())
            {
                accessRepository.SaveUser(user);
            }
        }

        public List<User> GetAllUsers() {
            using (var accessRepository = new AccessRepository())
            {
                return accessRepository.GetAllUsers();
            }
        }

        public void Dispose()
        {
        }
    }
}
