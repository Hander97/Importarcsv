using AccesoDatosClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class Logica
    {
        private static DcProductosDataContext dc = new DcProductosDataContext();
        public static List<Tbl_Producto> getAllaUsers()
        {
            try
            {
                var lista = dc.Tbl_Producto.Where(data => data.pro_status == 'A');

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Producto " + ex.Message);
            }
        }

    }
}
