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
    /// TeaInfoChange.xaml 的交互逻辑
    /// </summary>
    public partial class TeaInfoChange : Page
    {
        Teacher teacher;
        public TeaInfoChange()
        {
            InitializeComponent();
        }

        public TeaInfoChange(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            id.Text = teacher.Teacher_id;
            department.Text = teacher.Teacher_department;
            name.Text = teacher.Teacher_name;
            sex.Text = teacher.Teacher_sex;
            position.Text = teacher.Teacher_position;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newPassword.Password == newPassword1.Password)
            {
                teacher.Teacher_password = newPassword.Password;
                if (teacher.teaInfoChange())
                {
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
