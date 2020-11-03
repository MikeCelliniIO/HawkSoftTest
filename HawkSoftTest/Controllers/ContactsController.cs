using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HawkSoftTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactRepository ContactRepository { get; }
        private ILogger<ContactsController> Logger { get; }

        public ContactsController(ILogger<ContactsController> logger, IContactRepository contactRepo)
        {
            ContactRepository = contactRepo;
            Logger = logger;
        }

        public EnumerableResult<Contact> Get()
        {
            try
            {
                return new EnumerableResult<Contact>() { Success = true, Data = ContactRepository.GetAll() };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed to fetch contacts.");
                return new EnumerableResult<Contact>() { Success = false, Message = "Oops, something went wrong!" };
            }
        }

        [Route("[action]/{filter}")]
        public EnumerableResult<Contact> GetByFilter(string filter)
        {
            try
            {
                return new EnumerableResult<Contact>() { Success = true, Data = ContactRepository.GetAllBySearch(filter) };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed to fetch contacts filtered by '{filter}'.");
                return new EnumerableResult<Contact>() { Success = false, Message = "Oops, something went wrong!" };
            }
        }

        [HttpPost]
        [Route("[action]")]
        public bool Add(Contact contact)
        {
            try
            {
                ContactRepository.Add(contact);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "");
                return false;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public bool Edit(Contact contact)
        {
            try
            {
                ContactRepository.Edit(contact);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed to update contact {contact.Id}.");
                return false;
            }
        }

        [HttpDelete]
        public bool Delete(Contact contact)
        {
            try
            {
                ContactRepository.Delete(contact);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed to delete contact {contact.Id}.");
                return false;
            }
        }
    }
}
