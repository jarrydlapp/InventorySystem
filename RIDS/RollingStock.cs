//*****************************************************************************
//
//			Project Title:		Rapid Inventory Deployment System		
//	
//			Class Name:			RollingStock
//
//			File:				RollingStock.cs
//
//			Student:			Jarryd
//
//			Course Name:		COSC 4260
//
//			Date:				March 24th 2017
//
//
//			Description: this program is a cargo tracking software to be used
//          during military training exercises to track and report cargo 
//          within the training area.
//
//           Other Files included: CargoPiece.cs, Container.cs, CShipment.cs, 
//           Person.cs, PointOfContact.cs, Program.cs, RIDSDriver.cs, Unit.cs, 
//           User.cs  	
//*****************************************************************************
using System;

namespace RIDS
{
    public class RollingStock : CargoPiece
    {
        private string MDescription { get; set; }
        private bool MIsDrivable { get; set; }

        public string Description
        {
            get { return MDescription; }
            set { MDescription = value; }
        }
        public bool IsDrivable
        {
            get { return MIsDrivable; }
            set { MIsDrivable = value; }
        }
        //*********************************************************************
        // Default Constructor
        //*********************************************************************
        public RollingStock()
        {
            MDescription = Description;
            MIsDrivable = IsDrivable;
        }
        //*********************************************************************
        // Constructor
        //*********************************************************************
        public RollingStock(string tcn, string cargotype, string unitowner,
            string idNumber, string description,
            bool isDrivable, string destination, string deposition,
            bool isSensitive, bool isDamaged, bool isHazmat,
            bool isHighVis, string comments, DateTime dateTime)
            : base( tcn, cargotype, unitowner, idNumber, destination, 
                deposition, isSensitive, isDamaged, isHazmat,
                isHighVis, comments, dateTime)
        {
            Description = description;
            IsDrivable = isDrivable;
        }
    }
}
   
