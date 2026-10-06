var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);
var itUser = builder.AddParameter("it-user"); // Discord snowflake of the on-call IT person

// laya priority classifier — bot falls back gracefully when this is down
builder.AddPythonApp("laya-classifier", "../../../../laya-playground", "server.py")
    .WithVirtualEnvironment(".venv");

builder.AddProject("bot-discord", "../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken)
    .WithEnvironment("Discord__ItUser", itUser);

builder.Build().Run();
