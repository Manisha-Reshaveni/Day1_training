using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignment1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

  

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (Page.IsValid)
            {
                lblmsg.Text = "All validations passed successfully!";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblmsg.Text = "There are errors in the form.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }


  


  

  

    
    }
}