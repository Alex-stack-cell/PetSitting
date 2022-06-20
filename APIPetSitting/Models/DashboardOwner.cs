using System;

namespace APIPetSitting.Models
{
    public class DashboardOwner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public float? Score { get; set; }
    }
}
