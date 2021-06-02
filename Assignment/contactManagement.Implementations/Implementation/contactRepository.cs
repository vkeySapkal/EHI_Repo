using contactManagement.Model;
using contactManagement.Services;
using System;
using System.Collections.Generic;

namespace contactManagement.Implementation
{
    public class contactRepository : IContactRepository
    {
        private readonly AppDBContext _context;

        public contactRepository(AppDBContext context)
        {
            _context = context;
        }

        public Contact addContact(Contact contact)
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact deleteContact(Int64 id)
        {
            Contact contact = _context.contacts.Find(id);
            if (contact != null)
            {
                _context.contacts.Remove(contact);
                _context.SaveChanges();
            }
            return contact;
        }

        public IEnumerable<Contact> getAll()
        {
            return _context.contacts;
        }

        public Contact getContactById(Int64 Id)
        {
            return _context.contacts.Find(Id);
        }

        public Contact updateContact(Contact contactUpdated)
        {
            var contact = _context.contacts.Attach(contactUpdated);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return contactUpdated;
        }
    }
}
