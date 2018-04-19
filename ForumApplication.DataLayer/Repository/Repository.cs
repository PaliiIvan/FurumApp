﻿using ForumApplication.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext Context { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public void AddNewItem(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void DeleteItem(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteItemById(object id)
        {
            var item = DbSet.Find(id);
            DeleteItem(item);
            Context.SaveChanges();
        }

        public TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public IList<TEntity> GetAll(int pagenumber, int pageSize)
        {
            return DbSet.Select(x => x)
                .Page(pagenumber,pageSize)
                .ToList();
        }

        public virtual void Dispouse()
        {
            Context.Dispose();
        }
    }
}
