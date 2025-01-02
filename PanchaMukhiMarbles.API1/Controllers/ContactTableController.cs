using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanchaMukhiMarbles.API1.CustomActionFilter;
using PanchaMukhiMarbles.API1.Models.Domain;
using PanchaMukhiMarbles.API1.Models.DTO;
using PanchaMukhiMarbles.API1.Repositories;

namespace PanchaMukhiMarbles.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTableController : ControllerBase
    {
        private readonly IContactTableRepository contactTableRepository;
        private readonly IMapper mapper;

        public ContactTableController(IContactTableRepository contactTableRepository, IMapper mapper)
        {
            this.contactTableRepository = contactTableRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync(AddContactTableRequestDto addContactTableRequestDto)
        {
            //Map DTO To Domain Model
            var contactTable=mapper.Map<ContactTable>(addContactTableRequestDto);

            //Making Repository For contactTables
            await contactTableRepository.CreateAsync(contactTable);

            //Map Domain MOdel To DTO
            return Ok(mapper.Map<ContactTableDto>(contactTable));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define The Repository To Use Inside Method
            var contactTable=await contactTableRepository.GetAllAsync();    

            //Map Domain Table To DTO
            return Ok(mapper.Map<List<ContactTableDto>>(contactTable)); 
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Go To Repository To Get The Contact
            var contactTable=await contactTableRepository.GetByIdAsync(id);
            if(contactTable == null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<ContactTableDto>(contactTable));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id,UpdateContactTableRequestDto updateContactTableRequestDto)
        {
            var contactTable = mapper.Map<ContactTable>(updateContactTableRequestDto);
            contactTable=await contactTableRepository.UpdateAsync(id,contactTable);
            if (contactTable == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ContactTableDto>(contactTable));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedContactTable=await contactTableRepository.DeleteAsync(id);
            if (deletedContactTable == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ContactTableDto>(deletedContactTable));
        }
    }
}
