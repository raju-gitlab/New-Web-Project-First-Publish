using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LabelMessege.Visible = false;
                hyperlink.Visible = false;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileextension = Path.GetExtension(filename);
            int filesize = postedFile.ContentLength;

            if(fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".bmp" || fileextension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paraName = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = filename,
                    };
                    cmd.Parameters.Add(paraName);
                    SqlParameter paraSize = new SqlParameter()
                    {
                        ParameterName = "@Size",
                        Value = filesize,
                    };
                    cmd.Parameters.Add(paraSize);
                    SqlParameter paraImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes,
                    };
                    cmd.Parameters.Add(paraImageData);
                    SqlParameter paraNewId = new SqlParameter()
                    {
                        ParameterName = "@NewId",
                        Value = -1,
                        Direction = ParameterDirection.Output


                    };
                    cmd.Parameters.Add(paraNewId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    LabelMessege.Visible = true;
                    LabelMessege.Text = "Uploaded SuccessFully";
                    LabelMessege.ForeColor = System.Drawing.Color.Green;
                    hyperlink.Visible = true;
                }
            }
            else
            {
                LabelMessege.Visible = true;
                LabelMessege.Text = "File extension not supported";
                LabelMessege.ForeColor = System.Drawing.Color.Red;
                hyperlink.Visible = false; 
            }
        }
    }
}