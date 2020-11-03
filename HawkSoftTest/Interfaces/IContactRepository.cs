using System.Collections.Generic;

namespace HawkSoftTest
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetAllBySearch(string filter);
    }
}