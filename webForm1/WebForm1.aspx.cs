using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace webForm1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into utbl values('" + TextBox2.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text="Data Has Been Inserted";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update utbl set name='"+TextBox1.Text+"',age='"+TextBox3.Text+"' where Id='"+TextBox2.Text+"'",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Data Has Been Ubdated";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from utbl where Id='"+Convert.ToInt32(TextBox2.Text).ToString()+"'",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Data Has Been Deleted";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string find = "select * from utbl where (Id like '%' +@Id+ '%')";

            SqlCommand cmd = new SqlCommand(find,con);
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = TextBox4.Text ;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds,"Id");

            GridView1.DataSourceID = null;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            con.Close();
            Label1.Text = "data has been selected";
        }
    }
}