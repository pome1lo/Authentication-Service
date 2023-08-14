﻿namespace AuthenticationService.Database.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetBookList();
        T GetBook(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}