using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// TeacherCourse.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherCourse : Page
    {
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
          " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
          " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;
        Teacher teacher;
        string class_name;
        string course_name;

        public TeacherCourse()
        {
            InitializeComponent();
        }
        public TeacherCourse(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            class_name = null;
            course_name = null;


            //

            DataSet dataSet = new DataSet();
            if (oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            try
            {
                dataSet.Clear();
                oracleConnection.Open();

                string cmdStr = @"select distinct course_name from open, course where open.teacher_id = '"
                   + teacher.Teacher_id + "' and open.course_id=course.course_id";

                OracleCommand command = new OracleCommand(cmdStr, oracleConnection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet, "table");
                DataTable dt = dataSet.Tables["table"];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    RadioButton radioButton = new RadioButton()
                    {
                        Content = row[0],
                        Name = "course"
                    };
                    radioButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(rect_PreviewMouseLeftButtonDown);
                    Grid.SetRow(radioButton, i);
                    course.Children.Add(radioButton);
                    i++;                  
                }

                cmdStr = @"select distinct class_name from open,class where open.teacher_id = '"
                   + teacher.Teacher_id + "' and class.class_id=open.class_id";

                command = new OracleCommand(cmdStr, oracleConnection);
                adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet, "table1");
                dt = dataSet.Tables["table1"];
                i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    //班名
                    //MessageBox.Show(row[0].ToString());
                    RadioButton radioButton = new RadioButton()
                    {
                        Content = row[0],
                        Name = "class" 
                    };
                    radioButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(rect_PreviewMouseLeftButtonDown);
                    Grid.SetRow(radioButton, i);
                    classes.Children.Add(radioButton);
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("something error!");
            }
            finally
            {
                oracleConnection.Close();
            }


        }

        void rect_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if(radioButton.Name == "course")
            {
                course_name = radioButton.Content.ToString();
            }
            else if (radioButton.Name == "class")
            {
                class_name = radioButton.Content.ToString();
            }
            if(class_name!=null&&course_name!=null)
            {
                Show_Teacher_Course(class_name);

            }

        }


        public void Show_Teacher_Course(string className)
        {
            DataSet dataSet = new DataSet();
            if (oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            try
            {
                dataSet.Clear();
                oracleConnection.Open();
                string cmdStr = @"select student.student_id, sc_choose.new_course_id,student_name, student_grade "
                    +" from sc_choose, open,student,class where open.new_course_id=sc_choose.new_course_id "
                    +"and open.teacher_id='"+teacher.Teacher_id+"'and student.student_id=sc_choose.student_id "+
                    "and student.class_id=class.class_id and class_name='"+ className + "' and open.class_id=class.class_id";

                OracleCommand command = new OracleCommand(cmdStr, oracleConnection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet);
                dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("something error!");
            }
            finally
            {
                oracleConnection.Close();
            }
        }


    }
}
