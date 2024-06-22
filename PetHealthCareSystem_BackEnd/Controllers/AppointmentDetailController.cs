﻿using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHealthCareSystem_BackEnd.Validations;
using ServiceContracts;
using ServiceContracts.DTO.AppointmentDetailDTO;
using ServiceContracts.DTO.Result;
using ServiceContracts.DTO.ServiceDTO;
using ServiceContracts.DTO.UserDTO;
using ServiceContracts.Mappers;
using Services;

namespace PetHealthCareSystem_BackEnd.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentDetailService _appointmentDetailService;
        private readonly IRecordService _recordService;

        public AppointmentDetailController(IAppointmentService appointmentService, IAppointmentDetailService appointmentDetailService, IRecordService recordService)
        {
            _appointmentService = appointmentService;
            _appointmentDetailService = appointmentDetailService;
            _recordService = recordService;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> AddAppointmentDetail([FromBody] AppointmentDetailAddRequest? appointmentDetail)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(",", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }
            AppointmentDetail appointmentDetailModel = appointmentDetail.ToAppointmentDetailFromAdd();
            //appointmentDetailModel.RecordId = _appointmentService.GetAppointmentByIdAsync((int)appointmentDetailModel.AppointmentId).Result.Pet.RecordID;
            if (appointmentDetailModel == null)
            {
                return NotFound("Please input data");
            }

            var result = await _appointmentDetailService.AddAppointmentDetailAsync(appointmentDetailModel);
            return Ok(result.ToAppointDetailDto());



        }

        //Read
        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetails()
        {
            var list = await _appointmentDetailService.GetAppointmentDetailsAsync();
            var appoint = list.Select(x => x.ToAppointDetailDto());
            return Ok(appoint);

        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetAppointmentDetailById(int id)
        {
            var appointmentDetail = await _appointmentDetailService.GetAppointmentDetailByIdAsync(id);
            if (appointmentDetail == null)
            {
                return NotFound();
            }
            return Ok(appointmentDetail.ToAppointDetailDto());
        }


        //Update
        [HttpPut("update-diagnose/{id}")]
        public async Task<IActionResult> UpdateDiagnosis([FromRoute] int id, [FromBody] AppointmentDetailUpdateDiagnosis? appointmentDetail)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(",", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }

            var appointmentDetailModel = await _appointmentDetailService.GetAppointmentDetailByIdAsync(id);
            if (appointmentDetailModel == null)
            {
                return NotFound("AppointmentDetail not found");
            }
            var UpdateDiagnosis = appointmentDetail.ToAppointmentDetailUpdateDiagnosis();
            UpdateDiagnosis.AppointmentDetailId = id;
            if (await _appointmentService.GetAppointmentByIdAsync((int)appointmentDetailModel.AppointmentId) == null
                || await _recordService.GetRecordByIdAsync((int)appointmentDetail.RecordId) == null)
            {
                return NotFound("Appointment or Record not found");
            }
            var isUpdated = await _appointmentDetailService.UpdateAppointmentDetailAsync(UpdateDiagnosis);
            if (isUpdated == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(isUpdated.ToAppointDetailDto());
        }

        //Delete
        [HttpDelete("{appointmentDetailId}")]
        public async Task<IActionResult> DeleteAppointmentDetailById([FromRoute] int appointmentDetailId)
        {
            var existingappoint = await _appointmentDetailService.GetAppointmentDetailByIdAsync(appointmentDetailId);
            if (existingappoint == null)
            {
                return NotFound("AppointmentDetail not found");
            }
            var isDeleted = await _appointmentDetailService.RemoveAppointmentDetailAsync(appointmentDetailId);
            if (!isDeleted)
            {
                return BadRequest("Delete fail");
            }
            return Ok(existingappoint.ToAppointDetailDto());
        }
    }
}
