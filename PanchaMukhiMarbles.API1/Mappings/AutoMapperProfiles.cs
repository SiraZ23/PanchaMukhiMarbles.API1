using AutoMapper;
using PanchaMukhiMarbles.API1.Models.Domain;
using PanchaMukhiMarbles.API1.Models.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PanchaMukhiMarbles.API1.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AboutSection, AddAboutSectionRequestDto>().ReverseMap();
            CreateMap<AboutSectionDto, AboutSection>().ReverseMap();
            CreateMap<UpdateAboutSectionRequestDto, AboutSection>().ReverseMap();
            CreateMap<ExploreSection,  AddExploreSectionRequestDto>().ReverseMap();
            CreateMap<ExploreSectionDto, ExploreSection>().ReverseMap();
            CreateMap<UpdateExploreSectionRequestDto, ExploreSection>().ReverseMap();
            CreateMap<HeroSection, AddHeroSectionRequestDto>().ReverseMap();
            CreateMap<HeroSectionDto, HeroSection>().ReverseMap();
            CreateMap<UpdateHeroSectionRequestDto, HeroSection>().ReverseMap();
            CreateMap<Logo, AddLogorequestDto>().ReverseMap();
            CreateMap<LogoDto, Logo>().ReverseMap();
            CreateMap<UpdateLogoRequestDto, Logo>().ReverseMap();
            CreateMap<Product, AddProductRequestDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductRequestDto, Product>().ReverseMap();
            CreateMap<ServiceSection, AddServiceSectionRequestDto>().ReverseMap();
            CreateMap<ServiceSectionDto, ServiceSection>().ReverseMap();
            CreateMap<UpdateServiceSectionRequestDto, ServiceSection>().ReverseMap();
            CreateMap<SocialMedia, AddSocialMediaRequestDto>().ReverseMap();
            CreateMap<SocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaRequestDto, SocialMedia>().ReverseMap();
            CreateMap<ContactTable, AddContactTableRequestDto>().ReverseMap();
            CreateMap<ContactTableDto, ContactTable>().ReverseMap();
            CreateMap<UpdateContactTableRequestDto, ContactTable>().ReverseMap();
        }
    }
}
