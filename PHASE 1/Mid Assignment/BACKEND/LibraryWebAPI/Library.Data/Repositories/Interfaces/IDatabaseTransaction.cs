using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Interfaces
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}