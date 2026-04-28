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

## Support

If you find a bug, have a feature request, or something isn't working as expected, feel free to [open an issue](../../issues). I'll take a look when I can.

Custom plugins are available on request, potentially for a small fee depending on scope. Reach out via an issue or at access@shaedy.de.

> Note: These repos may not always be super active since most of my work happens in private repositories. But issues and requests are still welcome.

## Donate

If you want to support my work: [ko-fi.com/shaedy](https://ko-fi.com/shaedy)
