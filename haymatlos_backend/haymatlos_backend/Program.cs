
using haymatlos_backend.Hubs;
using haymatlos_backend.Services.dbservices;
using haymatlos_backend.Services.userservices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IdatabaseService, DbService>();
builder.Services.AddScoped<IUserService, UserService>(); 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
    endpoints.MapHub<UserHub>("/Users");

});
app.UseHttpsRedirection();
app.MapControllers();
 
app.Run();
