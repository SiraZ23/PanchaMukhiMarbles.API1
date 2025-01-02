using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanchaMukhiMarbles.API1.CustomActionFilter;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;
using PanchaMukhiMarbles.API1.Models.DTO;
using PanchaMukhiMarbles.API1.Repositories;

namespace PanchaMukhiMarbles.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutSectionController : ControllerBase
    {        
        private readonly IAboutSectionRepository aboutSectionRepository;
        private readonly IMapper mapper;

        public AboutSectionController(IAboutSectionRepository aboutSectionRepository,IMapper mapper)
        {
            this.aboutSectionRepository = aboutSectionRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddAboutSectionRequestDto addAboutSectionRequestDto)
        {
            //Map DTO To Domain Model
            var aboutsectionDomainModel = mapper.Map<AboutSection>(addAboutSectionRequestDto); 
         
            await aboutSectionRepository.CreateAsync(aboutsectionDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<AboutSectionDto>(aboutsectionDomainModel));
        }

        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            //Define The Repository To Use Inside The Method
            var aboutsectionDomainModel = await aboutSectionRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<AboutSectionDto>>(aboutsectionDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {          
            var aboutsectionDomainModel = await aboutSectionRepository.GetByIdAsync(id);
            if (aboutsectionDomainModel==null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AboutSectionDto>(aboutsectionDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id,UpdateAboutSectionRequestDto updateAboutSectionRequestDto)
        {
            //Map DTO To Domain MOdel
            var aboutsectionDomainModel=mapper.Map<AboutSection>(updateAboutSectionRequestDto);

            aboutsectionDomainModel = await aboutSectionRepository.UpdateAsync(id,aboutsectionDomainModel);
            if (aboutsectionDomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<AboutSectionDto>(aboutsectionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id )
        {
            var deletedAboutSectionDomainModel = await aboutSectionRepository.DeleteAsync(id);
            if (deletedAboutSectionDomainModel==null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AboutSectionDto>(deletedAboutSectionDomainModel));
        }
    }
}
