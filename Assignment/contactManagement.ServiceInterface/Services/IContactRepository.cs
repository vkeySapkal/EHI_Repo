using contactManagement.Model;
using System;
using System.Collections.Generic;

namespace contactManagement.Services
{
    public interface IContactRepository
    {
        //get single
        Contact getContactById(Int64 id);

        // list
        IEnumerable<Contact> getAll();

        //add new
        Contact addContact(Contact contact);

        // update
        Contact updateContact(Contact contact);

        //delete
        Contact deleteContact(Int64 id);

    }
}
