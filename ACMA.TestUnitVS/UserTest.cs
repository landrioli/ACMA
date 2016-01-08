using ACMA.Application.Services;
using ACMA.Domain.Entities.Access;
using ACMA.Domain.Entities.Common;
using ACMA.Models.User;
using ACMA.Repository.Repository;
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

        public RegisterUserModel registerUser = new RegisterUserModel() {
                                                                            UserName = "Joao.pedro",
                                                                            Password = "456789",
                                                                            Email = "sadasd@sda.com",
                                                                            Phone = "654545465",
                                                                            IdSelectListProfile = 1,
                                                                            FullName = "Joao pedro rocha"
                                                                        };

        [TestMethod]
        public void Login()
        {
            using (var accessService = new AccessService())
            {
                var canLogin = accessService.Login(registerUser.ConvertModelToDomain());
                Assert.IsTrue(canLogin);
            }
        }

        [TestMethod]
        public void GetUserByUserName()
        {
            string userName = "Juliana.Dagnostil";
            using (var accessRepository = new AccessRepository())
            {
                var user = accessRepository.GetUserBy(userName);
                Assert.AreEqual(userName, user.UserName);
            }
        }

        [TestMethod]
        public void GetUserByUserNameAndPassword()
        {
            string userName = "Roberto.Amaral";
            string password = "123456";

            using (var accessRepository = new AccessRepository())
            {
                var user = accessRepository.GetUserBy(userName,password);
                Assert.AreEqual(user.UserName, userName);
            }
        }

        [TestMethod]
        public void SaveNewUser()
        {
            //var user = new User()
            //{
            //    UserName = "joao",
            //    Password = "456456",
            //    Contact = new Contact() { FullName = "Joao Pedro Rosa", Email = "joaozinho@hotmail.com", Phone = "231213" },
            //    IdProfile = 1
            //};

            using (var accessService = new AccessService())
            {
                accessService.RegisterNewUser(registerUser.ConvertModelToDomain());
            }
            using (var accessRepository = new AccessRepository())
            {
                var userRetorned = accessRepository.GetUserBy(registerUser.UserName);
                Assert.AreEqual(registerUser.UserName, userRetorned.UserName);

                var saltRandomicoSenha = userRetorned != null ? userRetorned.Password.Split('$').FirstOrDefault() : null;
                var passwordCipher = EncryptionService.CriptografarSenha(registerUser.Password, saltRandomicoSenha);
                Assert.AreEqual(passwordCipher, userRetorned.Password);
            }
        }

        [TestMethod]
        public void UpdateUser()
        {

        }
    }
}
