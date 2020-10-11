using System;
using System.Threading.Tasks;

namespace Codeizi.Infra.Core.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}