﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AbetApi.EFModels;
using AbetApi.Authentication;


namespace AbetApi.Controllers
{
    // This controller is used to manage roles
    // Role names are case sensitive
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        // This function returns all users with the provided role name
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpGet("GetUsersByRole")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            try
            {
                return Ok(await Role.GetUsersByRole(roleName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetUsersByRole

        // This function returns a list of all users with the Admin/Instructor/Coordinator roles
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpGet("GetFaculty")]
        public async Task<IActionResult> GetFaculty()
        {
            try
            {
                AbetApi.Models.Faculty temp = new AbetApi.Models.Faculty
                {
                    Admins = await Role.GetUsersByRole("Admin"),
                    Instructors = await Role.GetUsersByRole("Instructor"),
                    Coordinators = await Role.GetUsersByRole("Coordinator"),
                    Assistants = await Role.GetUsersByRole("Assistant")
                };

                return Ok(temp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetFaculty

        // This function creates a role with a given role name
        // Role name can include any characters. Any function calls for a role will be case sensitive.
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(Role roleName)
        {
            try
            {
                await Role.CreateRole(roleName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // CreateRole

        // This function deletes a role by the given name
        // Anybody that calls this endpoint should include a verification before actually calling this endpoint. Deletions are final.
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            try
            {
                await Role.DeleteRole(roleName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }// DeleteRole

        // This function adds the provided role to the given user (via EUID)
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(string EUID, string roleName)
        {
            try
            {
                await Role.AddRoleToUser(EUID, roleName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // AddRoleToUser

        // This function removes the selected role from the selected user (via EUID)
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpDelete("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody]AxiosRequest.RemoveRoleFromUser request)
        {
            try
            {
                await Role.RemoveRoleFromUser(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // RemoveRoleFromUser
    } // RoleController
}
