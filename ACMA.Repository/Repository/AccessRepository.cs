using ACMA.Domain.Entities.Access;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

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

        public void SaveUser(User user)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
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

        public void UpdatePassword(string email, string password)
        {
            using (var context = new Context())
            {
                var user = context.User.Where(p=>p.Contact.Email == email).Single();
                user.Password = password;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public string GetUserPasswordBy(string userName)
        {
            using (var context = new Context())
            {
                return context.User.Where(p => p.UserName == userName).Select(p => p.Password).SingleOrDefault();
            }
        }
    }
}
