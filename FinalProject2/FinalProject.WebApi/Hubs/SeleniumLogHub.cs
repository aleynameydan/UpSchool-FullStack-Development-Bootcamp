using FinalProject.WebApi.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.WebApi.Hubs;

public class SeleniumLogHub : Hub
{
    //buraya yazılan methodlar clientların çalıştıracağı methodlar -->selenium, console, blazor --> server dışındaki her şey

    public async Task SendLogNotificationAsync(SeleniumLogDto log)
    {
        //istek gönderen kişi harici herkese bu mesajı geç.
        await Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded",log);
    }
}