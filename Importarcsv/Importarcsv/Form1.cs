using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Importarcsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = ",";

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[1].Split(new[] { SEP }, StringSplitOptions.None);

                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    tblProductos.Rows.Add(celdas);

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Data Source =.\SQLEXPRESS; Initial Catalog = Productos; Integrated Security = True
            SqlConnection conexion = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = Productos; Integrated Security = True");
            conexion.Open();
            SqlBulkCopy exportar = default(SqlBulkCopy);
            exportar = new SqlBulkCopy(conexion);
            exportar.DestinationTableName = "Tbl_Producto";
            //exportar.WriteToServer();
            conexion.Close();
            MessageBox.Show("exportacion exitosa");
        }
    }
}
