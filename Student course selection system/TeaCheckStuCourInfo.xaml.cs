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
    /// TeaCheckStuCourInfo.xaml 的交互逻辑
    /// </summary>
    public partial class TeaCheckStuCourInfo : Page
    {

        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
    " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
    " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;

        public TeaCheckStuCourInfo()
        {
            InitializeComponent();
            Show_Student_Info();

        }

        public void Show_Student_Info(string st_id="")
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
                string cmdStr = @"select * from chosen " + st_id;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sut_id.Text != "")
            {
                string str = " where student_id='" + sut_id.Text + "'";
                Show_Student_Info(str);
            }
            else
            {
                Show_Student_Info();
            }
            

        }
    }
}
