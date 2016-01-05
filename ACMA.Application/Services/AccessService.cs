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

        public void Dispose()
        {
        }
    }
}
