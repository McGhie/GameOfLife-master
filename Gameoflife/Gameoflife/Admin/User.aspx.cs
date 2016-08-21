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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(Globals.GameOfLifeConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("select UserID, FirstName, LastName, Email from [User]", connection);
                var adapter = new SqlDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                grdUsers.DataSource = dataTable;
                grdUsers.DataBind();
            }
        }

        protected void GrdUserDelete(object sender, GridViewDeleteEventArgs e)
        {
            using (var connection = new SqlConnection(Globals.GameOfLifeConnectionString))
            {
                connection.Open();
                var cmdGame = new SqlCommand("DELETE FROM [UserGame] WHERE UserID = @UserID", connection);
                var cmd = new SqlCommand("DELETE FROM [UserTemplate] WHERE UserID = @UserID", connection);
                var command = new SqlCommand("DELETE FROM [User] WHERE UserID = @UserID", connection);
                cmdGame.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value =
                    Int32.Parse(grdUsers.Rows[e.RowIndex].Cells[1].Text);
                cmd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = Int32.Parse(grdUsers.Rows[e.RowIndex].Cells[1].Text);
                command.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = Int32.Parse(grdUsers.Rows[e.RowIndex].Cells[1].Text);
                cmdGame.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                command.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("User.aspx");
            }
        }
    }
}