using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_course_selection_system
{
    /// <summary>
    /// StuInfo.xaml 的交互逻辑
    /// </summary>
    public partial class StuInfo : Page
    {
        Student Student;
        public StuInfo()
        {
            InitializeComponent();
        }

        public StuInfo(Student student)
        {
            InitializeComponent();
            this.Student = student;
            name.Text = student.Student_name;
            id.Text = student.Student_id;
            department.Text = student.Student_department;
            class_name.Text = student.Class_name;
            teacher.Text = student.Teacher_name;
            entime.Text = student.Student_entime;
            sex.Text = student.Student_sex;

        }
    }
}
