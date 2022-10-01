using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampingpladsenAuthorization.Models
{
    public class Reservation
    {
        private int? id;

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private Spot spot;

        public Spot Spot
        {
            get { return spot; }
            set { spot = value; }
        }


        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private int numberOfAdults;

        public int NumberOfAdults
        {
            get { return numberOfAdults; }
            set { numberOfAdults = value; }
        }

        private int numberOfChildren;

        public int NumberOfChildren
        {
            get { return numberOfChildren; }
            set { numberOfChildren = value; }
        }

        private int numberOfDogs;

        public int NumberOfDogs
        {
            get { return numberOfDogs; }
            set { numberOfDogs = value; }
        }


        private bool requiresBedLinen;

        public bool RequiresBedLinen
        {
            get { return requiresBedLinen; }
            set { requiresBedLinen = value; }
        }

        private bool requiresExitCleaning;

        public bool RequiresExitCleaning
        {
            get { return requiresExitCleaning; }
            set { requiresExitCleaning = value; }
        }

        private int bikeRentalTotal;

        public int BikeRentalTotal
        {
            get { return bikeRentalTotal; }
            set { bikeRentalTotal = value; }
        }

        private int numberOfAdultWaterParkPasses;

        public int NumberOfAdultWaterParkPasses
        {
            get { return numberOfAdultWaterParkPasses; }
            set { numberOfAdultWaterParkPasses = value; }
        }

        private int numberOfChildrensWaterParkPasses;

        public int NumberOfChildrensWaterParkPasses
        {
            get { return numberOfChildrensWaterParkPasses; }
            set { numberOfChildrensWaterParkPasses = value; }
        }

        /// <summary>
        /// Empty constructor to create an empty reservation in the database controller, that can be filled with the information from the database 
        /// </summary>
        public Reservation() { }

        /// <summary>
        /// Constructor without ID that can be used to create a new reservation (before the ID is known).
        /// </summary>
        public Reservation(Customer customer, Spot spot, DateTime startDate, DateTime endDate, int numberOfAdults, int numberOfChildren, int numberOfDogs, bool requiresBedLinen, bool requiresExitCleaning, int bikeRentalTotal, int numberOfAdultWaterParkPasses, int numberOfChildrensWaterParkPasses)
        {
            this.customer = customer;
            this.spot = spot;
            this.startDate = startDate;
            this.endDate = endDate;
            this.numberOfAdults = numberOfAdults;
            this.numberOfChildren = numberOfChildren;
            this.numberOfDogs = numberOfDogs;
            this.requiresBedLinen = requiresBedLinen;
            this.requiresExitCleaning = requiresExitCleaning;
            this.bikeRentalTotal = bikeRentalTotal;
            this.numberOfAdultWaterParkPasses = numberOfAdultWaterParkPasses;
            this.numberOfChildrensWaterParkPasses = numberOfChildrensWaterParkPasses;
        }

        /// <summary>
        /// Reservation with ID that can be used to collect info about a reservation from the database (this should be called from the GetReservationAttributes function)
        /// </summary>
        public Reservation(int id, Customer customer, Spot spot, DateTime startDate, DateTime endDate, int numberOfAdults, int numberOfChildren, int numberOfDogs, bool requiresBedLinen, bool requiresExitCleaning, int bikeRentalTotal, int numberOfAdultWaterParkPasses, int numberOfChildrensWaterParkPasses)
        {
            this.id = id;
            this.customer = customer;
            this.spot = spot;
            this.startDate = startDate;
            this.endDate = endDate;
            this.numberOfAdults = numberOfAdults;
            this.numberOfChildren = numberOfChildren;
            this.numberOfDogs = numberOfDogs;
            this.requiresBedLinen = requiresBedLinen;
            this.requiresExitCleaning = requiresExitCleaning;
            this.bikeRentalTotal = bikeRentalTotal;
            this.numberOfAdultWaterParkPasses = numberOfAdultWaterParkPasses;
            this.numberOfChildrensWaterParkPasses = numberOfChildrensWaterParkPasses;
        }

        /// <summary>
        /// Convert start date to SMALLDATETIME for database insertion
        /// </summary>
        /// <returns></returns>
        public string StartDateToSmallDateTime()
        {
            return StartDate.ToString("yyyy'-'MM'-'dd'T'13:00:00");
        }

        /// <summary>
        /// Convert end date to SMALLDATETIME for database insertion
        /// </summary>
        /// <returns></returns>
        public string EndDateToSmallDateTime()
        {
            return EndDate.ToString("yyyy'-'MM'-'dd'T'11:00:00");
        }

        /// <summary>
        /// Convert any datetime to the smalldate format for reservations.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="isStartDate">If this is true, the small date will be set at time 13:00:00 (time customer will arrive). If false, it will be 11:00:00 (time customer must leave).</param>
        /// <returns></returns>
        public static string ConvertToSmallDateTime(DateTime time, bool isStartDate = true)
        {
            return isStartDate ? time.ToString("yyyy'-'MM'-'dd'T'13:00:00") : time.ToString("yyyy'-'MM'-'dd'T'11:00:00");
        }

        public static Reservation GetReservationAttributes(int id)
        {
            return DbController.GetReservation(id);
        }
    }
}