using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_course_selection_system
{
    public class Teacher
    {
        private string teacher_id;
        private string teacher_name;
        private string teacher_sex;
        private string teacher_department;
        private string teacher_position;
        private string teacher_password;
        private string class_name;
        public string Teacher_id { get => teacher_id; set => teacher_id = value; }
        public string Teacher_name { get => teacher_name; set => teacher_name = value; }
        public string Teacher_position { get => teacher_position; set => teacher_position = value; }
        public string Teacher_password { get => teacher_password; set => teacher_password = value; }
        public string Teacher_sex { get => teacher_sex; set => teacher_sex = value; }
        public string Teacher_department { get => teacher_department; set => teacher_department = value; }
        public string Class_name { get => class_name; set => class_name = value; }

        //用来显示登陆的用户信息
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
           " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
           " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;

        public Teacher()
        {

        }
        public Teacher(string id, string password)
        {
            Teacher_id = id;
            Teacher_password = password;
        }
        public Boolean teaLogin()
        {
            bool flag = false;
            if (oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            try
            {
                oracleConnection.Open();
                string sql = "select * from teacher where teacher_id = '" + teacher_id + "' and teacher_password = '" + teacher_password + "'";
                OracleCommand cmd = oracleConnection.CreateCommand();
                cmd.CommandText = sql;    //在这儿写sql语句
                OracleDataReader oracleDataReader = cmd.ExecuteReader();//创建一个OracleDateReader对象

                if (oracleDataReader.Read())
                {
                    flag = true;
                    Teacher_name = oracleDataReader["teacher_name"].ToString();
                    Teacher_sex = oracleDataReader["teacher_sex"].ToString();
                    Teacher_department = oracleDataReader["teacher_department"].ToString();
                    Teacher_position = oracleDataReader["teacher_position"].ToString();
                }
                else
                {
                    flag = false;
                    MessageBox.Show("read false");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("老师连接出错", "提示");
            }
            finally
            {
                oracleConnection.Close();
            }

            return flag;
        }

        public Boolean teaInfoChange()
        {
            bool flag = false;
            int result = 0;
            if (oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);
            }
            try
            {
                oracleConnection.Open();

                OracleCommand oracleCommand = oracleConnection.CreateCommand();
                string cmdStr = @"update teacher set teacher_password='" + teacher_password + "' where teacher_id='" + teacher_id + "'";

                oracleCommand.CommandText = cmdStr;
                result = oracleCommand.ExecuteNonQuery();
                oracleConnection.Close();
                flag = true;
            }
            catch (Exception e)
            {

                MessageBox.Show("修改失败！", "提示");
                flag = false;
            }
            finally
            {
                oracleConnection.Close();
            }

            return flag;
        }


    }
}
