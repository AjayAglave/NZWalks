using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Dmain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Linq;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository ,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: htttp://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var regions = new list<region>
            //{
            //    new region
            //    {
            //        id = guid.newguid(),
            //        name = "auckland region",
            //        code = "akl",
            //        regionimageurl = "https://cdn.pixabay.com/photo/2017/03/06/22/01/new-zealand-2129794_1280.jpg"
            //    },
            //    new region
            //    {
            //        id = guid.newguid(),
            //        name = "india region",
            //        code = "ind",
            //        regionimageurl = "https://cdn.pixabay.com/photo/2017/01/20/00/30/gateway-of-india-1995527_1280.jpg"
            //    }
            //};

            /////////////////////////////////////////////////

            //Get data from the databgase  --- Domain Models
            //  var regionsDomain= await dbContext.Regions.ToListAsync();

            var regionsDomain = await regionRepository.GetAllAsync();

            // map Domain models to DTOs
           /* var regiondDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regiondDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }
*/
            // map Domain models to DTOs
            var regiondDto  =   mapper.Map<List<Region>>(regionsDomain);

            // return DTOs
            return Ok(regiondDto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult> GetById( [FromRoute] Guid id) {

            //var region =  dbContext.Regions.Find(id);  it will find only primary key menas id

            // var regionDomain= await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);  // this we can use for the all id like name,id,code anything
            var regionDomain = await regionRepository.GetByIdAsync(id);   // used repository pattern

            if(regionDomain == null)
            {
                return NotFound();
            }

            // Map / Convert Region Domain Model to Region DTO

            /* var regionDto = new RegionDto()
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionImageUrl = regionDomain.RegionImageUrl,
             };*/
            var regionDto = mapper.Map<RegionDto>(regionDomain);


           // return BackgroundService to cleint

            return Ok(regionDto);

        }

        [HttpPost]
       // [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto )
        {

            if(ModelState.IsValid)
            {
                // Map oe Convert DTO to Domain Model
                /*var regionDomainModel = new Region
                {
                    Code = addRegionRequestDto.Code,
                    Name = addRegionRequestDto.Name,
                    RegionImageUrl=addRegionRequestDto.RegionImageUrl,
                };*/

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Use Doamin Model to create Region

                /* await dbContext.Regions.AddAsync(regionDomainModel);
                 await dbContext.SaveChangesAsync();*/

                await regionRepository.CreateAsync(regionDomainModel);


                // Map Domain model back to DTO

                /*  var regiondDto = new RegionDto
                  {
                      Id = regionDomainModel.Id,
                      Code = regionDomainModel.Code,
                      Name = regionDomainModel.Name,
                      RegionImageUrl = regionDomainModel.RegionImageUrl,
                  };*/
                var regiondDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regiondDto.Id }, regiondDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
          

        }

        //Update Region
        //PUT: 

        [HttpPut]
        [Route("{id:Guid}")]
        //[ValidateModel]
        public async Task<IActionResult>  Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                /*var regionDomainModel = new Region
           {
               Code = updateRegionRequestDto.Code,
               Name = updateRegionRequestDto.Name,
               RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
           };*/
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                // cheeck of region exist
                //  var regionDomainModel = await  dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                /* // Map DTO to Domain model  /// when we are not using repository pattern
                 regionDomainModel.Code = updateRegionRequestDto.Code;
                 regionDomainModel.Name = updateRegionRequestDto.Name;
                 regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;*/


                await dbContext.SaveChangesAsync();

                // Convert Domain to Dto

                /* var regionDto = new RegionDto
                 {
                     Id = regionDomainModel.Id,
                     Name = regionDomainModel.Name,
                     Code = regionDomainModel.Code,
                     RegionImageUrl = regionDomainModel.RegionImageUrl,
                 };*/
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
           

        }

        // Delete Region
        //DELETE

        [HttpDelete]
        [Route("{id:Guid}")]
        public async  Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // cheeck of region exist
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

           

            // Delete region

            /* dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();*/

            // return the deleted region back
            // map domain model to Dto

            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            /* var regionDto = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Name = regionDomainModel.Name,
                 Code = regionDomainModel.Code,
                 RegionImageUrl = regionDomainModel.RegionImageUrl,
             };*/
            var regionDto=mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }
}
