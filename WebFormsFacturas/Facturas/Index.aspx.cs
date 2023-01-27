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

namespace WebFormsFacturas.Facturas
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillGrid();
            }
        }

        public void FillGrid()
        {

            con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("Select * from Facturas", con));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            adapter.Dispose();
            con.Close();


        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx");
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            Label idLabel = GridView1.Rows[e.NewEditIndex].FindControl("lbl_ID") as Label;

            Response.Redirect("Edit.aspx?Id=" + idLabel.Text);

        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Label idLabel = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;

            Response.Redirect("Eliminar.aspx?Id=" + idLabel.Text);
        }
    }
}