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
    public class ServiceSectionController : ControllerBase
    {
        private readonly IServiceSectionRepository serviceSectionRepository;
        private readonly IMapper mapper;

        public ServiceSectionController(IServiceSectionRepository serviceSectionRepository,IMapper mapper)
        {
            this.serviceSectionRepository = serviceSectionRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> CreateAsync([FromBody] AddServiceSectionRequestDto addServiceSectionRequestDto)
        {
            //Map DTO To Domain Model
            var serviceSectionDomainModel = mapper.Map<ServiceSection>(addServiceSectionRequestDto);

            //Making Repository
            await serviceSectionRepository.CreateAsync(serviceSectionDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<ServiceSectionDto>(serviceSectionDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define The Repository To Use Inside Method
            var existingServiceSectionDomainModel=await serviceSectionRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<ServiceSectionDto>>(existingServiceSectionDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id,UpdateAboutSectionRequestDto updateAboutSectionRequestDto)
        {
            //Go To Repository To Get The ServiceSection
            var serviceSectionDomainModel=await serviceSectionRepository.GetByIdAsync(id);
            if(serviceSectionDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ServiceSectionDto>(serviceSectionDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,UpdateServiceSectionRequestDto updateServiceSectionRequestDto)
        {
            //Map DTO TO Domain Model
            var serviceSectionDomainModel = mapper.Map<ServiceSection>(updateServiceSectionRequestDto);
            if(serviceSectionDomainModel==null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ServiceSectionDto>(serviceSectionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var deletedserviceSectionDomainModel=await serviceSectionRepository.DeleteAsync(id);
            if(deletedserviceSectionDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ServiceSectionDto>(deletedserviceSectionDomainModel));
        }
    }
}
