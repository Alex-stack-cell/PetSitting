using System;

namespace APIPetSitting.Models.Abstracts
{
    public abstract class Dashboard
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public float? Score { get; set; }
    }
}
