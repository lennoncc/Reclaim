# Game Basic Information #

## Summary ##

Our rhythm game follows a storyline, and the ultimate goal is to reclaim the lost kingdom by defeating enemies at each stage. Other rhythm games such as osu! and Beat Saber do not have a storyline; their only goal is just to play the game and pass the level. Our game adds on to that and is unique, because it connects the player to a novel storyline. The overall design of our game also follows a marvelous medieval theme, which allows the player to get the best gameplay experience. With our simple but unique storyline, Reclaim targets a younger age group – elementary/middle schoolers, since the game is easy to follow along and isn’t too overwhelming. This project is feasible, but because of time constraints, it is a little difficult to implement all the stages that we originally planned for. 

## Gameplay Explanation ##

The optimal gameplay strategy is to match the rectangular blocks as closely as possible to maximize your score and avoid dying. The input keys for each of the four blocks are d, f, j, and k which corresponds to the blocks from left to right. During the rhythm game, there will be a red bar that gets displayed to indicate that the enemy is attacking. When the enemy is attacking, the player should switch to defense mode if they're not already defending. Conversely, when the enemy is not attacking, the player would want to be in attack mode. To switch between attack and defense mode, you would press the spacebar. To navigate the player around, you would use the arrow keys.


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

**Lennon Cruz:** I made it so that dialogue generation was dynamic through the utilization of [queues](https://github.com/lennoncc/Reclaim/blob/7012832800e07e38d71ac555b1f0d3038be1ec2f/Assets/Scripts/DialogueManager.cs#L31), which was kind of similar to some of the concepts we learned in Exercise 3. I also helped to link the [slider for volume](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/VolumeController.cs) in the Main Menu to change the volume of the game.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input
**Lennon Cruz:** 
The default input configuration utilizes [WASD](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/CamberMovement.cs) and the Arrow Keys for left and right movement and Spacebar for jump in the sidescrolling parts, and DFJK and Spacebar for the rhythm game parts. DFJK are utilized for hitting notes, and Spacebar is utilized to switch between attack and defense modes. Alongside this, UI elements can be controlled with buttons that are clicked with the mouse pointer, and dialogue boxes can be navigated/skipped through by using the [Spacebar](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/DialogueController.cs). Unity's Input Manager was utilized to get the various inputs working; for example, since key D in WASD during the sidescrolling part conflicted with the key D in DFJK during the rhythm game part, I created new inputs in the input manager so that the rhythm game utilized different inputs from the sidescrolling parts.

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

## Producer


# Sub-Roles

## Audio
**Lennon Cruz:**
My Assets are as follows, and can also be seen in a README.md in the Audio folder:

**Music**

https://www.fesliyanstudios.com/royalty-free-music/downloads-c/8-bit-music/6
prologue_1 - 8 Bit Nostalgia

Following Music by Marllon Silva (xDeviruchi) - https://xdeviruchi.itch.io/8-bit-fantasy-adventure-music-pack

sidescroll_1 - xDeviruchi - Exploring The Unknown

act1_1 - xDeviruchi - And The Journey Begins

act2_1 - xDeviruchi - Prepare For Battle!


**Sound Effects**

https://kasse.itch.io/ui-buttons-sound-effects-pack?download
click_1 - UI_button01.wav

https://freesound.org/people/LittleRobotSoundFactory/sounds/270341/
heal_1 - Pickup_04.wav

https://freesound.org/people/LittleRobotSoundFactory/sounds/270338/
bow_1 - Open_01.wav

https://www.youtube.com/watch?v=br3OzOrARh4
death_1 - Game Over (8-Bit Music)

**Describe the implementation of your audio system.**

The audio system [SoundManager](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/SoundManager.cs) is largely based off SoundManager.cs from Exercise 1. [Modifications](https://github.com/lennoncc/Reclaim/blob/bb3bce343e1de79f0a70d7002a6f947833cb8a97/Assets/Scripts/SoundManager.cs#L41) were made to account for player's preferred audio volume when playing tracks/sfx.

**Document the sound style.** 

When searching for music, we knew our game was going to be in an 8-bit style, so I searched for royalty free chiptune styled music, that was of the fantasy/medieval/adventure genre. I also wanted to find music that was more upbeat in tone as this is a rhythm game; slower songs are harder to work with in terms of fun.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
