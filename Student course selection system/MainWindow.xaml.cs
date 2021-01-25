using Panuon.UI.Silver;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            id.Text = "110001";// "100983";// "110009";
            password.Password = "123456";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student(id.Text, password.Password);
            if(student.stuLogin())
            {
                StudentWin stuWin = new StudentWin(student);
                Application.Current.MainWindow = stuWin;
                this.Close();
                stuWin.Show();

            }
            else
            {
                MessageBox.Show("账号或者密码错误","提示");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher(id.Text, password.Password);
            if(teacher.teaLogin())
            {
                TeacherWin teacherWin = new TeacherWin(teacher);
                Application.Current.MainWindow = teacherWin;
                this.Close();
                teacherWin.Show();

            }
            else
            {
                MessageBox.Show("账号或者密码错误", "提示");
            }
        }
    }
}
