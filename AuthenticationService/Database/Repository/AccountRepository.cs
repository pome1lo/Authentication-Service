using JWTAuthenticationManager;

namespace AuthenticationService.Database.Repository
{
    public class AccountRepository : IRepository<UserAccount> 
    {
        private AccountDbContext db;
        public AccountRepository(AccountDbContext db)
        {
            this.db = db;
        }

        public void Create(UserAccount item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> GetBookList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserAccount item)
        {
            throw new NotImplementedException();
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}