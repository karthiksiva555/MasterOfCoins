using System.ComponentModel.DataAnnotations;

namespace MasterOfCoinsAPI.Models
{
    public class GroupDetails : BaseTable
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
