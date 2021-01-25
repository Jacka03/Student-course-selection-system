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
    /// StuCourse.xaml 的交互逻辑
    /// </summary>
    public partial class StuCourse : Page
    {

        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
            " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
             " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;
        Student student;

        public StuCourse()
        {
            InitializeComponent();

        }

        public StuCourse(Student student)
        {
            InitializeComponent();
            this.student = student;

           
            Show_Student_Course();
        }

        public void Show_Student_Course()
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
                string cmdStr = @"select * from chosen where student_id=' " + student.Student_id + "'";
                //MessageBox.Show(cmdStr);
                OracleCommand command = new OracleCommand(cmdStr, oracleConnection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet, "table");
                DataTable dt = dataSet.Tables["table"];


                
                foreach (DataRow row in dt.Rows)
                {
                    string str = "\n " + row[2] + "\n  " + row[10] + "\n  " + row[11] + "\n  " + row[12];
                    int x = 0, y = 0;

                    Get_TextBlock_Index(row[11].ToString(),ref x,ref y);
                    TextBlock textBlock = new TextBlock();
                    myGrid.Children.Add(textBlock);
                    textBlock.SetValue(Grid.RowProperty, y);
                    textBlock.SetValue(Grid.ColumnProperty, x);
                    //textBlock.TextAlignment = TextAlignment.Center;
                    textBlock.Text = str;

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


        public void Get_TextBlock_Index(string str, ref int row, ref int col)
        {
            string[] strArr = str.Split(' ');
            switch (strArr[0])
            {
                case "星期一": row = 1; break;
                case "星期二": row = 2; break;
                case "星期三": row = 3; break;
                case "星期四": row = 4; break;
                case "星期五": row = 5; break;
                case "星期六": row = 6; break;
                case "星期日": row = 7; break;
                default: MessageBox.Show("error"); break;
            }
            switch (strArr[1])
            {
                case "1-2节": col = 1; break;
                case "3-4节": col = 2; break;
                case "5-6节": col = 3; break;
                case "7-8节": 
                case "7-9节": col = 4; break;
                default: MessageBox.Show("error"); break;
            }
        }

    }
}
