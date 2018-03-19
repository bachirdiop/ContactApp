using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddContactAsync(T item);
        Task<bool> UpdateContactAsync(T item);
        Task<bool> DeleteContactAsync(T item);
        Task<T> GetContactAsync(string id);
        Task<IEnumerable<T>> GetContactListAsync(bool forceRefresh = false);
    }
}
