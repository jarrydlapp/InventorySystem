//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//
//			File:				RIDSDriver.cs
//
//			Student:			Jarryd
//
//			Course Name:		COSC 4260
//
//			Date:				April 12th 2017
//
//			Description: this program is a cargo tracking software to be used
//          during military training exercises to track and report cargo 
//          within the training area.
//
//          Other Files included: CargoPiece.cs, Container.cs, CShipment.cs, 
//          Person.cs, PointOfContact.cs, Program.cs, RIDSDriver.cs, Unit.cs, 
//          User.cs  	
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RIDS
{
    class RidsDriver
    {
        private readonly User _users = new User();
        private readonly List<Unit> _uList = new List<Unit>();
        private List<PointOfContact> _pList = new List<PointOfContact>();
        public readonly List<RollingStock> RsList = new List<RollingStock>();
        private readonly List<RollingStock> _tempRsList = new List<RollingStock>();
        public readonly List<Container> CList = new List<Container>();
        private readonly List<Container> _tempcList = new List<Container>();
        public readonly List<CShipment> CsList = new List<CShipment>();
        private readonly List<CShipment> _tempcsList = new List<CShipment>();
        public readonly List<CargoPiece> CpList = new List<CargoPiece>();
        public readonly List<CargoPiece> TempcpList = new List<CargoPiece>();
        private string[] _manifestHeaders;

        //*********************************************************************
        // User Login Function 
        //*********************************************************************
        public bool UserLogin(string userName, string password)
        {
            var voo = _users.UserLogin(userName, password);

            return voo != null;
        }
        //*********************************************************************
        // Loads unit information if file exist
        //*********************************************************************
        public void LoadUnits()
        {
            try
            {
                if (File.Exists(@"UnitInformation.csv"))
                {
                    var file = new StreamReader(@"UnitInformation.csv");

                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        if (line == null) continue;
                        string[] row = line.Split(',');
                        Unit u = new Unit(row[1], row[0]);
                        _uList.Add(u);
                        PointOfContact pointOfContact = 
                            new PointOfContact(row[1], row[2], row[3], 
                            row[4], row[5],
                            row[6]);
                        _pList.Add(pointOfContact);
                    }
                    file.Close();
                }
                else
                {
                    var file = new StreamWriter(@"UnitInformation.csv");
                    file.WriteLine("Unit" + "," + "UIC" + "," +
                        "Contact First Name" + "," + "Contact Last Name" + ","
                        + "Contact Email" + "," + "Contact Phone" + "," +
                        "Station");
                    Unit u = new Unit("UIC", "Unit");
                    _uList.Add(u);
                    PointOfContact pointOfContact = new PointOfContact
                        ("UIC", "Contact First Name", "Contact Last Name",
                        "Contact Email","Contact Phone", "Station");
                    _pList.Add(pointOfContact);
                    file.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show(@"File that contains Unit Information is being
                used by another process, Units Not Loaded.");
            }
        }
        //*********************************************************************
        // Function to check if Contact is a duplicate
        //*********************************************************************
        public bool CheckContactDupe(string uic, string firstName,
            string lastName, string email,
            string phone)
        {
            foreach (PointOfContact p in _pList)
            {
                if ((string.Equals(p.Uic, uic, StringComparison.
                    CurrentCultureIgnoreCase)) &&
                    (string.Equals(p.Firstname, firstName, StringComparison.
                    CurrentCultureIgnoreCase)) &&
                    (string.Equals(p.Lastname, lastName, StringComparison.
                    CurrentCultureIgnoreCase)) &&
                    ((string.Equals(p.Email, email, StringComparison.
                    CurrentCultureIgnoreCase)) ||
                     (string.Equals(p.Phone, phone, StringComparison.
                     CurrentCultureIgnoreCase))))
                {
                    return true;
                }
            }
            return false;
        }
        //*********************************************************************
        // Function to Create a Unit Profile (Unit and Point of Contact)
        //*********************************************************************
        public bool CreateUnitProfile(string uic, string unitName, 
            string firstName, string lastName, string email, string phone, 
            string station)
        { 
            bool dupecontact = CheckContactDupe(uic, firstName, lastName, 
                email, phone);
            if (!dupecontact)
            {
                User user = new User();
                Unit unit = user.CreateUnit(uic, unitName);
                _uList.Add(unit);
                PointOfContact poc = unit.AddContact(uic, firstName, 
                    lastName, email, phone, station);
                _pList.Add(poc);
                WriteUnits();
                return false;
            }
            return true;
        }
        //*********************************************************************
        // Function used to search for unit in Unit Profile Form
        //*********************************************************************
        public List<Unit> SearchUnit(string uic)
        {
            var found = _users.SearchUnit(uic, _uList);
            if (found.Count != 0)
            {
                return found;
            }
            return found;
        }
        //*********************************************************************
        // Function used to search for Contacts in Unit Profile form
        //*********************************************************************
        public PointOfContact[] SearchContact(List<Unit> unit)
        {
            Unit u = new Unit();
            var found = u.SearchContact(unit, _pList);

            return found;
        }
        //*********************************************************************
        // Function used to Edit a unit contact from the Unit Profile from
        //*********************************************************************
        public void EditUnit(PointOfContact p, PointOfContact temp)
        {
            _pList = _users.EditUnit(p, temp, _pList);
        }
        //*********************************************************************
        // Function called to delete contact from Unit Profile Form
        //*********************************************************************
        public List<Unit> DeleteContact(PointOfContact contact)
        {
            int index = 0;
            Unit u = new Unit();
            _pList = u.DeleteContact(contact, _pList);

            for (int i = 0; i < _uList.Count; i++)
            {
                if (contact.Uic == _uList[i].Uic)
                {
                    index = i;
                }
            }
            _uList.RemoveAt(index);

            return _uList;
        }
        //*********************************************************************
        // Function Called to Create cargo shipment from Create manifest form
        //*********************************************************************
        public void CreateCargoShipment(CShipment cs)
        {
            User u = new User();
            CShipment CS = u.CreateCargoShipment(cs.Tcn, cs.Deposition, 
                cs.Asset, cs.Destination, cs.PieceTcn,
                cs.RecievedBy);
            if (CS == null) throw new ArgumentNullException(nameof(CS));
            _tempcsList.Add(CS);

        }
        //*********************************************************************
        // Function to add cargo pieces to manifest
        //*********************************************************************
        public void CreateCargoShipment(List<RollingStock> rList, 
            List<Container> cnList)
        {
            foreach (var r in rList)
            {
                _tempRsList.Add(r);
            }
            foreach (var c in cnList)
            {
                _tempcList.Add(c);
            }
        }
        //*********************************************************************
        // Function used to create cargo pieces
        //*********************************************************************
        public void AddCargoPiece(string tcn, string cargotype,
            string unitowner, string idNumber, string destination,
            string deposition, bool isSensitive, bool isDamaged,
            bool isHazmat, bool isHighVis, string comments, DateTime dateTime)
        {
            CShipment cs = new CShipment();
            CargoPiece cp = cs.AddCargoPiece(idNumber, destination, cargotype,
                unitowner, deposition, tcn, comments,
                isSensitive, isDamaged, isHazmat, isHighVis, dateTime);
            TempcpList.Add(cp);
        }
        //*********************************************************************
        // Function used to load cargo information from Log File
        //*********************************************************************
        public void LoadCargoShipments()
        {
            try
            {
                if (File.Exists(@"AddCargoLog.csv"))
                {
                    StreamReader file = new StreamReader(@"AddCargoLog.csv");
                    var hline = file.ReadLine();
                    if (hline != null)
                        _manifestHeaders = hline.Split(',');

                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();
                        if (line != null)
                        {
                            string[] row = line.Split(',');
                            CShipment cs = new CShipment(row[0], row[1], row[3]
                                ,row[2], row[5], row[4]);
                            CsList.Add(cs);
                            CargoPiece cp = new CargoPiece(row[5], row[6], 
                                row[9], row[7], row[11], row[10], 
                                Convert.ToBoolean(row[14]),
                                Convert.ToBoolean(row[16]),
                                Convert.ToBoolean(row[13]),
                                Convert.ToBoolean(row[15]), row[18],
                                Convert.ToDateTime(row[19]));
                            CpList.Add(cp);
                            if (row[6] == "Rolling Stock")
                            {
                                RollingStock rs = new RollingStock(row[5], 
                                    row[6], row[9], row[7], row[8],
                                    Convert.ToBoolean(row[12]), row[11],
                                    row[10], Convert.ToBoolean(row[14]),
                                    Convert.ToBoolean(row[16]),
                                    Convert.ToBoolean(row[13]),
                                    Convert.ToBoolean(row[15]),
                                    row[18], Convert.ToDateTime(row[19]));
                                RsList.Add(rs);
                            }
                            else
                            {
                                Container c = new Container(row[5], row[6],
                                    row[7], row[9], row[11], row[10], row[8],
                                    Convert.ToBoolean(row[17]),
                                    Convert.ToBoolean(row[14]),
                                    Convert.ToBoolean(row[16]),
                                    Convert.ToBoolean(row[13]),
                                    Convert.ToBoolean(row[15]),
                                    row[18], Convert.ToDateTime(row[19]));
                                CList.Add(c);
                            }
                        }
                    }
                    file.Close();
                }
                else
                {
                    StreamWriter file = new StreamWriter(@"AddCargoLog.csv");
                    file.WriteLine("TCN" + "," + "Deposition" + "," +
                        "Destination" + "," + "Asset" + "," + "Recieved By" +
                        "," + "Piece TCN" + "," + "Cargo Type" + "," + 
                        "Piece ID" + "," + "Description" + "," +"Unit Owner" + 
                        "," + "Deposition" + "," + "Destination" + "," + 
                        "Drivable" + "," + "Hazmat" + "," + "Sensitive Item"
                        + "," + "High Visabilty" + "," +"Damaged" + "," + 
                        "Trained Pallet" + "," + "Comments" + "," + "Date");
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        //*********************************************************************
        // Writes the Cargo Information to data file
        //*********************************************************************
        public void WriteCargoShipment()
        {
            try
            {
                StreamWriter file = new StreamWriter(@"AddCargoLog.csv", true);
                {
                    foreach (var cs in _tempcsList)
                    {
                        foreach (RollingStock t in _tempRsList)
                            if (cs.PieceTcn == t.Tcn)
                            {
                                file.WriteLine(cs.Tcn + "," + cs.Deposition +
                                    "," + cs.Destination + "," + cs.Asset + ","
                                    + cs.RecievedBy + "," + t.Tcn+ "," + 
                                    t.Cargotype + "," + t.IdNumber + "," + 
                                    t.Description + "," + t.Unitowner + "," + 
                                    t.Deposition + "," + t.Destination+ "," + 
                                    t.IsDrivable + "," + t.IsHazmat + "," +
                                    t.IsSensitive + "," + t.IsHighVisability + 
                                    "," + t.IsDamaged + "," + "" + "," + 
                                    t.Comments + "," + t.Datetime);
                            }
                        foreach (Container c in _tempcList)
                            if (cs.PieceTcn == c.Tcn)
                            {
                                file.WriteLine(cs.Tcn + "," + cs.Deposition + 
                                    "," + cs.Destination + "," + cs.Asset + ","
                                    + cs.RecievedBy + "," + c.Tcn + "," + 
                                    c.Cargotype + "," + c.IdNumber + "," + 
                                    c.Description + "," + c.Unitowner + "," + 
                                    c.Deposition + "," + c.Destination + "," + 
                                    "" + "," + c.IsHazmat + "," + c.IsSensitive
                                    + "," + c.IsHighVisability + "," + 
                                    c.IsDamaged + "," + c.IsTrained + "," + 
                                    c.Comments + "," + c.Datetime);
                            }
                    }
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        //*********************************************************************
        // Write Unit information to external file
        //*********************************************************************
        public void WriteUnits()
        {
            try
            {
                File.Delete(@"UnitInformation.csv");

                StreamWriter file = new StreamWriter(@"UnitInformation.csv");

                for (int i = 0; i < _uList.Count; i++)
                {
                    file.WriteLine(_uList[i].Unitname + "," + _uList[i].Uic +
                        "," + _pList[i].Firstname + "," + _pList[i].Lastname + 
                        "," + _pList[i].Email + "," + _pList[i].Phone + "," +
                        _pList[i].Station);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        //*********************************************************************
        // Export data file from system
        //*********************************************************************
        public void Export(string filePath)
        {
            try
            {
                LoadUnits();
                if (File.Exists(@"AddCargoLog.csv"))
                {
                    StreamReader inFile = new StreamReader(@"AddCargoLog.csv");

                    var hline = inFile.ReadLine();
                    if (hline != null)
                    {
                        _manifestHeaders = hline.Split(',');
                    }
                    StreamWriter file = new StreamWriter(filePath);
                    file.WriteLine("Movement TCN" + "," + "Unit Owner" + "," + 
                        "UIC" + "," + "Date of Deposition" + "," + "Deposition"
                        + "," + "Cargo TCN" + "," + "Cargo Type" + "," + 
                        "Cargo ID" + "," + "Description" + "," + "Destination" 
                        + "," + "Driveable" + "," + "Sensitive Item" + "," + 
                        "Damaged" + "," + "Contains Hazmat" + "," + 
                        "High Visablity" + "," + "Trained Pallet" + "," +
                        "Asset" + "," + "Transported By Unit" + "," + 
                        "Destination" + "," +"Comments");
                    while (!inFile.EndOfStream)
                    {
                        var line = inFile.ReadLine();
                        if (line != null)
                        {
                            string[] row = line.Split(',');
                            string uic = "No UIC Data Found";

                            foreach (Unit t in _uList)
                            {
                                if (row[9] == t.Unitname)
                                {
                                    uic = t.Uic;
                                    break;
                                }
                            }
                            file.WriteLine(row[0] + "," + row[9] + "," + uic +
                                           "," + row[19] + "," + row[1] +
                                           "," + row[5] + "," + row[6] + "," +
                                           row[7] + "," + row[8] + "," + row[11] +
                                           "," + ConvertBool(row[12]) + "," +
                                           ConvertBool(row[14]) + "," +
                                           ConvertBool(row[16]) + ","
                                           + ConvertBool(row[13]) + "," +
                                           ConvertBool(row[15]) + "," +
                                           ConvertBool(row[17]) + "," + row[3] 
                                           + "," + row[4] + "," + row[2] + 
                                           "," + row[18]);
                        }
                    }
                    file.Close();
                    inFile.Close();
                    MessageBox.Show(@"Export Successful");

                }
                else
                {
                    MessageBox.Show(@"There Is No Data To Export");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        //*********************************************************************
        // Function that imports data from another RIDS file
        //*********************************************************************
        public void ImportData(string sourcefile)
        {
          try
            {
                StreamReader file = new StreamReader(sourcefile);
                var hline = file.ReadLine();
                if (hline != null)
                    _manifestHeaders = hline.Split(',');

                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (line != null)
                    {
                        string[] row = line.Split(',');
                        CShipment cs = new CShipment(row[0], row[4], row[16],
                            row[18], row[5], row[17]);
                        _tempcsList.Add(cs);
                        CargoPiece cp = new CargoPiece(row[5], row[6], row[1],
                            row[7], row[9], row[4],
                            RevertBool(row[11]), RevertBool(row[12]),
                            RevertBool(row[13]), RevertBool(row[14]), 
                            row[19], Convert.ToDateTime(row[3]));
                        TempcpList.Add(cp);
                        if (row[6] == "Rolling Stock")
                        {
                            RollingStock rs = new RollingStock(row[5], row[6],
                                row[1], row[7], row[8],
                                RevertBool(row[10]), row[9], row[4],
                                RevertBool(row[11]), RevertBool(row[12]),
                                RevertBool(row[13]), RevertBool(row[14]),
                                row[19], Convert.ToDateTime(row[3]));
                            _tempRsList.Add(rs);
                        }
                        else
                        {
                            Container c = new Container(row[5], row[6], row[7],
                                row[1], row[9], row[4], row[8],
                                RevertBool(row[15]), RevertBool(row[11]),
                                RevertBool(row[12]), RevertBool(row[13]),
                                RevertBool(row[14]),
                                row[19], Convert.ToDateTime(row[3]));
                            _tempcList.Add(c);
                        }
                    }
                }
                file.Close();
                WriteCargoShipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        //*********************************************************************
        // Validates Importing file to ensure it is another RIDS Export 
        //*********************************************************************
        public string ValidateInputFile(string sourcefile)
        {
            string[] cargoHeaders =
            {
                "Movement TCN", "Unit Owner", "UIC", "Date of Deposition",
                "Deposition", "Cargo TCN", "Cargo Type", "Cargo ID",
                "Description", "Destination", "Driveable",
                "Sensitive Item", "Damaged", "Contains Hazmat", "High Visablity",
                "Trained Pallet", "Asset", "Transported By Unit", "Destination",
                "Comments",
            };

            int colCount = 0;
            StreamReader source = new StreamReader(sourcefile);
            var hline = source.ReadLine();
            if (hline != null)
            {
                var line = hline.Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    colCount++;
                }
            }
            if (colCount == cargoHeaders.Length)
            {
                var header = hline.Split(',');
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] != cargoHeaders[i])
                    {
                        return "";
                    }
                }
            }
            else
            {
                return "";
            }
            return "Cargo";
        }
        //*********************************************************************
        // Function Called to loan "Recieved By" list box of unique Unit Names
        //*********************************************************************
        public List<string> LoadRecievedBy()
        {
            List<Unit> ulist = new List<Unit>();
            try
            {
                if (File.Exists(@"UnitInformation.csv"))
                {
                    StreamReader file = new StreamReader(@"UnitInformation.csv");
                    var hline = file.ReadLine();
                    if (hline != null)
                    {
                        while (!file.EndOfStream)
                        {
                            var line = file.ReadLine();
                            if (line != null)
                            {
                                string[] row = line.Split(',');
                                Unit u = new Unit("", row[0]);
                                ulist.Add(u);
                            }
                        }
                        file.Close();
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show(
                    @"File that contains unit nformation is being used by 
                    another process. Units have not been loaded.");
            }
            var uniqueUnit = ulist.Select(u => u.Unitname).Distinct().ToList();
            try
            {
                for (int i = 0; i < uniqueUnit.Count; i++)
                {
                    if (uniqueUnit[i] == "")
                    {
                        uniqueUnit.RemoveAt(i);
                    }
                    else if (uniqueUnit[i] == "Unit")
                    {
                        uniqueUnit.RemoveAt(i);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(@"Index Out of Range", Convert.ToString(ex));
            }
            return uniqueUnit;
        }
        //*********************************************************************
        // Reverts Bool's to True/False for import
        //*********************************************************************
        private static bool RevertBool(string b)
        {
            b = b == "Yes" ? "TRUE" : "FALSE";
            return Convert.ToBoolean(b);
        }
        //*********************************************************************
        // Convernts Bools to Yes or "" for Export
        //*********************************************************************
        private static string ConvertBool(string b)
        {
            b = b == "TRUE" ? "Yes" : "";
            return b;
        }
    }
}

