using AutoMapper;
using Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.DTOs.StaffDTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository _staffRepo;

        private readonly IMapper _mapper;

        public StaffsController(IStaffRepository staffRepo, IMapper mapper)
        {
            _staffRepo = staffRepo;

            _mapper = mapper;
        }

        // GET: api/<StaffsController>
        [HttpGet]
        public ActionResult<IEnumerable<StaffReadDTO>> Get()
        {
            var result = _staffRepo.GetAll();

            var value = _mapper.Map<IEnumerable<StaffReadDTO>>(result);

            return Ok(value);
        }

        // GET api/<StaffsController>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<StaffReadDTO> Get(int id)
        {
            var result = _staffRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var value = _mapper.Map<StaffReadDTO>(result);

                return Ok(value);
            }
        }

        // POST api/<StaffsController>
        [HttpPost]
        public ActionResult<StaffReadDTO> Post([FromBody] StaffCreateDTO newObject)
        {
            var value = _mapper.Map<Staff>(newObject);

            _staffRepo.Create(value);

            var valueToReturn = _mapper.Map<StaffReadDTO>(value);

            return CreatedAtRoute(nameof(Get), new { Id = valueToReturn.Id }, valueToReturn);
        }

        //PATCH api/<StaffsControlle>{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<StaffUpdateDTO> patchDoc)
        {
            var result = _staffRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var objectToPatch = _mapper.Map<StaffUpdateDTO>(result);

                patchDoc.ApplyTo(objectToPatch, ModelState);

                if (!TryValidateModel(objectToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(objectToPatch, result);

                    _staffRepo.Update(result);

                    return NoContent();
                }
            }
        }

        // DELETE api/<StaffsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _staffRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                _staffRepo.Delete(result);

                return NoContent();
            }
        }

        // PUT api/<StaffsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StaffUpdateDTO updatedObject)
        {
            var result = _staffRepo.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                var value = _mapper.Map(updatedObject, result);

                _staffRepo.Update(result);

                return NoContent();
            }
        }
    }
}
