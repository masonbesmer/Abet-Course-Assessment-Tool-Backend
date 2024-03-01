using Microsoft.AspNetCore.Mvc;
using AbetApi.EFModels;
using AbetApi.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace AbetApi.Controllers
{
    //Set & Get grades
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetGrades")]
        public async Task<IActionResult> GetGrades(string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                //Get the specified grades
                var grades = await Grade.GetGradesBySection(term, year, department, courseNumber, sectionNumber);

                //Converts the data to a format for the front end and returns the data
                return Ok(AbetApi.Models.Grade.ConvertToModelGrade(grades));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetGrades

        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpPost("SetGrades")]
        public async Task<IActionResult> SetGrades(string term, int year, string department, string courseNumber, string sectionNumber, Dictionary<string, AbetApi.Models.Grade> gradesDictionary)
        {
            //List<Grade> grades
            try
            {
                await Grade.SetGrades(term, year, department, courseNumber, sectionNumber, AbetApi.Models.Grade.ConvertToEFModelGrade(gradesDictionary));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetGrades

        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetGradesByMajor")]
        public async Task<IActionResult> GetGradesByMajor(string term, int year, string department, string courseNumber, string sectionNumber, string major)
        {
            try
            {
                // Get the specified grades
                var grades = await Grade.GetGradesByMajor(term, year, department, courseNumber, sectionNumber, major);

                // Converts the data to a format for the front end and returns the data
                return Ok(AbetApi.Models.Grade.ConvertToModelGrade(grades));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
