using ACMA.Domain.Entities.Access;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMA.Repository.Repository
{
    public class AccessRepository : RootBaseRepository
    {
        public AccessProfile GetAccessProfileBy(int idUser) {
            return this.Context.User.Select(p => p.AccessProfile).First(p=>p.Id == idUser);
        } 

    }
}
