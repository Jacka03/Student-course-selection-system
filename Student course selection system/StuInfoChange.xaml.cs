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
    /// StuInfoChange.xaml 的交互逻辑
    /// </summary>
    public partial class StuInfoChange : Page
    {
        Student student;
        public StuInfoChange()
        {
            InitializeComponent();
        }

        public StuInfoChange(Student student)
        {
            this.student = student;
            InitializeComponent();

            name.Text = student.Student_name;
            id.Text = student.Student_id;
            department.Text = student.Student_department;
            class_name.Text = student.Class_name;
            teacher.Text = student.Teacher_name;
            entime.Text = student.Student_entime;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(newPassword.Password == newPassword1.Password)
            {
                student.Student_password = newPassword.Password;
                if (student.stuInfoChange())
                {
                    MessageBox.Show(student.Student_password);
                    MessageBox.Show("修改成功");
                }                
            }
            else
            {
                MessageBox.Show("两次输入的密码不一致");
            }
        }
    }
}
