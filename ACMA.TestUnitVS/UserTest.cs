using ACMA.Application.Services;
using ACMA.Domain.Entities.Access;
using ACMA.Domain.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.TestUnitVS
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void SaveNewUser()
        {
            var user = new User()
            {
                UserName = "joao",
                Password = "456456",
                Contact = new Contact() { FullName = "Joao Pedro Rosa", Email = "joaozinho@hotmail.com", Phone = "231213" },
                IdProfile = 1
            };

            using (var accessService = new AccessService())
            {
                accessService.RegisterNewUser(user);
            }
        }

        [TestMethod]
        public void UpdateUser()
        {

        }
    }
}
