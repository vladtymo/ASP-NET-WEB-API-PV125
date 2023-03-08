﻿using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ShopDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(ShopDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async virtual Task<TEntity?> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async virtual Task Delete(object id)
        {
            TEntity? entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
                await Delete(entityToDelete);
        }

        public virtual Task Delete(TEntity entityToDelete)
        {
            return Task.Run(() =>
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            });
        }

        public virtual Task Update(TEntity entityToUpdate)
        {
            return Task.Run(() =>
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }

        // working with specifications
        public async Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(dbSet, specification);
        }
    }
}
