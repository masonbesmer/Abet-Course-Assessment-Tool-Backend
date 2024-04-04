using Microsoft.AspNetCore.Mvc;
using AbetApi.EFModels;
using AbetApi.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace AbetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentOutcomesCompletedController : ControllerBase
    {
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetStudentOutcomesCompleted")]
        public async Task<IActionResult> GetStudentOutcomesCompleted(string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                return Ok(AbetApi.Models.StudentOutcomesCompleted.ConvertToModelStudentOutcomesCompleted(term, year, department, courseNumber, StudentOutcomesCompleted.GetStudentOutcomesCompleted(term, year, department, courseNumber, sectionNumber).Result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetStudentOutcomesCompleted

        [Authorize(Roles = RoleTypes.Admin)]
        [HttpGet("GetCourseStudentOutcomesCompleted")]
        public async Task<IActionResult> GetCourseStudentOutcomesCompleted(string term, int year, string department, string courseNumber)
        {
            try
            {
                return Ok(AbetApi.Models.StudentOutcomesCompleted.ConvertToModelStudentOutcomesCompleted(term, year, department, courseNumber, StudentOutcomesCompleted.GetCourseStudentOutcomesCompleted(term, year, department, courseNumber).Result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetCourseStudentOutcomesCompleted

        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpPost("SetStudentOutcomesCompleted")]
        public async Task<IActionResult> SetStudentOutcomesCompleted(string term, int year, string department, string courseNumber, string sectionNumber, List<Dictionary<string, string>> studentOutcomesCompletedDictionary)
        {
            try
            {
                //await Grade.SetGrades(term, year, department, courseNumber, sectionNumber, AbetApi.Models.Grade.ConvertToEFModelGrade(gradesDictionary));

                //Need to turn a dictionary back in to a list of singular StudentOutcomesCompleted objects
                //There will be one for each major mentioned in that dictionary

                List<StudentOutcomesCompleted> tempList = AbetApi.Models.StudentOutcomesCompleted.ConvertToEFModelStudentOutcomesCompleted(term, year, department, courseNumber, sectionNumber, studentOutcomesCompletedDictionary);

                foreach(var item in tempList)
                {
                    await StudentOutcomesCompleted.SetStudentOutcomesCompleted(item.Term, item.Year, item.ClassDepartment, item.CourseNumber, item.SectionName, item.CourseOutcomeName, item.MajorName, item.StudentsCompleted).ConfigureAwait(false);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // SetStudentOutcomesCompleted
    }
}
