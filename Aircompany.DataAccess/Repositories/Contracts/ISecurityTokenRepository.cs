using System;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Repositories.Contracts
{
    public interface ISecurityTokenRepository : IDisposable, IRepository<SecurityToken>
    {
        string GetUsernameByToken(Guid token);
    }
}