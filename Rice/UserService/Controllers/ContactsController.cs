using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs.Contact;
using UserService.Repositories.Contact;
using UserService.Requests.Contact;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository=contactRepository;
        }

        [HttpPost]
        public ContactReadDto Post([FromBody] ContactPostRequest contactPostRequest)
        {
            return _contactRepository.Create(contactPostRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_contactRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
