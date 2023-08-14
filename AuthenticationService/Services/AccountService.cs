using AuthenticationService.Database;
using AuthenticationService.Database.Repository;

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

        public void Save()
        {
            db.SaveChanges();
        }

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
    }
}