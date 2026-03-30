
namespace WeatherApiDemo
{
    public class Program
    {
        public static void Main(string[] args)  
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(o => o.AddPolicy("AllowAll", b =>
                b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            var app = builder.Build();

            app.UseCors("AllowAll"); 

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
