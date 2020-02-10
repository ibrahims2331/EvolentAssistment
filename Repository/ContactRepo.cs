using Contract;
using DataModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepo : IContact
    {
        readonly EvolentAssistmentEntities _dbContext;
        public ContactRepo(EvolentAssistmentEntities dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// get cotact list
        /// </summary>
        /// <returns></returns>
        List<ContactModel> IContact.GetContacts()
        {
            try
            {
                return (from c in _dbContext.Contacts
                        select new ContactModel
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Email = c.Email,
                            PhoneNumber = c.PhoneNumber,
                            Status = c.Status,
                            CreatedDate = c.CreatedDate
                        }).ToList();
            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
            }
            return null;
        }
        /// <summary>
        /// get Contact By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ContactModel IContact.GetContact(int Id)
        {
            try
            {
                return (from c in _dbContext.Contacts
                        where c.Id == Id && c.Status == true
                        select new ContactModel
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Email = c.Email,
                            PhoneNumber = c.PhoneNumber,
                            Status = c.Status,
                            CreatedDate = c.CreatedDate
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
            }
            return null;
        }
        /// <summary>
        /// Insert Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public string InsertContact(ContactModel contact)
        {
            try
            {
                _dbContext.Contacts.Add(new Contact
                {

                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Status = true,
                    CreatedDate = DateTime.Now

                });
                _dbContext.SaveChanges();
                return "Success";

            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
            }
            return "Failed";
        }
        /// <summary>
        /// delete contact
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeleteContact(int Id)
        {
            try
            {
                Contact contact = (from c in _dbContext.Contacts
                                   where c.Id == Id && c.Status == true
                                   select c).FirstOrDefault();
                if (contact != null)
                {

                    contact.Status = false;
                    _dbContext.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {

                Common.ErrorLog.LogError(ex);
            }
            return "Failed";
        }
        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public string UpdateContact(ContactModel contactModel)
        {
            try
            {
                Contact contact = (from c in _dbContext.Contacts
                                   where c.Id == contactModel.Id
                                   select c).FirstOrDefault();
                if (contact != null)
                {
                    contact.FirstName = contactModel.FirstName;
                    contact.LastName = contactModel.LastName;
                    contact.Email = contactModel.Email;
                    contact.PhoneNumber = contactModel.PhoneNumber;

                    _dbContext.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {

                Common.ErrorLog.LogError(ex);
            }
            return "Failed";
        }
    }
}
