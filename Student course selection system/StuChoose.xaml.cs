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
    /// StuChoose.xaml 的交互逻辑
    /// </summary>
    public partial class StuChoose : Page
    {
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
            " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
            " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;
        Student student;
        DataTable dt;
        public StuChoose()
        {
            InitializeComponent();

        }

        public StuChoose(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        public void Show_Open_Course(string course_name = "")
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
                string cmdStr = @"select * from choose_course where student_id=' " + student.Student_id + "'" + course_name;
                //MessageBox.Show(cmdStr);
                OracleCommand command = new OracleCommand(cmdStr, oracleConnection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet, "table");
                dt = dataSet.Tables["table"];
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cou_name.Text != "")
            {
                string str = "and course_name= '" + cou_name.Text + "'";
                Show_Open_Course(str);
;            }
            else
            {
                Show_Open_Course();
            }
        }

        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            string sql = @"INSERT INTO sc_choose VALUES ('" + dt.Rows[dataGrid.SelectedIndex][0] + "' ,'"
                + dt.Rows[dataGrid.SelectedIndex][1] + "','" + Convert.ToInt32(dt.Rows[dataGrid.SelectedIndex][1])/10 
                + "','0', '0','0')";
            Get_Course(sql);




        }

        private void BtnAction_Click1(object sender, RoutedEventArgs e)
        {
            string sql = @"delete from sc_choose WHERE student_id= '" + dt.Rows[dataGrid.SelectedIndex][0]
                + "'and new_course_id='" + dt.Rows[dataGrid.SelectedIndex][1] + "'";

            Get_Course(sql);


        }

        public void Get_Course(string sql)
        {

            int result = 0;
            if (oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            try
            {
                oracleConnection.Open();
                OracleCommand oracleCommand = oracleConnection.CreateCommand();
                oracleCommand.CommandText = sql;
                result = oracleCommand.ExecuteNonQuery();
            }
            catch
            {
                //MessageBox.Show("失败!");
            }
            finally
            {
                oracleConnection.Close();
            }
            if (result == 1)
                MessageBox.Show("成功");
            else
                MessageBox.Show("失败");



        }





    }
}
