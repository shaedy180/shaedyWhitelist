# shaedy Whitelist

A CounterStrikeSharp plugin that restricts server access to whitelisted SteamIDs.

## Features

- Only allows players whose SteamID64 is in the whitelist to join
- Automatically kicks non-whitelisted players on connect
- Loads the whitelist from a JSON config file
- Default config is auto-generated on first run

## Installation

Drop the plugin folder into your CounterStrikeSharp `plugins` directory.

## Configuration

Edit `whitelist.json` in the plugin folder. It's a simple array of SteamID64 values:

```json
[
  76561198000000001,
  76561198000000002,
  76561198000000003
]
```

Find your SteamID64 at [steamid.io](https://steamid.io).
