namespace u24987906_Practical8.Models
{
    public class Equipment
    {
        public int equipmentID { get; set; }
        public string equipmentName { get; set; }
        public string equipmentType { get; set; }
        public DateTime purchaseDate { get; set; }

        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    }
}
