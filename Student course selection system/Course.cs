using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_course_selection_system
{
    public class Course
    {
        //课程类，课程详细信息

        private string student_id;
        private string new_course_id;
        private string course_name;
        private string course_type;

        public string Student_id { get => student_id; set => student_id = value; }
        public string New_course_id { get => new_course_id; set => new_course_id = value; }
        public string Course_name { get => course_name; set => course_name = value; }
        public string Course_type { get => course_type; set => course_type = value; }
    }
}
