﻿using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO.Result;
using ServiceContracts.DTO.UserDTO;

namespace PetHealthCareSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public UserController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        //Create
        [HttpPost]
        public IActionResult AddUser(UserAddRequest? userAddRequest)
        {
            if(userAddRequest == null)
            {
                return BadRequest("UserRequest is null");
            }

            _userService.AddUser(userAddRequest);

            return Ok("Created successfully");
        }

        //Read
        [HttpGet]
        public ActionResult<BusinessResult> GetUsers()
        {
            BusinessResult businessResult = new BusinessResult();
            businessResult.Data = _userService.GetUsers(); ;
            businessResult.Message = "Successful";
            businessResult.Status = 200;
            return businessResult;
        }

        [HttpGet("id/{id}")]
        public ActionResult<BusinessResult> GetUserById(int id)
        {
            BusinessResult businessResult = new BusinessResult();
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "No User found";
                return businessResult;
            }
            businessResult.Status = 200;
            businessResult.Data = user;
            businessResult.Message = "User found";
            return businessResult;
        }

        [HttpGet("username/{username}")]
        public ActionResult<BusinessResult> GetUserByUsername(string username)
        {
            BusinessResult businessResult = new BusinessResult();
            var user = _userService.GetUserByUsername(username);
            if(user == null)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "No User found";
                return businessResult;
            }
            businessResult.Status = 200;
            businessResult.Data = user;
            businessResult.Message = "User found";
            return businessResult;
        }

        //Update
        [HttpPut("{id}")]
        public ActionResult<BusinessResult> UpdateUserById(int id, UserUpdateRequest? userUpdateRequest)
        {
            BusinessResult businessResult = new BusinessResult();
            if(userUpdateRequest == null)
            {
                businessResult.Status = 400;
                businessResult.Data = null;
                businessResult.Message = "Request is null";
                return businessResult;
            }
            if(id != userUpdateRequest.UserId)
            {
                businessResult.Status = 400;
                businessResult.Data = null;
                businessResult.Message = "Mismatched id";
                return businessResult;
            }
            var isUpdated = _userService.UpdateUser(userUpdateRequest);
            if(!isUpdated)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "User not found";
                return businessResult;
            }
            businessResult.Status = 200;
            businessResult.Data = userUpdateRequest.ToUser();
            businessResult.Message = "User updated";
            return businessResult;
        }

        //Delete
        [HttpDelete("{username}")]
        public ActionResult<BusinessResult> DeleteUserByUsername(string username)
        {
            BusinessResult businessResult = new BusinessResult();
            var userData = _userService.GetUserByUsername(username);
            var isDeleted = _userService.RemoveUser(username);
            if(!isDeleted)
            {
                businessResult.Status = 404;
                businessResult.Data = null;
                businessResult.Message = "User not found";
                return businessResult;
            }
            businessResult.Status = 200;
            businessResult.Data = userData;
            businessResult.Message = "User deleted";
            return businessResult;
        }
    }
}
