using WebApplication1.Common;

namespace WebApplication1.Model.Entity
{
    public class Employee : IEntity
    {
        public string NAME { get; set; }
        public int SALARY { get; set; }
        public int DEPT_ID { get; set; }
    }
}
