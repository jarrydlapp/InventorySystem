//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			PointOfContact
//
//			File:				PointOfContact.cs
//
//			Student:			Jarryd Lapp
//
//			Course Name:		COSC 4260
//
//			Date:				Feb 9th, 2017
//
//			Description: this program is a cargo tracking software to be used
//          during military training exercises to track and report cargo 
//          within the training area.
//
//          Other Files included: CargoPiece.cs, Container.cs, CShipment.cs, 
//          Person.cs, PointOfContact.cs, Program.cs, RIDSDriver.cs, Unit.cs, 
//          User.cs  	
//*****************************************************************************
namespace RIDS
{
    public class PointOfContact : Person
    {
        private string MPhone { get; set; }
        private string MStation { get; set; }
        private string MUic { get; set; }

        public string Uic
        {
            get { return MUic; }
            set { MUic = value; }
        }
        public string Station
        {
            get { return MStation; }
            set { MStation = value; }
        }
        public string Phone
        {
            get { return MPhone; }
            set { MPhone = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public PointOfContact()
        {
            MPhone = "";
            MStation = "";
            MUic = "";
        }
        //*********************************************************************
        // Person Constructor 
        //*********************************************************************    
        public PointOfContact(string uic, string firstname, string lastname, 
            string email, string phone, string station): base(firstname, 
                lastname, email)
        {
            MPhone = phone;
            MStation = station;
            MUic = uic;
        }
    }
}