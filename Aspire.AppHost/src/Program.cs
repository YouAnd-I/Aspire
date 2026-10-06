var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);
var itUser = builder.AddParameter("it-user");
var cloudflareAccount = builder.AddParameter("cloudflare-account");
var cloudflareToken = builder.AddParameter("cloudflare-token", secret: true);

builder.AddProject("bot-discord", "../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken)
    .WithEnvironment("Discord__ItUser", itUser)
    .WithEnvironment("Cloudflare__AccountId", cloudflareAccount)
    .WithEnvironment("Cloudflare__ApiToken", cloudflareToken);

builder.Build().Run();
