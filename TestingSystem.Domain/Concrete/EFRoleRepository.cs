﻿using TestingSystem.Domain.Abstract;
using TestingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestingSystem.Domain.Concrete
{
    public class EFRoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public EFRoleRepository(DbContext context)
        {
            this.context = context;
        }

        public Role GetById(int id)
        {
            return context.Set<Role>().FirstOrDefault(r => r.Id == id);
        }

        public Role GetByName(string name)
        {
            return context.Set<Role>().FirstOrDefault(r => r.Name == name);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Set<Role>();
        }

        public void Create(Role entity)
        {
            context.Set<Role>().Add(entity);
            context.SaveChanges();
        }

        public void Update(Role entity)
        {
            if (entity == null) return;

            Role roleToUpdate = context.Set<Role>().FirstOrDefault(r => r.Id == entity.Id);
            context.Entry(roleToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Id == entity.Id);
            context.Set<Role>().Remove(role);
            context.SaveChanges();
        }
    }
}
