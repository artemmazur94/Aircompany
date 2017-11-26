using System;
using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class AccountRepository : GenericRepositrory<Account>, IAccountRepository
    {
        private AircompanyContext AccountContext => Context;

        public AccountRepository(AircompanyContext context) : base(context)
        {
        }

        public bool IsExistUsername(string username)
        {
            return
                AccountContext.Accounts.FirstOrDefault(
                    x => x.Login.Equals(username, StringComparison.CurrentCultureIgnoreCase)) != null;
        }

        public bool IsExistEmail(string email)
        {
            return
                AccountContext.Profiles.FirstOrDefault(
                    x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)) != null;
        }

        public bool IsValidLoginData(Account account)
        {
            return
                AccountContext.Accounts.FirstOrDefault(x =>
                x.Login == account.Login &&
                x.Password == account.Password) != null;
        }

        public Account GetAccountByUsername(string username)
        {
            return AccountContext.Accounts.Single(x => x.Login == username);
        }

        public Profile GetProfile(int id)
        {
            return AccountContext.Profiles.Single(x => x.Id == id);
        }

        public Profile GetProfileByEmail(string email)
        {
            return AccountContext.Profiles.Single(x => x.Email == email);
        }

        public bool IsExistExternalAccount(string userIdentity, int externalProviderId)
        {
            return AccountContext.ExternalAccounts.FirstOrDefault(x =>
                x.ExternalProviderId == externalProviderId &&
                x.UserIdentity == userIdentity) != null;
        }

        public void AddExternalAccount(ExternalAccount externalAccount)
        {
            AccountContext.ExternalAccounts.Add(externalAccount);
        }

        public List<ExternalProvider> GetNonAttachedExternalProviders(int profileId)
        {
            List<int> externalProviderIds =
                AccountContext.ExternalAccounts.Where(x => x.ProfileId == profileId)
                    .Select(x => x.ExternalProviderId)
                    .ToList();
            return AccountContext.ExternalProviders.Where(x => !externalProviderIds.Contains(x.Id)).ToList();
        }

        public bool IsAttachedExternalAccount(int profileId, int externalProviderId)
        {
            return
                AccountContext.Profiles.FirstOrDefault(x => x.Id == profileId)
                    .ExternalAccounts.Any(x => x.ExternalProviderId == externalProviderId);
        }

        public bool IsAttachedExternalAccountToCurrentProfile(string userIdentity, int externalProviderId, int profileId)
        {
            return
                AccountContext.ExternalAccounts.FirstOrDefault(
                    x =>
                        x.UserIdentity == userIdentity && 
                        x.ProfileId == profileId &&
                        x.ExternalProviderId == externalProviderId) != null;
        }

        public List<Discount> GetActiveDiscounts()
        {
            var dateTime = DateTime.Now.Date;
            return AccountContext.Discounts
                .Where(x => (x.StartDate <= dateTime && x.EndDate >= dateTime)
                    || (x.StartDate > dateTime))
                .ToList();
        }

        public void AddDiscount(Discount discount)
        {
            AccountContext.Discounts.Add(discount);
        }

        public int? GetCurrentDiscount()
        {
            return AccountContext.Discounts
                .FirstOrDefault(x => x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now)?.PercentageAmount;
        }
    }
}