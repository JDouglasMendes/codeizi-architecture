using System;
using System.Threading.Tasks;

namespace Codeizi.Infra.Core.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}