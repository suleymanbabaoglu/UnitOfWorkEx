using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task DisposeAsync()
        {
            await context.DisposeAsync();
        }

        public void RollBack()
        {
            context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}