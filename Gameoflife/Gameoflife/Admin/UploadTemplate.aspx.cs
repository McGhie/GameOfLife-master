﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gameoflife.Admin
{
    public partial class UploadTemplate : System.Web.UI.Page
    {
        protected void ButtonClick (object sender, EventArgs e)
        {
            List<string> stringList = new List<string>();
            ; 
            List<string> Cells = new List<string>();
            if (Uploader.HasFile)
            {
                StreamReader reader = new StreamReader(Uploader.FileContent);
                do
                {
                    string textLine = reader.ReadLine();
                    stringList.Add(textLine);

                } while (reader.Peek() != -1);
                reader.Close();

                var Height = stringList[0];
                var Width = stringList[1];
                
                for (int i = 2; i < stringList.Count; i++)
                {
                    Cells.Add(stringList[i]);
                }

                string output = string.Join("", Cells);
                string Name = "temp";
                int UserID = 1;


                using (var connection = new SqlConnection(Globals.GameOfLifeConnectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand("INSERT INTO UserTemplate (UserID, Name, Height, Width, Cells) VALUES(@UserID, @Name, @Height, @Width, @Cells)",
                        connection);
                    cmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar);
                    cmd.Parameters.AddWithValue("@Height", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@Width", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@Cells", SqlDbType.NVarChar);
                    cmd.ExecuteNonQuery();
                }
            }


        }
    }
}