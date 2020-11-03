using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawkSoftTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactRepository ContactRepository { get; }

        public ContactsController(IContactRepository contactRepo)
        {
            ContactRepository = contactRepo;
        }

        public IEnumerable<Contact> Get()
        {
            return ContactRepository.GetAll();
        }
    }
}
