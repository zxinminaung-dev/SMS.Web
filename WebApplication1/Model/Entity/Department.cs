using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Entity
{
    //[Table("Department")]
    public class Department
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string LOCATION { get; set; }
    }
}
