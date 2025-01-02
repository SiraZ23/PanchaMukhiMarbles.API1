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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //Map DTO To Domain Model
            var productDomainModel = mapper.Map<Product>(addProductRequestDto);

            //Making Repository For products
            await productRepository.CreateAsync(productDomainModel);    

            //Map Domain Model To DTO
            return Ok(mapper.Map<Product>(productDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //Define The Repository To Use Inside Method
            var productDomainModel=await productRepository.GetAllAsync();

            //Map Domain Model To DTO
            return Ok(mapper.Map<List<Product>>(productDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            //Go To Repository To Get The Products
            var productDomainModel = await productRepository.GetByIdAsync(id);
            if (productDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model To DTO
            return Ok(mapper.Map<ProductDto>(productDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,UpdateProductRequestDto updateProductRequestDto)
        {
            var productDomainModel=mapper.Map<Product>(updateProductRequestDto);

            productDomainModel=await productRepository.UpdateAsync(id,productDomainModel);
            if (productDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ProductDto>(productDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedProductDomainModel=await productRepository.DeleteAsync(id);
            if (deletedProductDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model To DTO
            return Ok(mapper.Map<ProductDto>(deletedProductDomainModel));
        }
    }
}
