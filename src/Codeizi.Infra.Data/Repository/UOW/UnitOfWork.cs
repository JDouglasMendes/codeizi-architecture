using Codeizi.DI.Helper.Anotations;
using Codeizi.Infra.Core.UOW;
using Codeizi.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace Codeizi.Infra.Data.Repository.UOW
{
    [Injectable(typeof(IUnitOfWork),
                typeof(UnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeiziContext codeiziContext;

        public UnitOfWork(CodeiziContext codeiziContext)
        {
            this.codeiziContext = codeiziContext;
        }

        public async Task<bool> Commit()
            => await this.codeiziContext.SaveChangesAsync() > 0;
    }
}