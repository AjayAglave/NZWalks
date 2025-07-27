using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Dmain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // create walk
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            // Map dto to domain model
          
            var walkDomainModel = mapper.Map<Walks>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomainModel);
            // Map domain model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
           var walksDomainModel= await walkRepository.GetAllAsync();
            //Map Domain model to dto

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }
    }
}
