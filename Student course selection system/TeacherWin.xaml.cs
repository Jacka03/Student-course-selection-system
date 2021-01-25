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
using System.Windows.Shapes;

namespace Student_course_selection_system
{
    /// <summary>
    /// teacherWin.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherWin : Window
    {
        Teacher teacher;
        public TeacherWin()
        {
            InitializeComponent();
        }

        public TeacherWin(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            test.Content = teacher.Teacher_name + "老师";
            if(teacher.Teacher_position=="主任")
            {


            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //查看老师信息
            TeaInfo teaInfo = new TeaInfo(teacher);
            stuInfo.Content = new Frame()
            {
                Content = teaInfo
            };
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            TeaInfoChange teaInfoChange = new TeaInfoChange(teacher);
            stuInfo.Content = new Frame()
            {
                Content = teaInfoChange
            };
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //查看老师课表
            TeaCourse teaCourse = new TeaCourse(teacher);
            stuInfo.Content = new Frame()
            {
                Content = teaCourse
            };
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            //课程
            TeacherCourse teacherCourse = new TeacherCourse(teacher);
            stuInfo.Content = new Frame()
            {
                Content = teacherCourse
            };
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            if(teacher.Teacher_position == "主任")
            {
                //学生信息
                TeaCheckStuInfo teaCheckStuInfo = new TeaCheckStuInfo();
                stuInfo.Content = new Frame()
                {
                    Content = teaCheckStuInfo
                };


            }
            
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            //查看老师信息
            if(teacher.Teacher_position=="主任")
            {
                TeaCheckTeaInfo teaCheckTeaInfo = new TeaCheckTeaInfo();

                stuInfo.Content = new Frame()
                {
                    Content = teaCheckTeaInfo
                };
            }
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            //查看课程信息
            if(teacher.Teacher_position=="主任")
            {
                TeaCheckStuCourInfo teaCheckStuCourInfo = new TeaCheckStuCourInfo();
                stuInfo.Content = new Frame()
                {
                    Content = teaCheckStuCourInfo
                };
            }

        }

        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }
    }
}
