using Microsoft.EntityFrameworkCore;
using u24987906_Practical8.Data;
using u24987906_Practical8.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HospitalDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
    context.Database.EnsureCreated();

    
    if (!context.Equipments.Any())
    {
        // 1. Create the 5 Equipment Items
        var equipments = new List<Equipment>
        {
            new Equipment { equipmentName = "Patient Monitor", equipmentType = "Monitoring", purchaseDate = new DateTime(2025, 3, 15) },
            new Equipment { equipmentName = "Ventilator", equipmentType = "Life Support", purchaseDate = new DateTime(2024, 7, 10) },
            new Equipment { equipmentName = "ECG Machine", equipmentType = "Monitoring", purchaseDate = new DateTime(2025, 1, 20) },
            new Equipment { equipmentName = "Ultrasound Machine", equipmentType = "Imaging", purchaseDate = new DateTime(2024, 11, 5) },
            new Equipment { equipmentName = "Infusion Pump", equipmentType = "Medication", purchaseDate = new DateTime(2025, 6, 18) }
        };
        context.Equipments.AddRange(equipments);
        context.SaveChanges(); 

        // 2. Create the 10 Maintenance Records
        var records = new List<MaintenanceRecord>
        {
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 1, 15), Description = "Battery replaced", maintenanceCost = 1500.00m, EquipmentID = equipments[0].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 7, 20), Description = "System inspection", maintenanceCost = 800.00m, EquipmentID = equipments[0].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 2, 10), Description = "Annual service", maintenanceCost = 2500.00m, EquipmentID = equipments[1].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 8, 5), Description = "Filter replaced", maintenanceCost = 1200.00m, EquipmentID = equipments[1].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 3, 12), Description = "Electrical inspection", maintenanceCost = 950.00m, EquipmentID = equipments[2].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 8, 18), Description = "Calibration completed", maintenanceCost = 1100.00m, EquipmentID = equipments[2].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 1, 25), Description = "Probe inspection", maintenanceCost = 1800.00m, EquipmentID = equipments[3].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 6, 30), Description = "Software update", maintenanceCost = 750.00m, EquipmentID = equipments[3].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 2, 5), Description = "Pump calibration", maintenanceCost = 650.00m, EquipmentID = equipments[4].equipmentID },
            new MaintenanceRecord { maintenanceDate = new DateTime(2026, 7, 15), Description = "Battery replaced", maintenanceCost = 500.00m, EquipmentID = equipments[4].equipmentID }
        };
        context.MaintenanceRecords.AddRange(records);
        context.SaveChanges(); 
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
