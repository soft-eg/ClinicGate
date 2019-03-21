using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicGate.Core.Models;
using ClinicGate.DAL;
using ClinicGate.Core.Contracts;
using Microsoft.AspNetCore.Cors;

namespace ClinicGate.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> _context;
        public PatientsController(IRepository<Patient> PatientContext)
        {
            _context = PatientContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.CollectionAsync();
            return patients.OrderByDescending(x => x.CreatedAt);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patient = await _context.FindByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(string id, [FromBody]Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("No item data provided");
            }

            var patientToUpdate = await _context.FindByIdAsync(id);
            if (patientToUpdate == null)
            {
                return NotFound("Item not found");
            }
            else
            {
                try
                {
                    patientToUpdate.PasNumber = patient.PasNumber;
                    patientToUpdate.Forenames = patient.Forenames;
                    patientToUpdate.Surname = patient.Surname;
                    patientToUpdate.DateOfBirth = patient.DateOfBirth;
                    patientToUpdate.SexCode = patient.SexCode;
                    patientToUpdate.HomeTelephoneNumber = patient.HomeTelephoneNumber;
                    patientToUpdate.NokName = patient.NokName;
                    patientToUpdate.NokRelationshipCode = patient.NokRelationshipCode;
                    patientToUpdate.NokAddressLine1 = patient.NokAddressLine1;
                    patientToUpdate.NokAddressLine2 = patient.NokAddressLine2;
                    patientToUpdate.NokAddressLine3 = patient.NokAddressLine3;
                    patientToUpdate.NokPostcode = patient.NokPostcode;
                    patientToUpdate.GpCode = patient.GpCode;
                    patientToUpdate.GpSurname = patient.GpSurname;
                    patientToUpdate.GpInitials = patient.GpInitials;
                    patientToUpdate.GpPhone = patient.GpPhone;
                    await _context.CommitAsync();
                    return Ok();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }



            }

        }

        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody]Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var patientExists = await _context.AnyAsync(patient.Id);
                if (patientExists)
                {
                    return BadRequest(ModelState);
                }
                _context.Insert(patient);
                await _context.CommitAsync();

                return Ok();
            }


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute]string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patientToDelete = await _context.FindByIdAsync(id);

            if (patientToDelete == null)
            {
                return NotFound();
            }
            _context.Delete(id);
            await _context.CommitAsync();
            return Ok(patientToDelete);

        }
    }
}