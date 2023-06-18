using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Bll;
using System.Data.SqlClient;
using SMS.Utils;
using System.Data;

namespace SMS.Dao
{
    internal class StudentDao
    {
        private SqlConnection cn;
        public StudentDao()
        {
            cn = DbConnection.MyConnection();
        }

        public void SaveStudent(Student s)
        {
            string sql = "INSERT INTO Student(Name, Address, Course, Fees) VALUES (@Name,@Address,@Course,@Fees)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Course", s.Course);
            cmd.Parameters.AddWithValue("@Fees", s.Fees);
            cmd.ExecuteNonQuery();

        }

        public void UpdateStudent(Student s)
        {
            string sql = "UPDATE Student set Name=@Name,Address=@Address, Course=@Course,Fees=@Fees WHERE SID=@SID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@SID", s.SID);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Course", s.Course);
            cmd.Parameters.AddWithValue("@Fees", s.Fees);
            cmd.ExecuteNonQuery();

        }

        public void DeleteStudent(int sid)
        {
            string sql = "DELETE FROM Student WHERE SID=@SID";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@SID", sid);
            cmd.ExecuteNonQuery();

        }

        public DataTable GetAllStudents()
        {
            string sql = "SELECT * FROM STUDENT";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}