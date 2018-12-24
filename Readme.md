Chaos Glitch Mod - v 1.5 by Apache Thunder.
Credits to KyleTheScientist, Zatherz, Abe Clancy, and PlaguedPixel for their help/code for improving/making certain features possible.


Features:

1. Chaos Mode. This mode is accessed via the "chaos" command. Sub commands for this mode are as follows:

pots - This mode makes random enemies spawn from pots/other destructible objects.
walls - This mode guarantees a wall mimic in every room on a floor.
walls_extreme - This mode does the same as walls, but also makes it so more then one mimic can appear in a room. (starting on the second chamber).
walls_ultra - This mode is same as extreme, only adds bonus enemy spawns for each new combat room a player enters.
tinybigmode - This mode enables/disables random big/small enemies. :D
normal - This mode enables both pots and walls modes.
extreme - This mode enables pots and walls_extreme if you really want a challenge. :D
ultra - This mode is same as extreme, only adds bonus enemy spawns for each new combat room a player enters. Higher floors ups chance of a bonus enemy spawn by about 10% to 20%
debug - This enables debug information to be displayed in the console regarding walls_extreme mode.
reset- This disables all chaos modes.

2. Glitch Mode. This mode applies the glitch chest shader to enemies or objects. The sub commands are as follows:

enemies - This applies the glitch shaders only to enemies. Please use this command before loading a level to ensure all enemies are affected properly.
all - This applies the glitch shader to almost all objects. Most floor tiles/wall tiles not effected however. For performance reasons, this mode will not apply the shader to the player sprite. Note that this mode may cause FPS dips. Use with care.
randomizer - Disabled/Enables randomizer for glitch enemies/objects. When using glitch all or glitch enemies commands, enemies now only have a chance to be glitched instead of all of them being glitched. Use this command to turn on or off that feature.
test - This does a one time glitch shader effect on any loaded objects in the room/in nearby rooms.
reset - This disables all glitch modes. Some modes may require the next floor to be loaded to fully clear.

There is also a bonus mod integrated into this mod. "DungeonFlow". This is a slight reworking of the old Anywhare mod to work with AG&D. Note that most floors can't be loaded with this anymore. But this can be used to load Bossrush levels, the glitch chest floor and a NPCParadise test room. RocketMod does not currently have this feature. ;)

Command syntax is mostly the same as old anywhere mod. Use "load_dungeonflow help" in console to get help on how to use this command.

Also included is a separate ZIP file containing a version of the mod with chaos extreme mode enabled by default. It can still be disabled via chaos reset like normal. 

Misc changes since 1.0 version of the mod:

1. Ultra Mode added. Use 'chaos ultra' to enable it. This mode enables an extra random enemy to spawn in various rooms. This is different from pots and stuff since they will already be in the room when you enter it. They also have a different enemy list pool with more difficult enemies. Pots/Destructible spawn mainly small enemies that don't shoot at you. (mostly. :P )\
2. A few new commands added. Use "glitch" or "chaos" to see the sub commands for each.
3. Bonus Enemies now use new code for spawning. (They now spawn using code similar to MTG's spawn command) This should resolve any remaining issues of bonus enemies being stuck in walls. Also expanded pool of enemies for bonus enemies.
4. Added new feature: TinyBig Mode. Enabled with normal, extreme, ultra modes and can be enabled/disabled individually via new console command "chaos tinybigmode".
This new mode causes random enemies to be smaller or larger then normal. Even some bosses can be affected. (but not all. Most added to black list as some cause issues when resized)
5. All enemy spawn pools use GUIDs and are spawned via GetOrLoadByGUID now. Updating MTG should no longer be necessary to see all the newer AG&D enemies spawn. Note however this mod still requires post AG&D version of ETG though.
6. Some immune enemies like lead cubes, flesh cubes, removed from bonus enemy spawn pool to avoid potential soft locks with certain room designs.


Compiling and versions of Enter the Gungeon required:

This source code uses C#. Visual Studio 2015 or newer recommended.
This mod is intended for post AG&D versions of Enter the Gungeon. Please ensure your game is up to date before attempting to use this mod.
