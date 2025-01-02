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
    public class HeroSectionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IHeroSectionRepository heroSectionRepository;

        public HeroSectionController(IMapper mapper,IHeroSectionRepository heroSectionRepository)
        {
            this.mapper = mapper;
            this.heroSectionRepository = heroSectionRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody]AddHeroSectionRequestDto addHeroSectionRequestDto)
        {
            //Map DomainModel To DTO
            var heroSectionDomainModel = mapper.Map<HeroSection>(addHeroSectionRequestDto);

            //Making Repository For HeroSection
            await heroSectionRepository.CreateAsync(heroSectionDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<HeroSection>(heroSectionDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define Repository To Use Inside Method
            var heroSectionDomainModel = await heroSectionRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<HeroSectionDto>>(heroSectionDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            //Go To Repository To Get The Walk
            var heroSectionDomainModel=await heroSectionRepository.GetByIdAsync(id);
            if (heroSectionDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<HeroSectionDto>(heroSectionDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,UpdateHeroSectionRequestDto updateHeroSectionRequestDto)
        {
            var heroSectionDomainModel = mapper.Map<HeroSection>(updateHeroSectionRequestDto);
            heroSectionDomainModel=await heroSectionRepository.UpdateAsync(id,heroSectionDomainModel);
            if (updateHeroSectionRequestDto == null)
            {
                return NotFound();
            }

            //map Domain Model To DTO
            return Ok(mapper.Map<HeroSectionDto>(heroSectionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var deletedheroSectionDomain=await heroSectionRepository.DeleteAsync(id);
            if (deletedheroSectionDomain==null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<HeroSectionDto>(deletedheroSectionDomain));
        }
    }
}
