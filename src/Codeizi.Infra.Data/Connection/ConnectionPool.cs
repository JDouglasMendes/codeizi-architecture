using Codeizi.DI.Anotations;
using Codeizi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Codeizi.Infra.Data.Connection
{
    [InjectableScoped]
    public class ConnectionPool
    {
        private readonly CodeiziContext codeiziContext;

        public ConnectionPool(CodeiziContext codeiziContext)
            => this.codeiziContext = codeiziContext;

        public IDbConnection Get()
            => codeiziContext.Database.GetDbConnection();
    }
}