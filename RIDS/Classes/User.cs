//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			User
//
//			File:				Users.cs
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
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RIDS
{
    public class User : Person
    {
        private string MUsername { get; set; }
        private string MPassword { get; set; }

        public User()
        {
            MUsername = "";
            MPassword = "";
        }
        //*********************************************************************
        //Constructor
        //*********************************************************************
        public User(string userName, string password, string firstName, 
            string lastName, string email): base(firstName, lastName, email)
        {
            MUsername = userName;
            MPassword = password;
        }
        //*********************************************************************
        // UserLogin Function
        // This Function reads in the user infomration from a file "users.csv"
        // and performs login validation using the Longin.cs form
        //*********************************************************************
        public User UserLogin(string userName, string password)
        {
            //DEFAULT USER LOGIN CREDENTIALS
            if (userName == "ADMIN" && password == "@dmin1")
            {
                User aUser = new User("ADMIN", "@dmin1", "", "", "");
                return aUser;
            }
            try
            {
                using (StreamReader file = new StreamReader(@"users.csv"))
                {
                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();
                        if (line != null)
                        {
                            string[] row = line.Split(',');

                            if (userName.Equals(row[0],
                                StringComparison.InvariantCultureIgnoreCase))

                            {
                                if (password == row[1])
                                {
                                    User u = new User(row[0], row[1], row[2],
                                        row[3],
                                        row[4]);
                                    return u;
                                }
                            }
                        }
                    }
                    file.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "File containing login credentials does not exist. Create a user file or login using the default " +
                    "login provided in the application documentation", "No User File Found");
            }
            return null;
        }
        //*****************************************************************************
        // CreateUnit Function
        // This Function takes in Unit Paramters and creates
        // a unit object and returns that object
        //*****************************************************************************
        public Unit CreateUnit(string uic, string unitname)
        {
            Unit unit = new Unit(uic, unitname);
            return unit;
        }
        //*****************************************************************************
        // SearchUnit Function
        // This Function takes in a searched UIC and a list of Units
        // and finds all units that match the UIC being searched
        //*****************************************************************************
        public List<Unit> SearchUnit(string uic, List<Unit> unit)
        {
            List<Unit> foundUnits = new List<Unit>();
            foreach (Unit u in unit)
            {
                if (uic == u.Uic)
                {
                    foundUnits.Add(u);
                }
            }
            return foundUnits;
        }
        //*****************************************************************************
        // EditUnit Function
        // This function takes in a 2 PointOfContact Objects and a List 
        // of the PointOfContact Objects to be used to perform an Update on 
        // the Point of Contact object. Then it returns the List with
        // updated object  included
        //*****************************************************************************
        public List<PointOfContact> EditUnit(PointOfContact p,
            PointOfContact temp, List<PointOfContact> pList)
        {

            foreach (PointOfContact t in pList)
            {
                if (temp.Firstname == t.Firstname && temp.Lastname == t.Lastname &&
                    temp.Email == t.Email && temp.Phone == t.Phone)
                {
                    t.Firstname = p.Firstname;
                    t.Lastname = p.Lastname;
                    t.Email = p.Email;
                    t.Phone = p.Phone;
                    t.Station = p.Station;

                }
            }
            return pList;
        }

        //*****************************************************************************
        // CreateCargoShipment Function
        // This function creates a CargoShipment Object and returns it
        //*****************************************************************************
        public CShipment CreateCargoShipment(string tcn, string deposition,
            string asset, string destination, string ptcn, string recievedby)
        {
            CShipment cs = new CShipment(tcn, deposition, asset, destination,
                ptcn, recievedby);
            return cs;
        }
    }
}
