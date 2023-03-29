using System;
using System.ComponentModel.DataAnnotations;

namespace MasterOfCoinsAPI.Models
{
    public abstract class BaseTable
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Inactive { get; set; }
    }
}
