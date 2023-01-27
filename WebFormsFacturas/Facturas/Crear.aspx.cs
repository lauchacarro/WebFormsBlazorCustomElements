using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsFacturas.Facturas
{
    public partial class Crear : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {


            if (!RegularExpressionValidator1.IsValid ||
                !RegularExpressionValidator2.IsValid ||
                CboMetodoPago.SelectedValue == "-1" ||
                CboVendedor.SelectedValue == "-1")
            {
                return;
            }



            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_FacturasInsert", con);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = RandomDigits(10);
                sql_cmnd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = TxtDescripcion.Text;
                sql_cmnd.Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = decimal.Parse(TxtTotal.Text);
                sql_cmnd.Parameters.AddWithValue("@SubTotal", SqlDbType.Decimal).Value = decimal.Parse(TxtSubTotal.Text);
                sql_cmnd.Parameters.AddWithValue("@MetodoPago", SqlDbType.VarChar).Value = CboMetodoPago.SelectedValue;
                sql_cmnd.Parameters.AddWithValue("@Vendedor", SqlDbType.VarChar).Value = CboVendedor.SelectedValue;
                sql_cmnd.Parameters.AddWithValue("@Pagado", SqlDbType.Bit).Value = ChkPagado.Checked;
                sql_cmnd.ExecuteNonQuery();
                con.Close();
            }

            Response.Redirect("/Facturas/Index");
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}