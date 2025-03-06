using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4994880_QueryString
{
	public partial class QueryStrings : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Retrive the query string's parameters from the encode URL.
			ddlCategory.SelectedValue = Request.QueryString["ddlCategory"];
			ddlSupplier.SelectedValue = Request.QueryString["ddlSupplier"];
			lblProduct.Text = Request.QueryString["strProduct"];
			txtDescription.Text = Request.QueryString["strDescription"];
			lblImage.Text = Request.QueryString["strImage"];
			Decimal decPrice =
				Convert.ToDecimal(Request.QueryString["decPrice"]);
			lblPrice.Text = "$" + decPrice.ToString();
			lblNumberInStock.Text = Request.QueryString["bytNumberInStock"];
			lblNumberOnOrder.Text = Request.QueryString["bytNumberOnOrder"];
			lblReorderLevel.Text = Request.QueryString["bytReorderLevel"];

			//COmpute and display the value in stock and the value on order
			Byte bytNumberInStock =
				Convert.ToByte(Request.QueryString["bytNumberInStock"]);
			Byte bytNumberOnOrder =
				Convert.ToByte(Request.QueryString["bytNumberOnOrder"]);
			Decimal decValueInStock = decPrice * bytNumberInStock;
			Decimal decValueOnOrder = decPrice * bytNumberOnOrder;
			lblValueInStock.Text = "(Value :" + decValueInStock.ToString() + ")";
			lblValueOnOrder.Text = "(Value :" + decValueOnOrder.ToString() + ")";
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
			Session["ddlCategory"] = ddlCategory.SelectedValue;
			Session["ddlSupplier"] = ddlSupplier.SelectedValue;
			Session["strProduct"] = lblProduct.Text;
			Session["strDescription"] = txtDescription.Text;
			Session["strImage"] = lblImage.Text;
			Session["decPrice"] = lblPrice.Text;
			Session["bytNumberInStock"] = lblNumberInStock.Text;
			Session["bytNumberOnOrder"] = lblNumberOnOrder.Text;
			Session["bytReorderLevel"] = lblReorderLevel.Text;


        }

		protected void btnBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("WebForm1.aspx");
		}
	}
}