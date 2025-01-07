using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyContactList.Dialogs;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services => 
{
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<MainMenuDialog>();
}).Build();

builder.Start();
Console.Clear();

var menu = builder.Services.GetRequiredService<MainMenuDialog>();
menu.MainMenu();
