using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignment1
{
    public partial class Products : System.Web.UI.Page
    {

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // Initialize the image visibility and price visibility
                    imgProduct.Visible = false;
                    lblPrice.Visible = false;
                }
            }

            // Event for product selection change
            protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
            {
                int selectedProduct = int.Parse(ddlProducts.SelectedValue);

                // Hide image and price initially
                imgProduct.Visible = false;
                lblPrice.Visible = false;

                // Show the image and price based on the selected product
                switch (selectedProduct)
                {
                    case 1:
                        imgProduct.ImageUrl = "images/product2.jpg"; 
                        lblPrice.Text = "Price: $1000";
                        break;
                    case 2:
                        imgProduct.ImageUrl = "images/product3.jpg";
                        lblPrice.Text = "Price: $2000";
                        break;
                    case 3:
                        imgProduct.ImageUrl = "images/product4.jpg";
                        lblPrice.Text = "Price: $100000";
                        break;
                    case 4:
                        imgProduct.ImageUrl = "images/product5.jpg";
                        lblPrice.Text = "Price: $3000";
                        break;

                default:
                        imgProduct.Visible = false;
                        lblPrice.Visible = false;
                        break;
                }

                // Show image and price
                if (selectedProduct != 0)
                {
                    imgProduct.Visible = true;
                 
                }
            }

            // Button click event to show the price
            protected void btnGetPrice_Click(object sender, EventArgs e)
            {
                // Just to confirm the action (you could also add more logic here if needed)
                lblPrice.Visible = true;
            }
    }
    
}