using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampingpladsenAuthorization
{
    public class Spot
    {
        private int? id;

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private decimal? pricePeakSeason;

        public decimal? PricePeakSeason
        {
            get { return pricePeakSeason; }
            set { pricePeakSeason = value; }
        }

        private decimal? priceOffSeason;

        public decimal? PriceOffSeason
        {
            get { return priceOffSeason; }
            set { priceOffSeason = value; }
        }

        public Spot() { }

        public Spot(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public Spot(int id, string name, string type, decimal pricePeakSeason, decimal priceOffSeason)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.pricePeakSeason = pricePeakSeason;
            this.priceOffSeason = priceOffSeason;
        }

        /// <summary>
        /// Static function to return one specific spot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Spot GetSpotData(int id)
        {
            return DbController.GetSpot(id);
        }
    }
}