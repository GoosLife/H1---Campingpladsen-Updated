using CampingpladsenAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampingpladsenAuthorization
{
    public partial class BrowseSpots : System.Web.UI.Page
    {
        static List<int> selectedTypeIds = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // On first load
            if (!Page.IsPostBack)
            {
                Page.DataBind(); // Binds the calendar controls

                // Get all spot types
                List<string[]> spotTypes = DbController.GetAllSpotTypes();


                // Create checkboxlist with all spot types
                for (int i = 0; i < spotTypes.Count; i++)
                {
                    cbl_spotTypes.Items.Add(new ListItem(spotTypes[i][1], spotTypes[i][0]));
                }

                cbl_spotTypes.DataBind();
            }

            // Get all spots based on list of selected spot type ids
            List<Spot> spots = new List<Spot>();

            for (int i = 0; i < selectedTypeIds.Count; i++)
            {
                spots.AddRange(DbController.GetFreeSpotsOfType(selectedTypeIds[i], calendar_dateStart.SelectedDate));
            }


            // Create data table with spot information
            DataTable table = new DataTable();
            table.Columns.Add("spot_id");
            table.Columns.Add("spot_name");
            table.Columns.Add("spot_type");
            table.Columns.Add("start_date");

            for (int i = 0; i < spots.Count; i++)
            {
                table.Rows.Add(spots[i].Id, spots[i].Name, spots[i].Type);
            }

            datalist_spots.DataSource = table;
            datalist_spots.DataBind();
        }

        protected void cbl_spotTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTypeIds.Clear();

            for (int i = 0; i < cbl_spotTypes.Items.Count; i++)
            {
                if (cbl_spotTypes.Items[i].Selected)
                    selectedTypeIds.Add(Convert.ToInt32(cbl_spotTypes.Items[i].Value));
            }

            // Get all spots bsaed on list of selected spot type ids
            List<Spot> spots = new List<Spot>();

            for (int i = 0; i < selectedTypeIds.Count; i++)
            {
                spots.AddRange(DbController.GetFreeSpotsOfType(selectedTypeIds[i], calendar_dateStart.SelectedDate));
            }


            // Create data table with spot information
            DataTable table = new DataTable();
            table.Columns.Add("spot_id");
            table.Columns.Add("spot_name");
            table.Columns.Add("spot_type");
            table.Columns.Add("start_date");

            for (int i = 0; i < spots.Count; i++)
            {
                table.Rows.Add(spots[i].Id, spots[i].Name, spots[i].Type);
            }

            datalist_spots.DataSource = table;
            datalist_spots.DataBind();
        }
    }
}