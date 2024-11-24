<p align="center">
  <img src="https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2382520/header.jpg?t=1719971377" />
</p>

# Erenshor More SimPlayer Phrases Mod
This mod lets SimPlayers react to certain events with pre-defined phrases that are configureable in the SimPlayerPhrases.json

# Requirements
> [!IMPORTANT]
> Melonloader Version >= 0.6.4 is needed

## Define own Phrases
> [!TIP]
> When you start the game once with the mod installed. And you do not have a `SimPlayerPhrases.json` in your root game directory. It will create you a sample file.

A Phrase in the .json looks like this:
```json
{
  "Phrase": "Congrats %playername% for reaching level %playerlevel%!",
  "Event": 0,
  "ChanceToReact": 0.6
},
```
We will go over every field that we need to define here.

#### Phrase
This defines the text that the SimPlayer will shout. You can use variables to make it more dynamic. Here's a list of them

| **Variable Name** | **Variable Value**                                      |
|-------------------|---------------------------------------------------------|
| %item%            | The name of the last item, that the player received     |
| %questname%       | The name of the last quest, that the player completed   |
| %playername%      | The name of the local player that is currently playing  |
| %playerlevel%     | The level of the local player that is currently playing |

#### Event
This defines WHEN the Phrase will be send into the chat. Here's a list of them

| **Event** | **Value**                             |
|-----------|---------------------------------------|
| 0         | When the Player is leveled up         |
| 1         | When the Player is killed             |
| 2         | When the Player is Revived            |
| 3         | When the Player has completed a quest |
| 4         | When the Player has received an item  |

#### ChanceToReact
This defines the chance in % that the phrase will be sent when the event happens.

* When the value is `1` then there's a `100%` chance that this phrase will be sent when the event happens. (Always)
* When the value is `0` then there's a `0%` chance that this phrase will be sent when the event happens. (Never)

## Example `SimPlayerPhrases.json` File created by ChatGPT
You can see how ChatGPT did a `SimPlayerPhrases.json` file [here](/SimPlayerPhrases.json)

> [!TIP]
> You can download this .json and use it

## Made with MelonLoader
<p align="center">
  <img src="https://melonwiki.xyz/_media/logo.svg" height="20%" width="20%" />
</p>
The Developement for this Mod has been made with MelonLoader which is also required to use this mod.

## How to Install
1. [Install MelonLoader](https://melonwiki.xyz/#/?id=automated-installation) 
2. Download the latest .zip of the Mod in the [releases](https://github.com/Lenzork/Erenshor-Achievement-Mod/releases)
3. Extract all Files that are in the Zip Folder into your Erenshor Folder.
4. Start the Game and Enjoy!

> [!TIP]
> To ensure that the Installation has been done right. Check if the `Newtonsoft.Json.dll` is located where your Erenshor.exe is located at.
> Also check if the Mods folder has the `Erenshor-More-SimPlayer-Phrases-Mod.dll` in it.
