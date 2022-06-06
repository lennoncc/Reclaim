# Game Basic Information #

## Summary ##

Our rhythm game follows a storyline, and the ultimate goal is to reclaim the lost kingdom by defeating enemies at each stage. Other rhythm games such as osu! and Beat Saber do not have a storyline; their only goal is just to play the game and pass the level. Our game adds on to that and is unique, because it connects the player to a novel storyline. The overall design of our game also follows a marvelous medieval theme, which allows the player to get the best gameplay experience. With our simple but unique storyline, Reclaim targets a younger age group – elementary/middle schoolers, since the game is easy to follow along and isn’t too overwhelming. This project is feasible, but because of time constraints, it is a little difficult to implement all the stages that we originally planned for. 

## Gameplay Explanation ##

The optimal gameplay strategy is to match the rectangular blocks as closely as possible to maximize your score and avoid dying. The input keys for each of the four blocks are d, f, j, and k which corresponds to the blocks from left to right. During the rhythm game, there will be a red bar that gets displayed to indicate that the enemy is attacking. When the enemy is attacking, the player should switch to defense mode if they're not already defending. Conversely, when the enemy is not attacking, the player would want to be in attack mode. To switch between attack and defense mode, you would press the spacebar. To navigate the player around, you could either use the WASD keys or the arrow keys.


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
**Jimmy Trinh**
The UI is present in every aspect of our game. From the start, the Main Menu allows players to Play, Quit, or control options. I implemented UI elements such as a volume slider to achieve a modern look. Within the game, I implemented a scalable Dialogue Box Manager. The dialogue box is able to be used in any scene, and can take in text input to generate the dialogue. There are animation keyframes to have the dialoguebox go off and on the screen when it should. There is a way to continue dialogue and the text scrolls like a typewriter so it isn't just static text reading. Furthermore, during gameplay, UI elements such as health, enemy health, and score are being used. And upon player fail, there are UI elements that allow them to replay.

## Movement/Physics
**Matthew Tom:**
Working alongside input, the initial movement physics in the sidescroller sequences were based off of CaptainController.cs from Exercise 1. However, when translating movement to Camber's functionality, the animations were much more janky and inconsistent, with the impact of not looking natural at all. [CamberMovement.cs](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/CamberMovement.cs) was designed by me to be retweaked from CaptainController.cs in order to focus on movement using a Vector2 function. For different techniques of horizontal movement, I referenced [GAME GLiTcH's 2D Movement Tutorial](https://www.youtube.com/watch?v=fcKGqxUuENk) on the differences between AddForce and Velocity. While experimenting between the two, Velocity produced a much more natural, human-like movement that was not based on acceleration and kept at a constant pace, whereas AddForce was focused on "vehicular" styled-movement, where it has momentum and acceleration build up. As a result, [Camber's movement is based on velocity](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/CamberMovement.cs#L46). There is also a jump function for Camber that also has [simulated gravity and weight to it](https://github.com/lennoncc/Reclaim/blob/3c332ba763a4ab98e13595f991b2f65f39426e14/Assets/Scripts/CamberMovement.cs#L48-L51) with the choice of using AddForce to have the effect of acceleration and momentum deliberately.

The next part was focusing on how the arrows that Camber fires would be implemented, as well as how the lasers would appear from the enemies Camber faced. [For the arrow prefab](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/BowArrowBehavior.cs), a behavior script was implemented to to dictate its movement in a constant direction towards the enemy and would destroy itself upon colliding with the enemy. [This would be instantiated](https://github.com/lennoncc/Reclaim/blob/e8ff2105a4fc96ede26990727a71b87f82f28dcb/Assets/Scripts/BowArrowController.cs) and [invoked in PlayerController.cs](https://github.com/lennoncc/Reclaim/blob/e8ff2105a4fc96ede26990727a71b87f82f28dcb/Assets/Scripts/PlayerController.cs#L146) in order to sync it up with Camber's firing animation. While a similar implementation was meant to be used for the enemy lasers, the choice was made to just make the enemy lasers appear and disappear as a [sprite when the enemy was attacking](https://github.com/lennoncc/Reclaim/blob/3c332ba763a4ab98e13595f991b2f65f39426e14/Assets/Scripts/EnemyController.cs#L60). It isn't quite as smooth or natural, but it still serves its purpose of being a visual indication. Potential improvements would have been to add flinching animations to each character when they were hit, but could have ultimately been a distracting factor during gameplay.

## Animation and Visuals

**Assets used for Backgrounds:**  
[Forest](https://anokolisa.itch.io/high-forest-assets-pack)  
License: "Legacy Fantasy High Forest" by Anokolisa  
[Demon Woods](https://aethrall.itch.io/demon-woods-parallax-background)  
License: "Demon Woods Parallax Background" by Aethrall  
[Village Props](https://cainos.itch.io/pixel-art-platformer-village-props)  
License: "Pixel Art Platformer Village Props" by Cainos  
[Castle](https://anokolisa.itch.io/heros-journey-castle-hall)  
License: "Hero's Journey Castle Hall" by Anokolisa  

Animations and visuals were done on the Piskel browser site, allowing for both sketches and frame-by-frame animations of each of the characters we had in the game. Our game consisted of four main characters, Camber, the Mage Captain, the Witch, and King Elec.  
A major factor in the game was to have the art to stay consistent when creating each level, including the external assets used for the background. As such, I decided to use a 16-bit retro style for the game environment, in agreement with Audio Design and Game Feel to use 8-bit music to create an immersive effect within the game.  
Overall, Camber's gameplay was comprised of 10 animation clips, while each enemy had 2 animation clips, one for being Idle, and another for Attacking.  
The animation clips themselves were comprised from anywhere between 5 to 20 frames depending on how complex the animation was (e.g Camber walking).  
The state machines shown below show how actions were determined by using Boolean parameters in order to tell the animator which state to transition to next.  
Camber:  
![image](https://drive.google.com/uc?export=view&id=1JKCk8P1WSR9F8gYvaXmJXFhbb2WbCGF3)  
  
General Enemy:  
![image](https://drive.google.com/uc?export=view&id=10opyI5vavvKgy0Azqf8gkWlcuyOOsOc3)  

In addition to the animations and visual, the background used a [Parallax.cs](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/Parallax.cs) script similar to the one used in Exercise 1 in addition to coding implementations made in [PlayerController.cs](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/PlayerController.cs) and [EnemyController.cs](https://github.com/lennoncc/Reclaim/blob/bbaa894956cffaeffc3c6ba49dcff9231cfff9aa/Assets/Scripts/EnemyController.cs) in order to set and reset booleans listed in the state machine parameters in order for the state transitions to occur.

In addition, the visual style guide for the character design and animations shown below:  
[Visual Style Guide](https://docs.google.com/document/d/1BTymkhHpYFkGf392tWce5TPe7hf9extUBVgBbXq5NlM/edit?usp=sharing)

## Input
**Lennon Cruz:** 
The default input configuration utilizes [WASD](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/CamberMovement.cs) and the Arrow Keys for left and right movement and Spacebar for jump in the sidescrolling parts, and DFJK and Spacebar for the rhythm game parts. DFJK are utilized for hitting notes, and Spacebar is utilized to switch between attack and defense modes. Alongside this, UI elements can be controlled with buttons that are clicked with the mouse pointer, and dialogue boxes can be navigated/skipped through by using the [Spacebar](https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/DialogueController.cs). Unity's Input Manager was utilized to get the various inputs working; for example, since key D in WASD during the sidescrolling part conflicted with the key D in DFJK during the rhythm game part, I created new inputs in the input manager so that the rhythm game utilized different inputs from the sidescrolling parts.

**Add an entry for each platform or input style your project supports.**

## Game Logic
**Angelina Vu**
Rhythm Game: For the rhythm part of the game, we followed this tutorial (https://youtu.be/cZzf1FQQFA0) to get a basic version of our game working. Similar to classic rhythm games, we have four different "notes" that fall from the sky that the player must match the input for using the dfjk keys on their keyboard. The buttons and falling notes are controlled here:

https://github.com/lennoncc/Reclaim/blob/7a4137f3d598ad8bbac0d6dd09eecde76a873909/Assets/Scripts/ButtonController.cs 

https://github.com/lennoncc/Reclaim/blob/main/Assets/Scripts/NoteObject.cs

https://github.com/lennoncc/Reclaim/blob/7a4137f3d598ad8bbac0d6dd09eecde76a873909/Assets/Scripts/NoteController.cs

Depending on how accurate the player times the hits 
(miss, ok, good, perfect), they will be rewarded more points.
![image](https://user-images.githubusercontent.com/37753647/172221400-cecd518c-d3af-4cb7-ac8d-12f0e7f071cd.png)


Game Manager: https://github.com/lennoncc/Reclaim/blob/7a4137f3d598ad8bbac0d6dd09eecde76a873909/Assets/Scripts/GameManager.cs 

Score System: stars
Combat System: toggle, multiplier, heal, attacks, update bars
Player Controller:
Enemy Controller:
Bar controller:
Lose/Win Logic:
Arrow factory:

**Document what game states and game data you managed and what design patterns you used to complete your task.**

## Producer
**Ferica Ting:** 
As producer, I facilitated team meetings and organized a master task list that lists out things to do for each part of the project. Based on the progress I gauge from team meetings, I assigned and divided the tasks by day for each role. 

Master task list: https://docs.google.com/document/d/1qWD-5el6uZG7cLrMdEkR3v5YtZmKVY-BncE4M4HeELc/edit?usp=sharing

Weekly/scheduled task list:
https://docs.google.com/document/d/1noumZGm8JTSRwwNUEN3i5zEBxNGPvAYrRijhTiqgklE/edit?usp=sharing

## Level Design
**Anthony Vu:**

The level designer was a role made up by us. Overall, my task was to come up the levels and the mechanics within the level. First, I designed the layout of each level and where each object should be on the screen. I made a rough sketch based on the artwork that was given to me at the time.
![image](https://i.imgur.com/jUD7gK4.png)  

The bulk of my tasks was in actually charting the rhythm aspect of the game. I decided where, when, and how fast each note falls. I had to listen to the music multiple times to get a feel of what the music is like. I then used a metronome to figure out the BPM (Beats per Minute) of each song. After all of that setup, I mapped out where and when each note should fall based on the song and its beat. I did this in a .txt file as you can see [here.](https://github.com/lennoncc/Reclaim/blob/6f58e883a3b49b89e7ddc93c49e2e161d7512e0e/Assets/Resources/Prologlevel.txt#L1) The first number in each line is the index of the note, ie 0 is the most left and 3 is the most right. The second number is the time in milisecconds that the note should be instantiated.

In terms of actual code, I wrote a majority of ArrowScheduler.cs. I created the ArrowSpecs struct, which holds the neccessary information needed to instantiate each note, such as the position and the time it needs to be instantiated. I parsed through my level text files to obtain the neccessary information [here.](https://github.com/lennoncc/Reclaim/blob/6f58e883a3b49b89e7ddc93c49e2e161d7512e0e/Assets/Scripts/ArrowScheduler.cs#L27)

After parsing through the file, I pushed each of the ArrowSpecs into a queue so that it would be easy to take stuff out later on. This process was very similar to exercise 4 when scheduling the projectiles. I had a timer that kept track of the time that has elapsed since the beginning of the song and instantiate the next arrow in the queue if the time is right. The code is [here.](https://github.com/lennoncc/Reclaim/blob/6f58e883a3b49b89e7ddc93c49e2e161d7512e0e/Assets/Scripts/ArrowScheduler.cs#L63)


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

[Gameplay Test Results](https://docs.google.com/document/d/1IWK-ffmyFXmgQgZxkubBjRLW1HUEBvl414KBRuQF7AM/edit?usp=sharing)

**Judy Zhang:**  
Through gameplay testing with 10 individuals, we discovered that several difficulties that the players faced while playing the game.
First and foremost, we initially did not include instructions in the game to determine how the players would react and see which controls were more intuitive.  
We quickly discovered that WASD or the arrow keys were well-known between the majority of the players during the platformer portion of the game.  
However, the playtesters were largely confused about which direction to head towards, resulting in some of them heading left to absolutely nothing. While we still wanted the element of exploration within the game, we decided to add an invisible barrier to the left of the gameplay area to prevent the player from infinitely heading towards the left of the game. We also did not want players to get confused by the invisible barrier, which resulted in a cat blocking your way :).  
In addition, some playtesters found it difficult to know when to use the spacebar to attack or defend during the rhythm/combat portion of the game. In an effort to mitigate the confusion, the team used a red overlay over the rhythm game whenever the enemy was attacking to signal the playtester to switch to defense mode.  
Finally, the falling arrows and matching buttons that were initially used in the first draft of our rhythm game were scrapped for one major reason, the UI for the buttons were aligned in a row, while the arrow keys on a player's keyboard were not aligned. We decided to use rectangles instead, binded to the d, f, j, and k keys as input. This avoided the physical dissociation that the playtesters felt when playing the rhythm game while also allowing for them to be able to access the space bar with both hands when switching between attack/defense.  
In addition to these control mechanisms that were edited, the UI and Physics were also revised from the playtesters' comments. For example, the dialogue text box was revised such that the text would scroll through faster, and Camber's movements were also speedier during the platformer parts of the game.  
Overall, the playtesters seemed to enjoy the visuals, animations, and audio, with the majority of them stating that they would gift it to a younger demographic, mainly little siblings or cousins, due to the vibrant and simple nature of the game.  

## Narrative Design
**Matthew Tom:** The entire point about this story is the path of reclaiming what was lost to fit the theme of "It was the best of times, it was the worst of times." From the sound design of music to give that inspiring, heroic like atmosphere, to the tactical decisions of switching between attack and defense modes, as well as the powerful enemies Camber faces, they all combine together to demonstrate a tale of struggle, strife, and victory through overcoming the odds. Every battle Camber fought required moments of sacrifice in the gameplay, such as sacrificing potential moments to build up the charge meter to attack, only to be met with a relentless attack from the enemy. The medieval look of Reclaim as a whole was an intentional choice as a reference back to the Medieval and Dark Ages in our history, where humanity arguably was at one of its lowest peaks. The worn down castle and the burning village in the later levels contrasted the opening first level and prologue where everything was much brighter and hopeful, further driving the point of how far the kingdom had fallen, and it would be up to Camber to save it.

A full narrative story was prototyped by me, found [here](https://docs.google.com/presentation/d/1HUj8aGtn-xqBHmpcKCYfG4XwCgd9Raxp5f-lnLd8QSg/edit?usp=sharing). 

Additional assets that were used to build scenes were found in free assets in Unity's asset store:
[Medieval Pixel Art](https://assetstore.unity.com/packages/p/medieval-pixel-art-asset-free-130131) and
[Pixel Art Platformer](https://assetstore.unity.com/packages/p/medieval-pixel-art-asset-free-130131).


## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel
**Ferica Ting:** 
We originally had arrow keys for the hit box, but then we realized that the spacing and sizing and the arrows did not provide the most optimal game feel. The arrows were a bit too small, so we ended up changing the arrows to larger rectangular boxes. Consequently, we also changed the input keys from arrow to DFJK. The DFJK keys go across the keyboard and correspond to the ordering of the rectangles. It did not make sense to keep the arrow keys as input, since it is not intuitive which keys would correspond to which rectangles.

## Cross-Platform
**Anthony Vu:** 
The game is primarily going to be played on PC, so most of the game logic and design was made to be PC friendly. I also made the game playable on mobile devices. I had to make some changes in the code to make the rhythm part work with mobile. I added invisible buttons where the notes are supposed to be pressed so that the player could tap there and the notes will be pressed. I had to add new logic to make the notes disappear [here](https://github.com/lennoncc/Reclaim/blob/6f58e883a3b49b89e7ddc93c49e2e161d7512e0e/Assets/Scripts/ButtonController.cs#L34) becuase the player would have to tap on the falling notes if I were to use the code we had for the PC version. I also added an invisible button to switch between attack and defense mode.

Most of the UI elements already worked for the main menue and dialog. However, I still had to implement movement for the side scroller scenes. I did this by checking if the player tapped on the left or right side of Camber and that would cause Camber to walk in that [direction.](https://github.com/lennoncc/Reclaim/blob/6f58e883a3b49b89e7ddc93c49e2e161d7512e0e/Assets/Scripts/CamberMovement.cs#L29)

## Design Translation
**Angelina Vu:**

This is one of the roles that our team made up and the main task for this role is to create diagrams that help others understand how the game works. The following are things I worked on for this sub-role.

Gantt Chart: https://ucdavis365-my.sharepoint.com/:w:/g/personal/athvu_ucdavis_edu/EdYyHaV_HlVChNt4J49-rfgBsqmByEnG_q7FALKK_8ApgA?e=4ePnla

Reclaim Game Logic Diagram: https://www.figma.com/file/4hGvLDmeaYvzbiD3lzMAHl/Reclaim-Game-Logic?node-id=0%3A1

Camber Animation FSM: https://docs.google.com/drawings/d/1jrccfaZD3c2KzukeoIZutvb3XEGru94xvKhegclnFGs/edit?usp=sharing
