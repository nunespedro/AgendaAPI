using AgendaAPI.Application.Services;
using AgendaAPI.Application.ViewModel;
using AgendaAPI.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/contact")]
    public class ContactControllet : ControllerBase
    {
        private readonly IContactService _service;

        public ContactControllet(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _service.GetAllAsync();
            if (contacts == null || !contacts.Any())
            {
                return NotFound("No contacts found.");
            }
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound($"Contact not found.");
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact cannot be null.");
            }

            await _service.AddAsync(contact);

            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact cannot be null.");
            }

            var existingContact = await _service.GetByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound($"Contact not found.");
            }

            existingContact.Name = contact.Name ?? existingContact.Name;
            existingContact.Email = contact.Email ?? existingContact.Email;
            existingContact.Phone = contact.Phone ?? existingContact.Phone;

            await _service.UpdateAsync(existingContact);

            return Ok(existingContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingContact = await _service.GetByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound($"Contact not found.");
            }

            await _service.DeleteAsync(id);

            return Ok($"Contact has been deleted.");
        }
    }
}
