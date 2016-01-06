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

            using (var accessRepository = new AccessRepository())
            {
                accessRepository.SaveNewUser(user);
            }
        }

        public bool Login(User user)
        {
            using (var accessRepository = new AccessRepository())
            {
                return accessRepository.GetUserBy(user.UserName, user.Password) == null ? false : true;
            }
        }

        public void RecoveryPassword(string email)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
