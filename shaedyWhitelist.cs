using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System.Text.Json;

namespace shaedyWhitelist;

public class shaedyWhitelist : BasePlugin
{
    public override string ModuleName => "shaedy Whitelist";
    public override string ModuleVersion => "1.1.0";
    public override string ModuleAuthor => "shaedy";

    private List<ulong> _allowedSteamIds = new();
    private string _configFilePath = "";

    public override void Load(bool hotReload)
    {
        _configFilePath = Path.Combine(ModuleDirectory, "whitelist.json");
        LoadWhitelist();

        RegisterEventHandler<EventPlayerConnectFull>(OnPlayerConnectFull);
        Console.WriteLine("[shaedyWhitelist] Plugin loaded.");
    }

    private void LoadWhitelist()
    {
        if (!File.Exists(_configFilePath))
        {
            // Create a default config with an example entry
            _allowedSteamIds = new List<ulong> { 76561198000000000 };
            File.WriteAllText(_configFilePath, JsonSerializer.Serialize(_allowedSteamIds, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine("[shaedyWhitelist] Created default whitelist.json - add your SteamID64s there.");
            return;
        }

        try
        {
            string json = File.ReadAllText(_configFilePath);
            _allowedSteamIds = JsonSerializer.Deserialize<List<ulong>>(json) ?? new();
            Console.WriteLine($"[shaedyWhitelist] Loaded {_allowedSteamIds.Count} whitelisted SteamIDs.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[shaedyWhitelist] Failed to load whitelist: {ex.Message}");
            _allowedSteamIds = new();
        }
    }

    private HookResult OnPlayerConnectFull(EventPlayerConnectFull @event, GameEventInfo info)
    {
        var player = @event.Userid;

        if (player == null || !player.IsValid || player.IsBot || player.IsHLTV)
            return HookResult.Continue;

        if (!_allowedSteamIds.Contains(player.SteamID))
        {
            Console.WriteLine($"[shaedyWhitelist] KICKED: {player.PlayerName} ({player.SteamID}) - not whitelisted.");

            Server.NextFrame(() =>
            {
                Server.ExecuteCommand($"kickid {player.UserId} \"This server is private (whitelist only)\"");
            });
        }
        else
        {
            Console.WriteLine($"[shaedyWhitelist] Welcome {player.PlayerName}");
        }

        return HookResult.Continue;
    }
}