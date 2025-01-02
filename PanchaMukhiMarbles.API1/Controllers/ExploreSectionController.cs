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
    public class ExploreSectionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IExploreSectionRepository exploreSectionRepository;

        public ExploreSectionController(IMapper mapper,IExploreSectionRepository exploreSectionRepository)
        {
            this.mapper = mapper;
            this.exploreSectionRepository = exploreSectionRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddExploreSectionRequestDto addExploreSectionRequestDto)
        {
            //Map DTO To Domain Model
            var exploresectionDomainModel = mapper.Map<ExploreSection>(addExploreSectionRequestDto);

            await exploreSectionRepository.CreateAsync(exploresectionDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<ExploreSectionDto>(exploresectionDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define The repository 
            var exploresectionDomainModel = await exploreSectionRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<ExploreSectionDto>>(exploresectionDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            //Checking The Explore Section 
            var exploresectionDomainModel=await exploreSectionRepository.GetByIdAsync(id);
            if (exploresectionDomainModel==null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ExploreSectionDto>(exploresectionDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateExploreSectionRequestDto updateExploreSectionRequestDto)
        {
            //Map DTO To Domain MOdel
            var exploresectionDomainModel = mapper.Map<ExploreSection>(updateExploreSectionRequestDto);
            exploresectionDomainModel = await exploreSectionRepository.UpdateAsync(id, exploresectionDomainModel);
            if(exploresectionDomainModel==null)
            {
                return NotFound();
            }
            //Map DomainModel To DTO
            return Ok(mapper.Map<ExploreSection>(exploresectionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedexploreSection = await exploreSectionRepository.DeleteAsync(id);
            if (deletedexploreSection==null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ExploreSectionDto>(deletedexploreSection));
        }
      
    }
}
