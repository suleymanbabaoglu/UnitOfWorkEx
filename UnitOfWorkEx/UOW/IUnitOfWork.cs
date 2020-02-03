using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.UOW
{
    public interface IUnitOfWork
    {
        public DatabaseContext Context { get; }

        public Task SaveAsync();
        public void RollBack();
        public Task DisposeAsync();
    }
}