﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbetApi.Data;
using AbetApi.EFModels;
using AbetApi.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AbetApi.Controllers
//As its named, it controlls the courses. Add Course, Delete Course, Edit Course
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse(string term, int year, Course course)
        {
            try
            {
                await Course.AddCourse(term, year, course);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // AddCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetCourse")]
        public async Task<IActionResult> GetCourse(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(await Course.GetCourse(term, year, department, courseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // GetCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpPatch("EditCourse")]
        public async Task<IActionResult> EditCourse(string term, int year, string department, string courseNumber, Course NewValue)
        {
            try
            {
                await Course.EditCourse(term, year, department, courseNumber, NewValue);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // EditCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(string term, int year, string department, string courseNumber)
        {
            try
            {
                await Course.DeleteCourse(term, year, department, courseNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // DeleteCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetSectionsByCourse")]
        public async Task<IActionResult> GetSectionsByCourse(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(await Course.GetSectionsByCourse(term, year, department, courseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // GetSections

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetNumberOfSectionsInCourse")]
        public async Task<IActionResult> GetNumberOfSectionsInCourse(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(await Course.GetNumberOfSectionsInCourse(term, year, department, courseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // GetNumberOfSectionsInCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetMajorsThatRequireCourse")]
        public async Task<IActionResult> getMajorsThatRequireCourse(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(await Course.getMajorsThatRequireCourse(term, year, department, courseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // getMajorsThatRequireCourse

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetCoursesByDepartment")]
        public async Task<IActionResult> GetCoursesByDepartment(string term, int year, string department)
        {
            try
            {
                return Ok(await Course.GetCoursesByDepartment(term, year, department));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (ex.Message == "The specified semester has no courses.")
                {
                    return Ok(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        } // GetCoursesByDepartment

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetCourseNamesByDepartment")]
        public async Task<IActionResult> GetCourseNamesByDepartment(string term, int year, string department)
        {
            try
            {
                return Ok(await Course.GetCourseNamesByDepartment(term, year, department));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments(string term, int year)
        {
            try
            {
                return Ok(await Course.GetDepartments(term, year));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        } // GetDepartments

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetMajorOutcomesSatisfied")]
        public async Task<IActionResult> GetMajorOutcomesSatisfied(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(await Course.GetMajorOutcomesSatisfied(term, year, department, courseNumber));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }//GetMajorOutcomesSatisfied

        [Authorize(Roles = RoleTypes.Coordinator)]
        [HttpGet("GetCoursesByCoordinator")]
        public async Task<IActionResult> GetCoursesByCoordinator(string term, int year, string coordinatorEUID)
        {
            try
            {
                return Ok(await Section.GetSectionsByCoordinator(term, year, coordinatorEUID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    } // CourseController
}
