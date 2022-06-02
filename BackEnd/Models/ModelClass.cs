using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CardNumber { get; set; }
        public string Name { get; set; }
        public string BloodGroup { get; set; }
        public string RoomNumber { get; set; }
        public string Block { get; set; }
        public string Session { get; set;}
        public string Year { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
    }
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SessionNumber { get; set; }
        public string SessionName { get; set; }
        public bool FirstOfMonth { get; set; }
        public string ManagerName { get; set; }
        public int CardNumber { get; set; }
        public virtual List<Purchage> Purchages { get; set; }
        public virtual List<FundCollection> FundCollection { get; set; }
    }

    public class Purchage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNumber { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Dated { get; set; }
        public string Items { get; set; }
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [ForeignKey("Session")]
        public int SessionNumber { get; set; }
        public virtual Session Session { get; set; }
    }

    public class FundCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNumber { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        [ForeignKey("Session")]
        public int SessionNumber { get; set; }
        public virtual Session Session { get; set; }

    }
}
