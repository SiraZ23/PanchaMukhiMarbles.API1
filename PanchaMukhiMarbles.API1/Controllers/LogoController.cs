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
    public class LogoController : ControllerBase
    {
        private readonly ILogoRepository logoRepository;
        private readonly IMapper mapper;

        public LogoController(ILogoRepository logoRepository,IMapper mapper)
        {
            this.logoRepository = logoRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddLogorequestDto addLogorequestDto)
        {
            //Map DTO To Domain Model
            var logoDomainModel = mapper.Map<Logo>(addLogorequestDto);

            //Making Repository For Logo
            await logoRepository.CreateAsync(logoDomainModel);

            //Map Domain Model To DTO
            return Ok(mapper.Map<LogoDto>(logoDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedLogoDomainModel = await logoRepository.DeleteAsync(id);
            if (deletedLogoDomainModel==null)
            {
                return NotFound();
            }
            //map Domain Model To DTO
            return Ok(mapper.Map<LogoDto>(deletedLogoDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id,UpdateLogoRequestDto updateLogoRequestDto)
        {
            var logoDomainModel=mapper.Map<Logo>(updateLogoRequestDto);

            logoDomainModel=await logoRepository.UpdateAsync(id,logoDomainModel);
            if(logoDomainModel==null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<LogoDto>(logoDomainModel));
        }
    }
}
