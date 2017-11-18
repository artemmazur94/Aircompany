using System;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class SecurityTokenRepository : GenericRepositrory<SecurityToken>, ISecurityTokenRepository
    {
        private AircompanyContext SecurityTokenContext => Context;

        public SecurityTokenRepository(AircompanyContext context) : base(context)
        {
        }

        public string GetUsernameByToken(Guid token)
        {
            DateTime datetime = DateTime.UtcNow.AddDays(-1);
            var securityToken = SecurityTokenContext.SecurityTokens.FirstOrDefault
                (
                    x => x.Id == token &&
                         x.ResetRequestDateTime > datetime &&
                         x.IsUsed == false
                );
            return securityToken?.Account.Login;
        }
    }
}