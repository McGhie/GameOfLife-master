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

                var command = new SqlCommand("select * from [User]", connection);
                var adapter = new SqlDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                grdUsers.DataSource = dataTable;
                grdUsers.DataBind();
            }
        }
    }
}