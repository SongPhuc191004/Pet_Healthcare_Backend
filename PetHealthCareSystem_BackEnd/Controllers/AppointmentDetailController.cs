﻿using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO.AppointmentDetailDTO;
using ServiceContracts.DTO.Result;
using ServiceContracts.DTO.UserDTO;
using ServiceContracts.Mappers;
using Services;

namespace PetHealthCareSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppointmentDetailService _appointmentDetailService;

        public AppointmentDetailController(ApplicationDbContext context, IAppointmentDetailService appointmentDetailService)
        {
            _context = context;
            _appointmentDetailService = appointmentDetailService;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> AddAppointmentDetail([FromBody] AppointmentDetailAddRequest? appointmentDetail)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BusinessResult businessResult = new BusinessResult();
            var appointmentDetailModel = appointmentDetail.ToAppointmentDetailFromAdd();

            if (appointmentDetailModel == null)
            {
                businessResult.Status = 400;
                businessResult.Data = null;
                businessResult.Message = "AppointmentDetail request is null";
                return BadRequest(businessResult);
            }

            var data = await _appointmentDetailService.AddAppointmentDetailAsync(appointmentDetailModel);

            if(data != null)
            {
                businessResult.Data = data;
                businessResult.Message = "Successful";
                businessResult.Status = 200;
                return Ok(businessResult);
            }
            
            businessResult.Status = 500;
            businessResult.Data = null;
            businessResult.Message = "Failed to retrive data";
            return StatusCode(StatusCodes.Status500InternalServerError, businessResult);
        }

        //Read
        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetails()
        {
            BusinessResult businessResult = new BusinessResult();
            var list = await _appointmentDetailService.GetAppointmentDetailsAsync();
            if (list == null)
            {
                businessResult.Status = 500;
                businessResult.Data = null;
                businessResult.Message = "Failed to retrive data";
                return StatusCode(StatusCodes.Status500InternalServerError, businessResult);
            }
            businessResult.Data = list;
            businessResult.Message = "Successful";
            businessResult.Status = 200;
            return Ok(businessResult);

        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetAppointmentDetailById(int id)
        {
            BusinessResult businessResult = new BusinessResult();
            var appointmentDetail = await _appointmentDetailService.GetAppointmentDetailByIdAsync(id);
            if (appointmentDetail == null)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "No AppointmentDetail found";
                return NotFound(businessResult);
            }
            businessResult.Status = 200;
            businessResult.Data = appointmentDetail;
            businessResult.Message = "AppointmentDetail found";
            return Ok(businessResult);
        }


        //Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiagnosis([FromBody]  AppointmentDetailUpdateDiagnosis appointmentDetail)
        {
            BusinessResult businessResult = new BusinessResult();
            if (!ModelState.IsValid)
            {
                businessResult.Status = 400;
                businessResult.Data = null;
                businessResult.Message = "Request is null";
                return BadRequest(businessResult);
            }
            var appointmentDetailModel = appointmentDetail.ToAppointmentDetailUpdateDiagnosis();
            var isUpdated = await _appointmentDetailService.UpdateAppointmentDetailAsync(appointmentDetail.AppointmentDetailId, appointmentDetailModel);
            if (isUpdated == null)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "AppointmentDetail not found";
                return NotFound(businessResult);
            }
            businessResult.Status = 200;
            businessResult.Data = isUpdated;
            businessResult.Message = "User updated";
            return Ok(businessResult);
        }

        //Delete
        [HttpDelete("{appointmentDetail}")]
        public async Task<IActionResult> DeleteUserByUsername([FromRoute] int id)
        {
            BusinessResult businessResult = new BusinessResult();
            var isDeleted = await _appointmentDetailService.RemoveAppointmentDetailAsync(id);
            if (isDeleted == null)
            {
                businessResult.Status = 200;
                businessResult.Data = isDeleted;
                businessResult.Message = "AppointmentDetail deleted";
                return Ok(businessResult);
            }
            businessResult.Status = 404;
            businessResult.Data = null;
            businessResult.Message = "AppointmentDetail not found";
            return NotFound(businessResult);
        }
    }
}
