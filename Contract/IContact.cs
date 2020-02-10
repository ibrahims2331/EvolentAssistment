using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IContact
    {
        // get list of all available contacts
        List<ContactModel> GetContacts();
        //get contact by Id
        ContactModel GetContact(int Id);
        // add new contact
        string InsertContact(ContactModel contact);
        //delete existing contact
        string DeleteContact(int Id);
        //update contact information
        string UpdateContact(ContactModel contact);
    }
}
