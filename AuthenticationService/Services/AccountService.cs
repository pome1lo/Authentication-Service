using AuthenticationService.Database;
using AuthenticationService.Database.Repository;
using JWTAuthenticationManager;
using TokenHandlerModels;

namespace AuthenticationService.Services
{
    public class AccountService
    {
        private readonly AccountDbContext db;

        public AccountService(AccountDbContext db)
        {
            this.db = db;    
        }

        private AccountRepository _accountRepository = null!;

        public AccountRepository Accounts
        {
            get
            {
                return _accountRepository ?? new AccountRepository(db);
            }
        }

        public UserAccount? GetUserAccountOrDefault(AuthenticationRequest request)
        {
            var user = Accounts.GetCollection().FirstOrDefault(x => x.Name == request.UserName);
            
            if (user is not null)
            {
                EncryptionService service = new(request.Password);

                if (EncryptionService.Verify(service.Salt, user.Hash, request.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region Dispose 

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 

        #endregion
    }
}