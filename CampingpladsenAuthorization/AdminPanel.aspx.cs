using CampingpladsenAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampingpladsenAuthorization
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Send unauthorized users to the login page
            if (Request.Cookies["CampingpladsenAuthorization"] == null)
                Response.Redirect("/Login.aspx");

            // Load data when the page isn't loaded as a post-back
            if (!IsPostBack)
            {
                // Get current reservations
                List<Reservation> currentReservations = DbController.GetCurrentReservations();
                // Get all reservations
                List<Reservation> allReservations = DbController.GetAllReservations();

                // Store all reservations in table
                DataTable reservationsTable = new DataTable();

                // Add the columns that we want to the datatable
                reservationsTable.Columns.Add("Navn");
                reservationsTable.Columns.Add("Adresse");
                reservationsTable.Columns.Add("Telefonnummer");
                reservationsTable.Columns.Add("Email");
                reservationsTable.Columns.Add("Plads");
                reservationsTable.Columns.Add("Type");
                reservationsTable.Columns.Add("Ankomst");
                reservationsTable.Columns.Add("Hjemrejse");
                reservationsTable.Columns.Add("Antal voksne");
                reservationsTable.Columns.Add("Antal børn");
                reservationsTable.Columns.Add("Antal hunde");
                reservationsTable.Columns.Add("Har lejet sengelinned");
                reservationsTable.Columns.Add("Har betalt for rengøring");
                reservationsTable.Columns.Add("Cykeludlejning total");
                reservationsTable.Columns.Add("Badebilletter (voksne)");
                reservationsTable.Columns.Add("Badebilletter (børn)");

                // Add all reservations to the table
                foreach (Reservation reservation in allReservations)
                    reservationsTable.Rows.Add(
                        reservation.Customer.Name,
                        reservation.Customer.Address,
                        reservation.Customer.Phone,
                        reservation.Customer.Email,
                        reservation.Spot.Name,
                        reservation.Spot.Type,
                        reservation.StartDate,
                        reservation.EndDate,
                        reservation.NumberOfAdults,
                        reservation.NumberOfChildren,
                        reservation.NumberOfDogs,
                        reservation.RequiresBedLinen,
                        reservation.RequiresExitCleaning,
                        reservation.BikeRentalTotal,
                        reservation.NumberOfAdultWaterParkPasses,
                        reservation.NumberOfChildrensWaterParkPasses);

                // Bind all reservations to datalist
                gv_allReservations.DataSource = reservationsTable;
                gv_allReservations.DataBind();

                // Clear table
                reservationsTable.Clear();

                // Add current reservations to table
                foreach (Reservation reservation in currentReservations)
                {
                    reservationsTable.Rows.Add(
                        reservation.Customer.Name,
                        reservation.Customer.Address,
                        reservation.Customer.Phone,
                        reservation.Customer.Email,
                        reservation.Spot.Name,
                        reservation.Spot.Type,
                        reservation.StartDate,
                        reservation.EndDate,
                        reservation.NumberOfAdults,
                        reservation.NumberOfChildren,
                        reservation.NumberOfDogs,
                        reservation.RequiresBedLinen,
                        reservation.RequiresExitCleaning,
                        reservation.BikeRentalTotal,
                        reservation.NumberOfAdultWaterParkPasses,
                        reservation.NumberOfChildrensWaterParkPasses);
                }

                // Bind current reservations to datalist
                gv_currentReservations.DataSource = reservationsTable;
                gv_currentReservations.DataBind();
            }
        }
    }
}