using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {

        readonly IContact _contact;
        public ContactController(IContact contact)
        {
            _contact = contact;
        }

        [HttpGet]
        public List<ContactModel> Get()
        {
            return _contact.GetContacts();
        }

        [ResponseType(typeof(ContactModel))]
        public IHttpActionResult GetContact(int id)
        {
            ContactModel contact = _contact.GetContact(id);
            if (contact == null)
            { return NotFound(); }
            return Ok(contact);
        }


        [ResponseType(typeof(ContactModel))]
        public IHttpActionResult PostContact(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);

                string result = _contact.InsertContact(contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
                return Ok("Failed");
            }
        }

        // PUT: api/Contact/5
        public IHttpActionResult PutContact(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                string result = _contact.UpdateContact(contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
                return Ok("Failed");
            }
        }

        // DELETE: api/Contact/5
        public IHttpActionResult DeleteContact(int id)
        {
            try
            {
                string result = _contact.DeleteContact(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Common.ErrorLog.LogError(ex);
                return Ok("Failed");
               
            }
        }
    }
}
