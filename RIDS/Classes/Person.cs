//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			Person
//
//			File:				Person.cs
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
    public class Person
    {
        private string MFirstname { get; set; }
        private string MLastname { get; set; }
        private string MEmail { get; set; }

        public string Firstname
        {
            get { return MFirstname; }
            set { MFirstname = value; }
        }
        public string Lastname
        {
            get { return MLastname; }
            set { MLastname = value; }
        }
        public string Email
        {
            get { return MEmail; }
            set { MEmail = value; }
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        protected Person()
        {
            MFirstname = "";
            MLastname = "";
            MEmail = "";
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public Person(string firstName, string lastName, string email)
        {
            MFirstname = firstName;
            MLastname = lastName;
            MEmail = email;
        }
    }
}