using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMS.Bll;
using SMS.Utils;

namespace SMS.Dao
{
    internal class UserDao
    {
        private SqlConnection cn;
        public UserDao()
        {
            cn = DbConnection.MyConnection();
        }

        public DataTable CheckUser(User u)
        {
            string sql = "SELECT * FROM USERS WHERE Username=@Username and Password=@Password";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal DataTable CheckUser(UserControl u)
        {
            throw new NotImplementedException();
        }
    }

    }
