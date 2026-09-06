using System;
using System.ComponentModel.DataAnnotations;

namespace u24987906_Practical8.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int MaintenanceID { get; set; }
        public DateTime maintenanceDate { get; set; }
        public string Description { get; set; }
        public decimal maintenanceCost { get; set; }

        public int EquipmentID { get; set; }

        public virtual Equipment Equipment { get; set; }

    }
}
