using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using SMS.Utils;
using System.Windows.Forms;

namespace SMS.Bll
{
    internal class User
    {
       public int Uid { get; set; }
       public string Username { get; set; }
       public string Password { get; set; }
       public string Role{ get; set; }

        
    }
}
