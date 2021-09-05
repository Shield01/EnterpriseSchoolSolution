using AutoMapper;
using Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.DTOs.StudentDTOs;
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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;

            _mapper = mapper;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDTO>> Get()
        {
            var result = _studentRepo.GetAll();

            var value = _mapper.Map<IEnumerable<StudentReadDTO>>(result);

            return Ok(value);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}", Name = "Gets")]
        public ActionResult<StudentReadDTO> Gets(int id)
        {
            var result = _studentRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var value = _mapper.Map<StudentReadDTO>(result);

                return Ok(value);
            } 
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<StudentReadDTO> Post([FromBody] StudentCreateDTO newObject)
        {
            var value = _mapper.Map<Student>(newObject);

            _studentRepo.Create(value);

            var valueReturned = _mapper.Map<StudentReadDTO>(value);

            return CreatedAtRoute(nameof(Gets), new { Id = valueReturned.Id }, valueReturned);
        }

        //PATCH api/<StudentsController>/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<StudentUpdateDTO> patchDoc)
        {
            var result = _studentRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var objectToPatch = _mapper.Map<StudentUpdateDTO>(result);

                patchDoc.ApplyTo(objectToPatch, ModelState);

                if (!TryValidateModel(objectToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(objectToPatch, result);

                    _studentRepo.Update(result);

                    return NoContent();
                }
            }  
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oldObject = _studentRepo.Get(id);

            if (oldObject == null)
            {
                return NotFound();
            }
            else
            {
                _studentRepo.Delete(oldObject);

                return NoContent();
            }

           
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentUpdateDTO updatedStudent)
        {
            var result = _studentRepo.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                var value = _mapper.Map(updatedStudent, result);

                _studentRepo.Update(result);

                return NoContent();
            }
        }
    }
}
