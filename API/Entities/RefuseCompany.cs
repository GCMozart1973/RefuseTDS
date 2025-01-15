namespace Api.Data.Entities
{
    public class RefuseCompany
    {
        public long ID  { get; set; }
        public string? RefuseCompanyID { get; set; }
        public string? RefuseCompanyName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public double? Zip { get; set; }
        public string? Country { get; set; }
        public long? FTLDealerID { get; set; }
        public int? RegionID { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}