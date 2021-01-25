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
    /// StuScore.xaml 的交互逻辑
    /// </summary>
    public partial class StuScore : Page
    {
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
           " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
           " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;
            
        Student student;

        public StuScore()
        {
            InitializeComponent();
        }

        public StuScore(Student student)
        {
            InitializeComponent();
            this.student = student;
        }


        public void Show_Student_Info(string course_name = "")
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
                string cmdStr = @"select * from sc_chosen where student_id=' " + student.Student_id + "'"+course_name;
                //MessageBox.Show(cmdStr);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(cou_name.Text !="")
            {
                string course_name = " and course_name = '" + cou_name.Text + "'";
                Show_Student_Info(course_name);
            }
            else
            {
                Show_Student_Info();
            }

        }
    }


}
