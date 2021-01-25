using Oracle.ManagedDataAccess.Client;
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
    /// StudentWin.xaml 的交互逻辑
    /// </summary>
    public partial class StudentWin : Window
    {

        Student student;

        public StudentWin()
        {
            InitializeComponent();

        }

        public StudentWin(Student student)
        {
            InitializeComponent();
            this.student = student;
            test.Content = student.Student_name;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //查看学生信息
            StuInfo stuinfo = new StuInfo(student);
            stuInfo.Content = new Frame()
            {
                Content = stuinfo
            };
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //修改学生信息
            StuInfoChange stuinfo = new StuInfoChange(student);
            stuInfo.Content = new Frame()
            {
                Content = stuinfo
            };
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //查看学生课程表
            StuCourse stuCourse = new StuCourse(student);
            stuInfo.Content = new Frame()
            {
                Content = stuCourse
            };
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            //选课
            StuChoose stuChoose = new StuChoose(student);
            stuInfo.Content = new Frame()
            {
                Content = stuChoose
            };
            stuChoose.Show_Open_Course();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
          
            StuScore stuScore = new StuScore(student);
            stuInfo.Content = new Frame()
            {
                Content = stuScore
            };
            stuScore.Show_Student_Info();
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }
    }
}
