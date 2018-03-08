//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			Container
//
//			File:				Container.cs
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
//          Other Files included: CargoPiece.cs, Container.cs, CShipment.cs, 
//          Person.cs, PointOfContact.cs, Program.cs, RIDSDriver.cs, Unit.cs, 
//          User.cs  	
//*****************************************************************************
using System;

namespace RIDS
{
    public class Container : CargoPiece
    {
        private string Mdescription { get; set; }
        private bool MIsTrained { get; set; }

        public string Description
        {
            get { return Mdescription; }
            set { Mdescription = value; }
        }
        public bool IsTrained
        {
            get { return MIsTrained; }
            set { MIsTrained = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public Container()
        {
            Mdescription = Description;
            MIsTrained = IsTrained;
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public Container(string tcn, string cargotype, string idNumber, 
            string unitowner, string destination,string deposition, 
            string description,bool isTrained, bool isSensitive, 
            bool isDamaged, bool isHazmat,bool isHighVis, string comments,
            DateTime dateTime)
            : base(tcn, cargotype, unitowner, idNumber, destination, deposition
                  ,isSensitive, isDamaged, isHazmat,isHighVis, comments, 
                  dateTime)
        {
            Description = description;
            IsTrained = isTrained;
        }
    }
}

