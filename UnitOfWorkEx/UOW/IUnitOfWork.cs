using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkEx.UOW
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        void RollBack();

        Task DisposeAsync();
    }
}