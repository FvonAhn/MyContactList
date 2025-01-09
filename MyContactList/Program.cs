using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using MyContactList.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("contact.json"));
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MainMenuDialog>();

var service = serviceCollection.BuildServiceProvider();
var mainMenuDialogs = service.GetRequiredService<MainMenuDialog>();

mainMenuDialogs.MainMenu();