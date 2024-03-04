using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AbetApi.EFModels;
using AbetApi.Authentication;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AbetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        ////////////////////////////////////////////////////////////////////////////////////
        // AddSection //
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // Section section:      Section object that contains: InstructorEUID string, 
        //                       sectionCompleted boolean, sectionNumber int,
        //                       numberOfStudents int
        // description:          This function adds a section/section info to a specific
        //                       course/courseID. Specific courses (and all their sections)
        //                       all share the same CourseID, though the InstructorEUID
        //                       can be different. A SectionID number is auto-generated
        //                       in sequential order in relation to the other sections
        ////////////////////////////////////////////////////////////////////////////////////
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpPost("AddSection")]
        public async Task<IActionResult> AddSection(string term, int year, string department, string courseNumber, Section section)
        {
            try
            {
                await Section.AddSection(term, year, department, courseNumber, section);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        } // AddSection

        ////////////////////////////////////////////////////////////////////////////////////
        // GetSection //
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // description:          This function gets a JSON object that contains sectonID int,
        //                       instructorEUID string, isSectioncompleted boolean, 
        //                       sectionNumber string,numberOfStudents int
        ////////////////////////////////////////////////////////////////////////////////////
        //[Authorize(Roles = RoleTypes.Instructor)] // Fall 2022 changed this to instructor. Front end calls
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetSection")]
        public async Task<IActionResult> GetSection(string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                return Ok(await Section.GetSection(term, year, department, courseNumber, sectionNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetSection

        ////////////////////////////////////////////////////////////////////////////////////
        // GetSectionAssistant //
        // string assistantEUID: The EUID of the assistant to search for
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // description:          This function gets the assistant EUID from a section as
        //                       a string IFF the assistant is assigned to the section.
        ////////////////////////////////////////////////////////////////////////////////////
        //[Authorize(Roles = RoleTypes.Instructor)] // Fall 2022 changed this to instructor. Front end calls
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetSectionAssistant")]
        public async Task<IActionResult> GetSectionAssistant(string assistantEUID, string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                return Ok(await Section.GetSectionAssistant(assistantEUID, term, year, department, courseNumber, sectionNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetSectionAssistant

        ////////////////////////////////////////////////////////////////////////////////////
        // EditSection //
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // Section NewValue:     NewValue object that contains sectionID int,
        //                       instructorEUID string, isSectionCompleted boolean,
        //                       sectionNumber string, numberOfStudents int, isFormSubmitted boolean
        // description:          This function edits the prexisting sections
        ////////////////////////////////////////////////////////////////////////////////////
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpPatch("EditSection")]
        public async Task<IActionResult> EditSection(string term, int year, string department, string courseNumber, string sectionNumber, Section NewValue)
        {
            try
            {
                await Section.EditSection(term, year, department, courseNumber, sectionNumber, NewValue);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // EditSection

        ////////////////////////////////////////////////////////////////////////////////////
        // EditComments //
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // string newInstructorComment
        // string newCoordinatorComment
        // description:          This function edits comments
        ////////////////////////////////////////////////////////////////////////////////////
        [HttpPatch("EditComments")]
        public async Task<IActionResult> EditComments(string term, int year, string department, string courseNumber, string sectionNumber, string newInstructorComment, string newCoordinatorComment)
        {
            try
            {
                await Section.EditComments(term, year, department, courseNumber, sectionNumber, newInstructorComment, newCoordinatorComment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // EditSection

        ////////////////////////////////////////////////////////////////////////////////////
        // DeleteSection //
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // description:          This function deletes the prexisting sections
        ////////////////////////////////////////////////////////////////////////////////////
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpDelete("DeleteSection")]
        public async Task<IActionResult> DeleteSection(string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                await Section.DeleteSection(term, year, department, courseNumber, sectionNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // DeleteSection

        ////////////////////////////////////////////////////////////////////////////////////
        // AddAssistantToSection //
        // string assistantEUID: The EUID of the assistant to be added to the section, such as abc1234
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // description:          This function adds a pre-existing assistant to a section
        ////////////////////////////////////////////////////////////////////////////////////
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpDelete("AddAssistantToSection")]
        public async Task<IActionResult> AddAssistantToSection(string assistantEUID, string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                await Section.AddAssistantToSection(assistantEUID, term, year, department, courseNumber, sectionNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // AddAssistantToSection

        ////////////////////////////////////////////////////////////////////////////////////
        // RemoveAssistantFromSection //
        // string assistantEUID: The EUID of the assistant to be removed from the section, such as abc1234
        // string term:          Semester term, such as Fall or Spring
        // int year:             School year, such as 2022 or 2023
        // string department:    Major department, such as CSCE or MEEN
        // string courseNumber:  Course identifier, such as 3600 for Systems Programming
        // string sectionNumber: Course section, such as 001 or 002
        // description:          This function removes a pre-existing assistant from a section
        ////////////////////////////////////////////////////////////////////////////////////
        [Authorize(Roles = RoleTypes.Admin)]
        [HttpDelete("RemoveAssistantFromSection")]
        public async Task<IActionResult> RemoveAssistantFromSection(string assistantEUID, string term, int year, string department, string courseNumber, string sectionNumber)
        {
            try
            {
                await Section.RemoveAssistantFromSection(assistantEUID, term, year, department, courseNumber, sectionNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // RemoveAssistantFromSection

        [Authorize(Roles = RoleTypes.Instructor)]
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetSectionsByInstructor")]
        public async Task<IActionResult> GetSectionsByInstructor(string term, int year, string instructorEUID)
        {
            try
            {
                return Ok(await Section.GetSectionsByInstructor(term, year, instructorEUID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetSectionsByInstructor

        //[Authorize(Roles = RoleTypes.Instructor)]
        [Authorize(Roles = RoleTypes.Assistant)]
        [HttpGet("GetSectionsByAssistant")]
        public async Task<IActionResult> GetSectionsByAssistant(string term, int year, string assistantEUID)
        {
            try
            {
                return Ok(await Section.GetSectionsByAssistant(term, year, assistantEUID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } // GetSectionsByAssistant
    } // SectionController
}
