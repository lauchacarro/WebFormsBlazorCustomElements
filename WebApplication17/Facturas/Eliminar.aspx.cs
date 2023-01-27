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
using System.ComponentModel;

namespace WebFormsFacturas.Facturas
{
    public partial class Eliminar : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con;

        [Bindable(true)]
        [Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Codigo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string facturaId = Request.QueryString["Id"];

                using (con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand sql_cmnd = new SqlCommand("usp_FacturasSelect", con);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = facturaId;

                    var dr = sql_cmnd.ExecuteReader();
                    while (dr.Read())
                    {

                        LblMessage.Text = $"¿Realmente desea eliminar la factura con codigo: {dr["Codigo"]}?";
                    }

                    //close DataReader
                    dr.Close();
                    con.Close();
                }
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string facturaId = Request.QueryString["Id"];


            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sql_cmnd = new SqlCommand("usp_FacturasDelete", con);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = facturaId;
                sql_cmnd.ExecuteNonQuery();
                con.Close();
            }

            Response.Redirect("/Facturas/Index");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Facturas/Index.aspx");
        }
    }
}