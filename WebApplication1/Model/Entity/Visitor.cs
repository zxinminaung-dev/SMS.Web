using WebApplication1.Common;

namespace WebApplication1.Model.Entity
{
    public class Visitor : IEntity
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string BusinessNumber { get; set; }
        public string BusinessEmail { get; set; }
        public string Designation { get; set; }
        public string LicensePlate { get; set; }
        public string NRICNumber { get; set; }
        public bool IsStayHome { get; set; }    
        public bool HasContact { get; set; }
        public bool HasFluSymptom { get; set; }
    }
}
