using System;

namespace contactManagement.Model
{
    public class Contact
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Phone  { get; set; }
        public bool Status { get; set; }
    }
}
