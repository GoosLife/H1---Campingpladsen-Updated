using CampingpladsenAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampingpladsenAuthorization
{
    public partial class BookSpot : System.Web.UI.Page
    {
        // Variables to store data from URL
        int id = 1;
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now;
        Spot s;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get data from url

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                id = Convert.ToInt32(Request.QueryString["id"]);

            if (!string.IsNullOrEmpty(Request.QueryString["startDate"]))
                startDate = Convert.ToDateTime(Request.QueryString["startDate"]);

            if (!string.IsNullOrEmpty(Request.QueryString["endDate"]))
                endDate = Convert.ToDateTime(Request.QueryString["endDate"]);

            // Get spot from id

            s = Spot.GetSpotData(id);

            // Find current price

            DateTime compareable = new DateTime(DateTime.Now.Year, startDate.Month, startDate.Day);
            DateTime peakSeasonStart = new DateTime(DateTime.Now.Year, 6, 14);
            DateTime peakSeasonEnd = new DateTime(DateTime.Now.Year, 8, 15);

            decimal? price;

            if (compareable > peakSeasonStart && compareable < peakSeasonEnd)
            {
                price = s.PricePeakSeason;
            }
            else
            {
                price = s.PriceOffSeason;
            }

            // Bind data to view

            DataTable table = new DataTable();


            table.Columns.Add("spot_id");
            table.Columns.Add("spot_name");
            table.Columns.Add("spot_type");
            table.Columns.Add("spot_price");

            table.Rows.Add(s.Id, s.Name, s.Type, price);

            datalist_spotToBook.DataSource = table;
            datalist_spotToBook.DataBind();
        }

        protected void btn_makeReservation_Click(object sender, EventArgs e)
        {
            // Get customer information
            string customerName = text_customerName.Value;
            string customerAddress = text_customerAddress.Value;
            string customerPhone = text_customerPhone.Value;
            string customerEmail = text_customerEmail.Value;

            // Get reservation information
            int adults = Convert.ToInt32(number_adults.Value);
            int children = Convert.ToInt32(number_children.Value);
            int dogs = Convert.ToInt32(number_dogs.Value);

            // Get extras information
            bool bedLinen = cb_bedLinen.Checked;
            bool exitCleaning = cb_exitCleaning.Checked;
            int bikeRentalTotal = Convert.ToInt32(number_bikeDays.Value) * Convert.ToInt32(number_bikes.Value);
            int waterParkPassesAdult = Convert.ToInt32(number_waterParkPassAdults.Value);
            int waterParkPassesChildren = Convert.ToInt32(number_waterParkPassChildren.Value);

            Customer c = new Customer(customerName, customerAddress, customerPhone, customerEmail);

            Reservation r = new Reservation(c, s, startDate, endDate, adults, children, dogs, bedLinen, exitCleaning, bikeRentalTotal, waterParkPassesAdult, waterParkPassesChildren);

            if (!DbController.InsertReservation(r))
            {
                lbl_invalidForm.Visible = true;
            }
            else
            {
                Response.Redirect("BookSpotConfirmation.aspx");
            }
        }
    }
}