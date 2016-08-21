using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gameoflife.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(Globals.GameOfLifeConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("select UserTemplateID, UserID, Name from [UserTemplate]", connection);
                var adapter = new SqlDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                grdUserTemplates.DataSource = dataTable;
                grdUserTemplates.DataBind();
                
            }
        }

        protected void GrdUserTemplateDelete(object sender, GridViewDeleteEventArgs e)
        {
            using (var connection = new SqlConnection(Globals.GameOfLifeConnectionString))
            {
                int index = grdUserTemplates.SelectedIndex;
                connection.Open();

                var command = new SqlCommand("DELETE FROM [UserTemplate] WHERE UserTemplateID = @UserTemplateID", connection);
                command.Parameters.AddWithValue("@UserTemplateID", SqlDbType.Int).Value = Int32.Parse(grdUserTemplates.Rows[e.RowIndex].Cells[1].Text);
                command.ExecuteNonQuery();
                Response.Redirect("UserTemplates.aspx");
            }
        }
    }
}