namespace AbetApi.Models
{
    //This class is used to package specific data to be sent to the front end, for relevant course info
    public class SectionInfo
    {
        public string CourseFriendlyName { get; set; }
        public string CourseNumber { get; set; }
        public string SectionNumber { get; set; }
        public string InstructorEUID { get; set; }
        public string CoordinatorEUID { get; set; }

        public bool isFormSubmitted { get; set; }

        public SectionInfo(string courseFriendlyName, string courseNumber, string sectionNumber, string instructorEUID, string coordinatorEUID, bool isFormSubmitted)
        {
            this.CourseFriendlyName = courseFriendlyName;
            this.CourseNumber = courseNumber;
            this.SectionNumber = sectionNumber;
            this.InstructorEUID = instructorEUID;
            this.CoordinatorEUID = coordinatorEUID;
            this.isFormSubmitted = isFormSubmitted;
        }
    }
}
