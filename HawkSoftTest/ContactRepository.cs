using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            //TODO: We're gonna just throw in a single user id for now, we'll setup authentication later.
            return DataAccess.ExecuteStoredProcedure<Contact>("GetContactsForUser", new SqlParameter("@userId", 1));
        }

        public IEnumerable<Contact> GetAllBySearch(string filter)
        {
            return DataAccess.ExecuteStoredProcedure<Contact>("GetContactsForUser", new SqlParameter("@userId", 1), new SqlParameter("@filter", filter));
        }
    }
}
