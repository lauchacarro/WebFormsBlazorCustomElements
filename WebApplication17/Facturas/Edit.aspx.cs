using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection.Emit;

namespace WebFormsFacturas.Facturas
{
    public partial class Edit : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con;

        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            string facturaId = Request.QueryString["Id"];

            if (int.TryParse(facturaId, out int _id))
            {
                Id = _id;
            }


            if (!Page.IsPostBack)
            {

                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand sql_cmnd = new SqlCommand("usp_FacturasSelect", con);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = facturaId;

                    var dr = sql_cmnd.ExecuteReader();
                    while (dr.Read())
                    {

                        TxtCodigo.Text = dr["Codigo"].ToString();
                        TxtDescripcion.Text = dr["Descripcion"].ToString();
                        TxtTotal.Text = dr["Total"].ToString();
                        TxtSubTotal.Text = dr["SubTotal"].ToString();
                        CboMetodoPago.SelectedValue = dr["MetodoPago"].ToString();
                        CboVendedor.SelectedValue = dr["Vendedor"].ToString();
                        ChkPagado.Checked = Convert.ToBoolean(dr["Pagado"].ToString());
                    }

                    //close DataReader
                    dr.Close();
                    con.Close();
                }
            }



        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string facturaId = Request.QueryString["Id"];


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
                SqlCommand sql_cmnd = new SqlCommand("usp_FacturasUpdate", con);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = facturaId;
                sql_cmnd.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = TxtCodigo.Text;
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
    }
}