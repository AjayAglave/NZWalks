using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
           /* if (walksDomainModel.IsNullOrEmpty())
            {
               return NotFound();
            }*/
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
       public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel=await walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto )
        {

            // Map dto to domain mopdel

            var walkDomainModel = mapper.Map<Walks>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        // delete a walk by ur

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
