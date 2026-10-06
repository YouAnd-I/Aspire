var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);
var itUser = builder.AddParameter("it-user"); // Discord snowflake of the on-call IT person
var cloudflareAccount = builder.AddParameter("cloudflare-account"); // Workers AI account id
var cloudflareToken = builder.AddParameter("cloudflare-token", secret: true);

// Priority classification runs on Cloudflare Workers AI (clef) — nothing local
// to keep running. The bot falls back to urgent when the API is unreachable.
builder.AddProject("bot-discord", "../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken)
    .WithEnvironment("Discord__ItUser", itUser)
    .WithEnvironment("Cloudflare__AccountId", cloudflareAccount)
    .WithEnvironment("Cloudflare__ApiToken", cloudflareToken);

builder.Build().Run();
