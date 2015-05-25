using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Aerolinea_AccesoDatos
{
  public class BDComun
    {

      public static SqlConnection cn = new SqlConnection(@"Data Source=CEALER-LAPTOP;Initial Catalog=aerolinea;Integrated Security=True");
                
        public static void Conectar() {cn.Open();}
        public static void DesConectar() { cn.Close(); }
    }
}
