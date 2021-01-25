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
    /// TeaCheckTea.xaml 的交互逻辑
    /// </summary>
    public partial class TeaCheckTeaInfo : Page
    {
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
           " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
           " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;


        public TeaCheckTeaInfo()
        {
            InitializeComponent();
            Show_Student_Info();
        }


        public void Show_Student_Info(string tea="")
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
                string cmdStr = @"select * from teacher "+tea;
                //MessageBox.Show(cmdStr);

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
            if(tea_id.Text !="")
            {
                string tea = " where teacher_id='" + tea_id.Text + "'";
                Show_Student_Info(tea);
            }
            else
            {
                Show_Student_Info();
            }
           
        }
    }
}
