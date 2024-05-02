using BlazorPushGroupLab.Data;
using BlazorPushGroupLab.Pages;
using Microsoft.AspNetCore.ResponseCompression;

namespace BlazorPushGroupLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<RoomService>();
            //#SingalR#
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                      new[] { "application/octet-stream" });
            });

            var app = builder.Build();
            //#SingalR#
            app.UseResponseCompression();
            app.MapHub<RoomHub>("/roomhub");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();


            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
