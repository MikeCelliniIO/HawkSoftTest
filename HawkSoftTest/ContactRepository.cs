using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HawkSoftTest
{
    public class ContactRepository : IContactRepository
    {
        IDataAccess DataAccess { get; }
        public ContactRepository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void Add(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Contact entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAllBySearch(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
