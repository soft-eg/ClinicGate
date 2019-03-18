using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicGate.Core.Models
{
 

    public class Patient : BaseEntity
    {
         
        #region Basic

        public string PasNumber { get; set; }

        public string Forenames { get; set; }
         
        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

       
        public Sex SexCode { get; set; }

        public string HomeTelephoneNumber { get; set; }


        #endregion
        #region NextOfKin
        public string NokName { get; set; }

        public RelationshipCode NokRelationshipCode { get; set; }


        public string NokAddressLine1 { get; set; }
        public string NokAddressLine2 { get; set; }
        public string NokAddressLine3 { get; set; }


        public string NokPostcode { get; set; }

        #endregion
        #region GpDetails
        public string GpCode { get; set; }

        public string GpSurname { get; set; }

        public string GpInitials { get; set; }

      
        public string GpPhone { get; set; }

        #endregion

        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
