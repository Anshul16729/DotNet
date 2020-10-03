using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace assignment
{
    public partial class form : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EducationCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

            string name = NameTextBox.Text.Trim();
            string age = AgeTextBox.Text.Trim();
            string gender = string.Empty;
            if (FemaleRadioButton.Checked)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }
           
            string education = "";
            for (int i = 0; i < EducationCheckBoxList.Items.Count; i++)
            {
                if (EducationCheckBoxList.Items[i].Selected)
                {
                    education += EducationCheckBoxList.Items[i].Text + ",";
                }
            }
            education = education.TrimEnd(',');

            string city = CityDropDownList.SelectedValue.Trim();


            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd=new SqlCommand("INSERT INTO assignment(Name,Age,Gender,Education,City) VALUES (@name,@age,@gender,@education,@city)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@education", education);
                    cmd.Parameters.AddWithValue("@city", city);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (Page.IsValid)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Data Saved Successfully!!')</script>");

                    }

                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Data did not saved..')</script>");

                    }
                    con.Close();
                }
            }
        }
    }
}