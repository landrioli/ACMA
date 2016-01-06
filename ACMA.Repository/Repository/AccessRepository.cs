using ACMA.Domain.Entities.Access;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ACMA.Repository.Repository
{
    public class AccessRepository : RootBaseRepository
    {
        public AccessProfile GetAccessProfileBy(int idUser)
        {
            return this.Context.User.Select(p => p.AccessProfile).First(p => p.Id == idUser);
        }

        public User GetUserBy(string userName)
        {
            return this.Context.User.Where(p => p.UserName == userName).SingleOrDefault();
        }

        public void SaveNewUser(User user)
        {
            using (var context = new Context())
            {
                context.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
                context.SaveChanges();
            }
        }

        public User GetUserBy(string userName, string password)
        {
            using (var context = new Context())
            {
                return context.User.Where(p => p.UserName == userName &&
                                             p.Password == password)
                                    .SingleOrDefault();
            }
        }
    }
}
