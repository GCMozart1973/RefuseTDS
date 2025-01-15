using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Entities
{
    public class RefuseLocation
    {
        [Key]
        public long LocationID { get; set; }
        public long CompanyID { get; set; }
        public long RegionID { get; set; }
        public string? LocationNo { get; set; }
        public string? LocationName { get; set; }
        public string? LocationAddress { get; set; }
        public string? LocationCity { get; set; }
        public string? LocationState { get; set; }
        public string? LocationZipCode { get; set; }
        public long? CreatedBy  { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}