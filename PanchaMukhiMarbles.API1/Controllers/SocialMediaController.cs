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
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaRepository socialMediaRepository;
        private readonly IMapper mapper;

        public SocialMediaController(ISocialMediaRepository socialMediaRepository,IMapper mapper)
        {
            this.socialMediaRepository = socialMediaRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody]AddSocialMediaRequestDto addSocialMediaRequestDto)
        {
            //Map DTO To Domain Model
            var socialMediaDomainModel = mapper.Map<SocialMedia>(addSocialMediaRequestDto);

            //Making Repository For Social Media
            await socialMediaRepository.CreateAsync(socialMediaDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<SocialMediaDto>(socialMediaDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define The Repository To Use Inside The Method
            var socialMediaDomainModel = await socialMediaRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<SocialMediaDto>>(socialMediaDomainModel));    
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Go To Repository To Get The Social Media
            var socialMediaDomainMOdel=await socialMediaRepository.GetByIdAsync(id);
            if(socialMediaDomainMOdel == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<SocialMediaDto> (socialMediaDomainMOdel)); 
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]  
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateSocialMediaRequestDto updateSocialMediaRequestDto)
        {
            //Map DTO To Domain Model
            var socialMediaDomainModel = mapper.Map<SocialMedia>(updateSocialMediaRequestDto);

            //Create Update Method in ISocialMedia repository
            socialMediaDomainModel=await socialMediaRepository.UpdateAsync(id, socialMediaDomainModel);

            if(socialMediaDomainModel==null)
            {
                return NotFound();
            }

            //map Domain Model To Dto
            return Ok(mapper.Map<SocialMediaDto>(socialMediaDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedSocialMediaDomainModel=await socialMediaRepository.DeleteAsync(id);
            if(deletedSocialMediaDomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<SocialMediaDto>(deletedSocialMediaDomainModel));
        } 
    }
}
