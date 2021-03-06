﻿using System;
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
            DataAccess.ExecuteNonQuery(
                "AddContact",
                new SqlParameter("@userId", 1),
                new SqlParameter("@firstName", entity.FirstName),
                new SqlParameter("@lastName", entity.LastName),
                new SqlParameter("@email", entity.Email));
        }

        public void Delete(Contact entity)
        {
            DataAccess.ExecuteNonQuery(
                "DeleteContact",
                new SqlParameter("@contactId", entity.Id));
        }

        public void Edit(Contact entity)
        {
            DataAccess.ExecuteNonQuery(
                "EditContact",
                new SqlParameter("@contactId", entity.Id),
                new SqlParameter("@firstName", entity.FirstName),
                new SqlParameter("@lastName", entity.LastName),
                new SqlParameter("@email", entity.Email),
                new SqlParameter("@updateKey", entity.UpdateKey));
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
