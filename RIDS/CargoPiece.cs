//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			CargoPiece
//
//			File:				CargoPiece.cs
//
//			Student:			Jarryd Lapp
//
//			Course Name:		COSC 4260
//
//			Date:				April 11th, 2017
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
    public class CargoPiece
    {
        private string MIdNumber { get; set; }
        private string MDestination { get; set; }
        private  string MCargotype { get; set; }
        private string MUnitowner { get; set; }
        private string MDeposition { get; set; }
        private  DateTime MDatetime { get; set; }
        private string Mtcn { get; set; }
        private string MComments { get; set; }
        private bool MIsSensitive { get; set; }
        private bool MIsDamaged { get; set; }
        private bool MIsHazmat { get; set; }
        private bool MIsHighVisability { get; set; }

        public string IdNumber
        {
            get { return MIdNumber; }
            set { MIdNumber = value; }
        }
        public string Destination
        {
            get { return MDestination; }
            set { MDestination = value; }
        }
        public string Cargotype
        {
            get { return MCargotype; }
            set { MCargotype = value; }
        }
        public string Unitowner
        {
            get { return MUnitowner;}
            set { MUnitowner = value; }
        }
        public string Deposition
        {
            get { return MDeposition; }
            set { MDeposition = value; }
        }
        public DateTime Datetime
        {
            get { return MDatetime; }
            set { MDatetime= value; }
        }
        public string Tcn
        {
            get { return Mtcn; }
            set { Mtcn = value; }
        }
        public string Comments
        {
            get { return MComments;}
            set { MComments = value; }
        }
        public bool IsSensitive
        {
            get { return MIsSensitive;}
            set { MIsSensitive = value; }
        }
        public bool IsDamaged
        {
            get { return MIsDamaged;}
            set { MIsDamaged = value; }
        }
        public bool IsHazmat
        {
            get { return MIsHazmat;}
            set { MIsHazmat = value; }
        }
        public bool IsHighVisability
        {
            get { return MIsHighVisability;}
            set { MIsHighVisability = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public CargoPiece()
        {
            MIdNumber = IdNumber;
            MDestination = Destination;
            MDeposition = Deposition; 
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public CargoPiece(string tcn, string cargotype, string unitowner, 
            string idNumber, string destination, string deposition, 
            bool isSensitive, bool isDamaged,bool isHazmat, bool isHighVis,
            string comments, DateTime dateTime)
        {
            Tcn = tcn;
            Cargotype = cargotype;
            IdNumber = idNumber;
            Destination = destination;
            Unitowner = unitowner;
            Deposition = deposition;
            Comments = comments;
            IsSensitive = isSensitive;
            IsDamaged = isDamaged;
            IsHazmat = isHazmat;
            IsHighVisability = isHighVis;
            Datetime = dateTime;
        }
    }
}
