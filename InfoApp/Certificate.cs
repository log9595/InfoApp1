using System;

namespace InfoApp
{
    public class Certificate
    {
        public int Id { get; set; }
        public string NumbContainer { get; set; }
        public string FIO { get; set; }
        public string PostName { get; set; }
        public string OrgStructName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
