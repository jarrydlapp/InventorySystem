//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			Unit
//
//			File:				Unit.cs
//
//			Student:			Jarryd Lapp
//
//			Course Name:		COSC 4260
//
//			Date:				March 24th 2017
//
//			Description: this program is a cargo tracking software to be used
//          during military training exercises to track and report cargo 
//          within the training area.
//
//           Other Files included: CargoPiece.cs, Container.cs, CShipment.cs, 
//           Person.cs, PointOfContact.cs, Program.cs, RIDSDriver.cs, Unit.cs, 
//           User.cs  	
//*****************************************************************************
using System.Collections.Generic;

namespace RIDS
{
    public class Unit
    {
        private string MUic { get; set; }
        private string MUnitname { get; set; }

        public string Uic
        {
            get { return MUic; }
            set { MUic = value; }
        }
        public string Unitname
        {
            get { return MUnitname; }
            set { MUnitname = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public Unit()
        {
            MUic = Uic;
            MUnitname = Unitname;
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public Unit(string uic, string unitName)
        {
            Uic = uic;
            Unitname = unitName;
        }
        //*********************************************************************
        // AddContact Function
        // This Function Creates a PointOfContact and returns it
        //*********************************************************************
        public PointOfContact AddContact(string uic, string firstName,
            string lastName, string email, string phone, string station)
        {
            PointOfContact poc = new PointOfContact(uic, firstName, lastName,
                email,
                phone, station);
            return poc;
        }

        //*********************************************************************
        // SearchContact
        // This Function Searches for and returns the list of
        // PointOfContacts associated with a Unit.
        //*********************************************************************
        public PointOfContact[] SearchContact(List<Unit> unit,
            List<PointOfContact> lcontacts)
        {
            PointOfContact[] contacts = new PointOfContact[unit.Count];
            List<PointOfContact> tempList = new List<PointOfContact>(lcontacts);
            for (int i = 0; i < unit.Count; i++)
            {
                for (int u = 0; u < tempList.Count; u++)
                {
                    if (unit[i].Uic == tempList[u].Uic)
                    {
                        contacts[i] = tempList[u];
                        tempList.RemoveAt(u);
                        u = tempList.Count;
                    }
                }
            }
            return contacts;
        }

        //*********************************************************************
        // DeleteContact
        // This Function Deletes a Contact associated with a Unit
        //*********************************************************************
        public List<PointOfContact> DeleteContact(PointOfContact contact,
            List<PointOfContact> pList)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (contact.Uic == pList[i].Uic && contact.Firstname ==
                    pList[i].Firstname &&
                    contact.Lastname == pList[i].Lastname && contact.Email ==
                    pList[i].Email)
                {
                    pList.Remove(contact);
                }
            }
            return pList;
        }
    }
}


