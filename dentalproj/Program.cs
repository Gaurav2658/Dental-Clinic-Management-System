using DataAccessLibrary;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Repository.ComplaintMasterRepository;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<UserMasterRepository, UserMasterRepository>();
builder.Services.AddScoped<ComplaintMasterRepository, ComplaintMasterRepository>();
builder.Services.AddScoped<AdviceMasterRepository,AdviceMasterRepository>();
builder.Services.AddScoped<ObservationMasterRepository, ObservationMasterRepository>();
builder.Services.AddScoped<MedicineMasterRepository, MedicineMasterRepository>();
builder.Services.AddScoped<ServiceMasterRepository, ServiceMasterRepository>();
builder.Services.AddScoped<ShadeMasterRepository, ShadeMasterRepository>();
builder.Services.AddScoped<AttachmentMasterRepository, AttachmentMasterRepository>();
builder.Services.AddScoped<UnitMasterRepository, UnitMasterRepository>();
builder.Services.AddScoped<CategoryMasterRepository, CategoryMasterRepository>();
builder.Services.AddScoped<SupplierMasterRepository, SupplierMasterRepository>();
builder.Services.AddScoped<PurchaseMasterRepository, PurchaseMasterRepository>();
builder.Services.AddScoped<ItemMasterRepository, ItemMasterRepository>();
builder.Services.AddScoped<ItemAssignMasterRepository, ItemAssignMasterRepository>();
builder.Services.AddScoped<AppointmentMasterRepository, AppointmentMasterRepository>();
builder.Services.AddScoped<PatientMasterRepository, PatientMasterRepository>();
builder.Services.AddScoped<CaseMasterRepository,CaseMasterRepository>();
builder.Services.AddScoped<AppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<CaseMasRepository, CaseMasRepository>();










builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserMaster}/{action=GetAllUsers}/{id?}");

app.Run();