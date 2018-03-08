//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			CargoShipment
//
//			File:				CShipment.cs
//
//			Student:			Jarryd
//
//			Course Name:		COSC 4260
//
//			Date:				April 9th, 2017
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

namespace RIDS
{
    public class CShipment
    {
        private string MTcn { get; set; }
        private string MDeposition { get; set; }
        private string MAsset { get; set; }
        private string MDestination { get; set; }
        private string MPieceTcn { get; set; }
        private string MRecievedBy { get; set; }

        public string Tcn
        {
            get { return MTcn;}
            set { MTcn = value; }
        }
        public string Deposition
        {
            get { return MDeposition; }
            set { MDeposition = value; }
        }
        public string Asset
        {
            get { return MAsset; }
            set { MAsset = value; }
        }
        public string Destination
        {
            get { return MDestination; }
            set { MDestination = value; }
        }
        public string PieceTcn
        {
            get { return MPieceTcn; }
            set { MPieceTcn = value; }
        }
        public string RecievedBy
        {
            get { return MRecievedBy; }
            set { MRecievedBy = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public CShipment()
        {
            MTcn = Tcn;
            MDestination = "";
            MAsset = "";
            MDestination = "";
            MPieceTcn = "";
            MRecievedBy = "";
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public CShipment(string tcn, string deposition, string asset, 
            string destination, string ptcn, string recievedby)
        {
            Tcn = tcn;
            Destination = destination;
            Asset = asset;
            Deposition = deposition;
            PieceTcn = ptcn;
            RecievedBy = recievedby;
        }
        //*********************************************************************
        // AddCargoPiece Function
        // This Function Creates a CargoPiece Object used to link
        // CargoShipments to CargoPieces
        //********************************************************************* 
        public CargoPiece AddCargoPiece(string id, string destination, 
            string cargotype, string unitowner, string depo, string tcn, 
            string comments, bool issensitive, bool isdamaged, bool ishazmat, 
            bool ishighvis, DateTime dateTime)
        {
            CargoPiece cargoPiece = new CargoPiece(tcn, cargotype, unitowner, 
                id, destination, depo, issensitive,isdamaged, ishazmat, 
                ishighvis, comments, dateTime);

            return cargoPiece;
        }
    }
}
