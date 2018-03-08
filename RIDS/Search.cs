using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Security.Policy;

namespace RIDS
{
    public partial class Search : Form
    {
        public class CargoLogObject
        {
            public string ManifestTcn { get; set; }
            public string ManifestDepo { get; set; }
            public string ManifestDest { get; set; }
            public string ManifestAsset { get; set; }
            public string ManifestRecBy { get; set; }
            public string Piecetcn { get; set; }
            public string CargoType { get; set; }
            public string PieceId { get; set; }
            public string PieceDesc { get; set; }
            public string PieceOwner { get; set; }
            public string OwnerUic { get; set; }
            public string PieceDepo { get; set; }
            public string PieceDest { get; set; }
            public string Drivable { get; set; }
            public string Hazmat { get; set; }
            public string Sensitive { get; set; }
            public string HighVis { get; set; }
            public string Damaged { get; set; }
            public string TrainedPallet { get; set; }
            public string Comments { get; set; }
            public string DateofDepo { get; set; }

            //Constructor
            public CargoLogObject(string manifestTcn, string manifestDepo, string manifestDest, string manifestAsset,
                string manifestRecBy, string piecetcn, string cargoType, string pieceId, string pieceDesc,
                string pieceOwner, string ownerUic, string pieceDepo, string pieceDest, string drivable, string hazmat, string sensitive,
                string highVis, string damaged, string trainedPallet, string comments, string dateofDepo)
            {
                ManifestTcn = manifestTcn;
                ManifestDepo = manifestDepo;
                ManifestDest = manifestDest;
                ManifestAsset = manifestAsset;
                ManifestRecBy = manifestRecBy;
                Piecetcn = piecetcn;
                CargoType = cargoType;
                PieceId = pieceId;
                PieceDesc = pieceDesc;
                PieceOwner = pieceOwner;
                OwnerUic = ownerUic;
                PieceDepo = pieceDepo;
                PieceDest = pieceDest;
                Drivable = drivable;
                Hazmat = hazmat;
                Sensitive = sensitive;
                HighVis = highVis;
                Damaged = damaged;
                TrainedPallet = trainedPallet;
                Comments = comments;
                DateofDepo = dateofDepo;
            }
        }
        //Input Parameter Variables
        public string SeachedUnitName;
        public string SearchedUic;
        public string SearchedTcn;
        public string SearchedCargoType;

        public DataTable Dt = new DataTable();

        private string _cargoLogHeaders;
        private string _unitInfoHeaders;
        private List<string> _uniqueUnitUic;
       

        public List<CargoLogObject> CargoLogObjects = new List<CargoLogObject>();
        public List<Unit> Units = new List<Unit>();
        public List<PointOfContact> Contacts = new List<PointOfContact>();

        private readonly List<CargoLogObject> _tempObjects = new List<CargoLogObject>();
        private readonly List<Unit> _tempUnit = new List<Unit>();
        //List<PointOfContact> tempContact = new List<PointOfContact>();
        private int _resultcount = 0;

        public void CreateSourceObjects()
        {
            //////////////////////////////////////
            //Create Unit and Unit Contact Objects
            try
            {
                StreamReader file = new StreamReader(@"UnitInformation.csv");
                _unitInfoHeaders = file.ReadLine();
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    string[] row = line.Split(',');

                    Unit unit = new Unit(row[1], row[0]);
                    PointOfContact contact = new PointOfContact(row[1], row[2], row[3], row[4], row[5], row[6]);

                    Units.Add(unit);
                    Contacts.Add(contact);
                }
                file.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("UnitInformation.csv does not exisit", "File Not Found");
     
            }

            _uniqueUnitUic = Units.Select(u => u.Uic).Distinct().ToList();
            
            ///////////////////////////////////////
            //Create CargoObject
            try
            {
                StreamReader cargoFile = new StreamReader(@"AddCargoLog.csv");

                _cargoLogHeaders = cargoFile.ReadLine();
                
                while (!cargoFile.EndOfStream)
                {
                    var line = cargoFile.ReadLine();
                    string[] row = line.Split(',');

                    string uic = GetUic(row[9]);


                    CargoLogObject cargoObj = new CargoLogObject(row[0], row[1], row[2], row[3], row[4],
                        row[5], row[6], row[7], row[8], row[9], uic, row[10], row[11],
                        row[12], row[13], row[14], row[15], row[16], row[17], row[18], row[19]);

                    CargoLogObjects.Add(cargoObj);
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("AddCargoLog.csv does not exist","File Not Found");
           
            }
        }

        public string GetUic(string unitname)
        {
            foreach (Unit t in Units)
            {
                if (t.Unitname == unitname)
                {
                    return t.Uic;
                }
            }
            return "No Matched Unit";
        }
        public Search(string unitName, string uic, string cargoType, string tcn)
        {
            Dt.Clear();
            InitializeComponent();
            SeachedUnitName = unitName;
            SearchedUic = uic.ToUpper();
            SearchedCargoType = cargoType;
            SearchedTcn = tcn;
        }

        public DialogResult CargoUnitOption()
        {
            var result =MessageBox.Show(
                        @"If you want contact information associated with the unit you are searching, press yes. " +
                        @"Otherwise cargo information will be returned",
                        @"Choose Unit Search Results",
                        MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                return result;
            }
            return result;
        }

        private void Search_Load_1(object sender, EventArgs e)
        {
            CreateSourceObjects();
            //Search by only UnitName
            if (SearchedUic == "" && SearchedCargoType == "" && SearchedTcn == "" && SeachedUnitName != "")
            {
               SearchByUnitName();
            }
            //Search by UnitName & UIC
            if (SearchedCargoType == "" && SearchedTcn == "" && SearchedUic != "" && SeachedUnitName != "") 
            {
                SearchByUnitNameUic();
            }
           //Search By UnitName & TCN
            if (SearchedCargoType == "" && SearchedTcn != "" && SearchedUic == "" && SeachedUnitName != "")
            {
                SearchByUnitNameTcn();
            }
            //Seach By UnitName & Cargo Type
            if (SearchedCargoType != "" && SearchedTcn == "" && SearchedUic == "" && SeachedUnitName != "")
            {
                SearchByCargoTypeUnitName();
            }
            //Search By UnitName, UIC & TCN
            if (SearchedCargoType == "" && SearchedTcn != "" && SearchedUic != "" && SeachedUnitName != "")
            {
                SearchByUnitNameUicTcn();
            }
            //Search By UnitName, TCN & CargoType
            if (SearchedCargoType != "" && SearchedTcn != "" && SearchedUic == "" && SeachedUnitName != "")
            {
                SearchByUnitNameTcnCType();
            }
            //Search By UnitName, UIC, TCN & CargoType
            if (SearchedCargoType != "" && SearchedTcn != "" && SearchedUic != "" && SeachedUnitName != "")
            {
                SearchByUnitNameUicTcnCType();
            }
            //Search By CargoType
            if (SearchedCargoType != "" && SearchedTcn == "" && SearchedUic == "" && SeachedUnitName == "")
            {
                SearchByCargoType();
            }
            //Search by TCN
            if (SearchedCargoType == "" && SearchedTcn != "" && SearchedUic == "" && SeachedUnitName == "")
            {
                SearchByTcn();
            }
            //Search by TCN & CargoType
            if (SearchedCargoType != "" && SearchedTcn != "" && SearchedUic == "" && SeachedUnitName == "")
            {
                SearchByTcncType();
            }
            //Search by UIC
            if (SearchedCargoType == "" && SearchedTcn == "" && SearchedUic != "" && SeachedUnitName == "")
            {
                SearchByUic();
            }
            //Search by UIC & tcn
            if (SearchedCargoType == "" && SearchedTcn != "" && SearchedUic != "" && SeachedUnitName == "")
            {
                SearchByUicTcn();
            }
            //Search by UIC & CargoType
            if (SearchedCargoType != "" && SearchedTcn == "" && SearchedUic != "" && SeachedUnitName == "")
            {
                SearchByUicCType();
            }
            //Search by UIC, TCN & Cargo Type
            if (SearchedCargoType != "" && SearchedTcn != "" && SearchedUic != "" && SeachedUnitName == "")
            {
                SearchByUicTcncCType();
            }

            if (_resultcount ==0)
           {
                MessageBox.Show(@"Search returned zero results. Please try a different criteria", @"No Match Found");
                Close();
           }
        }

        public void SearchByUicCType()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)) &&
                    (string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase)))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByUnitNameTcnCType()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if (((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                     (string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase)) &&
                     ((string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                      (string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)))))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByTcncType()
        {
             foreach (CargoLogObject obj in CargoLogObjects)
            {
                if (((string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                     (string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase))) &&
                    (string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase)))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }


        public void SearchByUicTcncCType()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)) &&
                    (string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase)) &&
                    ((string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                     (string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase))))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByUicTcn()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)) &&
                    ((string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                     (string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase))))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }

            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByUnitNameUicTcnCType()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                    (string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)) &&
                    (string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase)) &&
                    ((string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                     (string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase))))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }

            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }


        public void SearchByUnitNameUicTcn()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                    (string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)) &&
                    ((string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                     (string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase))))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }


        public void SearchByUic()
        {
            DialogResult res = CargoUnitOption();
            if (res != DialogResult.Yes)
            {
               foreach (CargoLogObject obj in CargoLogObjects)
                    {
                        if (string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase))
                        {
                            _tempObjects.Add(obj);
                            _resultcount++;
                        }
                    }
                
                if (_tempObjects.Count != 0)
                {
                    AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
                }
            }
            else
            {
                foreach (Unit u in Units)
                {
                    if (string.Equals(u.Uic, SearchedUic, StringComparison.CurrentCultureIgnoreCase))
                    {
                        _tempUnit.Add(u);
                        _resultcount++;
                    }

                }
                if (_tempUnit.Count != 0)
                {
                    AddUnitToDataTable(_tempUnit, _unitInfoHeaders);
                }
            }
        }

        public void SearchByTcn()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }

            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByCargoType()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if (string.Equals(obj.CargoType, SearchedCargoType,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByCargoTypeUnitName()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if ((string.Equals(obj.PieceOwner, SeachedUnitName,StringComparison.CurrentCultureIgnoreCase)) &&
                    string.Equals(obj.CargoType, SearchedCargoType, StringComparison.CurrentCultureIgnoreCase))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByUnitNameTcn()
        {
            foreach (CargoLogObject obj in CargoLogObjects)
            {
                if (((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                     string.Equals(obj.Piecetcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)) ||
                    ((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                     string.Equals(obj.ManifestTcn, SearchedTcn, StringComparison.CurrentCultureIgnoreCase)))
                {
                    _tempObjects.Add(obj);
                    _resultcount++;
                }
            }
            if (_tempObjects.Count != 0)
            {
                AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
            }
        }

        public void SearchByUnitNameUic()
        {
            DialogResult res = CargoUnitOption();
            if (res != DialogResult.Yes)
            {
                foreach (CargoLogObject obj in CargoLogObjects)
                {
                    if ((string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                        (string.Equals(obj.OwnerUic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        _tempObjects.Add(obj);
                        _resultcount++;
                    }
                }
                if (_tempObjects.Count != 0)
                {
                    AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
                }
            }
            else
            {
                foreach (Unit u in Units)
                {
                    if ((string.Equals(u.Unitname, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase)) &&
                        (string.Equals(u.Uic, SearchedUic, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        _tempUnit.Add(u);
                        _resultcount++;
                    }
                }
                if (_tempUnit.Count != 0)
                {
                    AddUnitToDataTable(_tempUnit, _unitInfoHeaders);
                }
            }
        }

        public void SearchByUnitName()
        {
            DialogResult res = CargoUnitOption();
            if (res != DialogResult.Yes)
            {
                foreach (CargoLogObject obj in CargoLogObjects)
                {
                    if (string.Equals(obj.PieceOwner, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        _tempObjects.Add(obj);
                        _resultcount++;
                    }
                }
                if (_tempObjects.Count != 0)
                {
                    AddCargoToDataTable(_tempObjects, _cargoLogHeaders);
                }
            }
            else
            {
                foreach (Unit u in Units)
                {
                    if (string.Equals(u.Unitname, SeachedUnitName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        _tempUnit.Add(u);
                        _resultcount++;
                    }
                }
                if (_tempUnit.Count != 0)
                {
                    AddUnitToDataTable(_tempUnit, _unitInfoHeaders);
                }
            }
        }
        public void AddUnitToDataTable(List<Unit> u, string headers)
        {
            //Add Headers To The Table
            if (headers != null)
            {
                string[] header = headers.Split(',');
                try
                {
                    foreach (string t in header)
                    {
                       Dt.Columns.Add(t, typeof(string));                     
                    }
                }
                catch (DuplicateNameException ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }

            foreach (PointOfContact p in Contacts)
            {
                    if (u.Count != 0 && u[0].Uic == p.Uic)
                    {
                        Dt.Rows.Add(u[0].Unitname, u[0].Uic, p.Firstname, p.Lastname,
                            p.Email, p.Phone, p.Station);
                        u.RemoveAt(0);
                    }
                
            }
            SearchDataGrid.DataSource = Dt;
        }
        public void AddCargoToDataTable(List<CargoLogObject> c, string headers)
        {
            //Add Headers To The Table
            if (headers != null)
            {
                string[] header = headers.Split(',');

                try
                {
                    foreach (string t in header)
                    {
                        if (Dt.Columns.Contains(t))
                        {
                            Dt.Columns.Add("Piece " + t, typeof(string));
                        }
                        else
                        {
                            Dt.Columns.Add(t, typeof(string));
                        }
                    }
                }
                catch (DuplicateNameException ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            foreach (CargoLogObject obj in c)
            {
                Dt.Rows.Add(obj.ManifestTcn, obj.ManifestDepo, obj.ManifestDest,
                    obj.ManifestAsset, obj.ManifestRecBy, obj.Piecetcn,
                    obj.CargoType, obj.PieceId, obj.PieceDesc,
                    obj.PieceOwner, obj.PieceDepo, obj.PieceDest,
                    obj.Drivable, obj.Hazmat, obj.Sensitive,
                    obj.HighVis, obj.Damaged, obj.TrainedPallet,
                    obj.Comments, obj.DateofDepo);
            }
            SearchDataGrid.DataSource = Dt;
        }
        private void btnCloseSearch_Click_1(object sender, EventArgs e)
        {
            Dt.Clear();
            CargoLogObjects.Clear();
            Units.Clear();
            Contacts.Clear();
            Close();
        }
    }
}



