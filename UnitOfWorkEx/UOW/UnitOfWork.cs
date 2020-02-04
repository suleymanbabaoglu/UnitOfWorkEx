using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext context;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.DisposeAsync();
            GC.Collect();
            GC.SuppressFinalize(this);
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