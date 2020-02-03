using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext Context { get; }

        public UnitOfWork(DatabaseContext context)
        {
            Context = context;
        }

        public async Task DisposeAsync()
        {
            await Context.DisposeAsync();
        }

        public void RollBack()
        {
            Context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}