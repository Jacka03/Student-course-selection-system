using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows;



namespace Student_course_selection_system
{
    public class Student
    {
        private string student_id;       //学号
        private string student_name;     //名字
        private string student_sex;      //性别
        private string student_password; //密码
        private string student_entime;
        private string student_department;
        private string class_name;
        private string teacher_name;

        //用来显示登陆的用户信息
        private static string connectionString = "Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS" +
           " = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))" +
           " (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));User ID = C##exp; Password=123456;";

        OracleConnection oracleConnection;

        public string Student_id { get => student_id; set => student_id = value; }
        public string Student_name { get => student_name; set => student_name = value; }
        public string Student_sex { get => student_sex; set => student_sex = value; }
        public string Student_password { get => student_password; set => student_password = value; }
        public string Student_entime { get => student_entime; set => student_entime = value; }
        public string Student_department { get => student_department; set => student_department = value; }
        public string Class_name { get => class_name; set => class_name = value; }
        public string Teacher_name { get => teacher_name; set => teacher_name = value; }

        public Student()
        {

        }

        public Student(string id)
        {
            Student_id = id;
        }

        public Student(string id, string password)
        {
            student_id = id;
            Student_password = password;
        }

        public Boolean stuLogin()
        {
            bool flag = false;
            if(oracleConnection == null)
            {
                oracleConnection = new OracleConnection(connectionString);

            }
            try
            {
                oracleConnection.Open();
                //string sql = "select student_name, class_id, student_sex, student_entime, student_department" +
                //    " from student where student_id = '"+student_id+"' and student_password='"+Student_password+"'"; //末尾不能有分号

                string sql = "select * from stuInfo where student_id = '"+student_id+"' and student_password = '"+Student_password+"'";
                //MessageBox.Show(sql);
                OracleCommand cmd = oracleConnection.CreateCommand();
                cmd.CommandText = sql;    //在这儿写sql语句
                OracleDataReader oracleDataReader = cmd.ExecuteReader();//创建一个OracleDateReader对象

                if(oracleDataReader.Read())
                {
                    flag = true;
                    Student_name = oracleDataReader["student_name"].ToString();
                    Student_sex = oracleDataReader["student_sex"].ToString();
                    Student_entime = oracleDataReader["student_entime"].ToString();
                    Student_department = oracleDataReader["student_department"].ToString();
                    Class_name = oracleDataReader["class_name"].ToString();
                    Teacher_name = oracleDataReader["teacher_name"].ToString();
                   
                }
                else
                {
                    flag = false;
                    //2MessageBox.Show("read false");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("学生连接出错", "提示");
            }
            finally
            {
                oracleConnection.Close();
            }

            return flag;
        }


        public Boolean stuInfoChange()
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
                string cmdStr = @"update student set student_password='" + student_password + "' where student_id='" + student_id + "'";

                oracleCommand.CommandText = cmdStr;
                result = oracleCommand.ExecuteNonQuery();
                oracleConnection.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show("修改失败！", "提示");
            }
            finally
            {
                oracleConnection.Close();
            }

            return flag;
        }

    }
}
