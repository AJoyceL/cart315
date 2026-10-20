### Oct 2

After yesterday's class activities, I kept thinking about my 2nd prototype. I could either work on makign a variation of the templates offered, or create a completely different game. 
Honestly, I'm leaning towards the latter. I find the concept I can with more interesting: a 2D hide-and-seek horror game, where the player has toplays as a child hiding behind furniture and walls to stay hidden from monsters.
The setting would be the hallway of the character's (MC) home. 
The plot would be a child needing to go to the bathroom, and having to walk in the dark. Naturally, young children with wildly active imagination conjure up monsters and myths. This kid, however, has nightmares and is scared of the dark.
The game olay would be mainly running and crouching, hiding behind furnitures and walls.

I'll come up with more ideas later on.

___

### Oct 10

After procrastinaitng long enough, I finally decided to start working on my prototype 2. Just to start it off with, I copy pasted a template folder so that I wouldn't have to create a new Unity file from scratch. I renamed it, and deleted the previous folders before I starte working on anything. 
I have the background done: walls, furnitures and doors(player bedroom and bathroom), and for the player and monster, I'm currently using temporary sprites for them. I'll finish the script before I actually change them, I think it'd be easier to do it this way. 
For now, I think I'm sticking with my plan: a hide and seek game where the player starts from point A and has to reach point B without being caught. 
I'll have to look up how to make the monster/nightmare an agent-based model, where it'll have to move by itself and act and catch the player.

___

### Oct 14

So I decided to work on the essential parts of the prototype: the player movement/controls, the monster Ai and the camera follow.
the first thing I did was the player movement. Taking from the Paddle's script and discovered it moved to jerkily for what I wanted. I wanted gradual acceleration within a certain limit, but still feel like a slow crawl. I used this [reference](https://docs.unity.com/en-us/engine/6000.5/script-reference/unityengine/mathf/movetowards) to calculate the speed, but I couldn't get it working correctly, and so, I ended up asking Copilot where my mistakes were using MathF.MoveToward(). After a few more tries, I got it working. 
Then I worked on the camera since it was essential if I wanted to be able to see what the game scene looked like. I found this [reference](https://www.codemahal.com/making-the-camera-follow-the-player-2d-unity) to allow the camera to follow the player. Since I only needed the camera to follow a horizontal path, I just too what I needed.
Finally, the hardest part was the monster's movement. I couldn't find much of what I wanted, but a few good references were by [Generalist Programmer](https://youtu.be/8mTY7_WMPG8?si=tL5YcvFbuHbJ4Nab), by [Unity](https://discussions.unity.com/t/enemy-line-of-sight-with-raycast2d/865347) and this one by [Lost Relic Games](https://youtu.be/2VX8uD_xUlM?si=WC0vW-LnLGyFRRlT).
The last one being very helpful to deal with the line of sight by using Raycaster. Though I used Headers instead of SerialisedFields because I was using field objects.
Despite having all these references, I still couldn't make the monster move behind the walls and blocks because of the boc collider, but fortunetaly, ChatGPT showed me I could add object layers and change what it interacts with through the Project Setting > Physics2. By unchecking where my Monster, Player and VisionBlocker layer intersect, I got it fixed. This took the longest to get working, but it was worhtwhile seeing my monstyer game object work as I wanted it to. 

I'll leave the catching, restarting and end game scene for another day. 

___

### Oct 16

Logged on to do some debugging before I left for the cinema to watch Resident Evil. I reworked the monster's prtrol function to get it to consistently walk back and forth between Point A and Point B. That was all I worked on today, but I'm planning on make the player move slower and without acceleration or make it slower(it makes sense for a child to rush to the bathroom when the path feels safe and clear, but children aren't often that fast). I'll also have to make the scene reset when the monster catches the player, add and endgame scene and probably find assets to replace the player and the monster.

___

### Oct 18

I tried to make the player reset it's position whenever the monster catches it, but it won't work. Anything I do won't work an dI'm getting really frustrated. I'll just drop this and restart a new prototype. Hopefully I can make it with 3 days left, bevause I'm really fed up with all the problems popping up.
I'm either going to work on the Bricks or Snake game since they're the ones I find more interesting, especially the snake. 
I'm already getting ideas:
- make the snake eat moving blocks,
- make multiple spawn at the same time
- make it possible to be played with multiple people or add an AI that's competing with the player or trying to kill the player.\,
- make some blocks hostile to the player like remove points,
- make some blocks give extra points,
- etc...

Yeah, I'll start workign on it tomorrow and try to finish it by wednesday.

___

### Oct 19

Just started working on the new prototype 2. 

Step1: I made the food square move at random position over time, but now the snake has to collide with it at a specific position to consume it. I'm working on fixing it right now.
Update: as long as half of the snake collides with food, it'll eat it. 

Step 2: Made food spawn multiple ones at the start in an empty object called FoodSpawner.
Update: It kept breaking the game, but I realised that I had to take FoodSpawner out of the Food object and tweaked the FoodSpawner script. Now I can set hw many spawn at the start in the Inspector and only the one consumed resets at a random position.

Step 3: Make food move at random speed.
Update: Using Random.Range, I can set the range of speed for all food prefabs. Replaced the assigned speed to a variable I can change in the start for initial movement speed and in the RandomisePosition to randomise the speed after it resets.

Step 4: Make an AI snake.
Update: Recycled the Snake.cs and previous CPU Paddle from P1 to make up the bulk of the AISnake.cs, but chnaged the movement to be autonomous and added a FindFood(). Both snakes will reset if they hit one another. I also changed the snake start position so that the player starts moving to the left and the AISnake to the right.

I'll continue making variations and. changes tomorrow.
___

### Oct 20

First thing I did today, was change the colours of the game, I might also chnage the snakes' shape from square to circle.
Update: I added keyboard commands for the AISnake so that it can be player alone, or with another person.

Step 2: randomise food effect (+1, +2 & -1 segments).
Update: It works, and just to be sure, I left debugs int he script to check in the consol. It now affects f=both the AISnake and the Snake. Effects randomise upon reset. I like the randomness of the effect, not knowing if you're eating a good or bad thing sincd they all look alike, it adds tension when you're left with 1 segment. It happened a few times during my test runs, to both me and the AISnake. I watched my snake wither to 1 segment and got unlucky and ate a bad one. I had to reset while the AISnake had a few segments to it.

I'll add to this until thursday if I have any more ideas.
ps. changed the name of my original Hide_and_seek file and made a duplicate of the final SNake game and moved it outside and into my main github file so that it's easier to find. I named it P2_Snakes

___
 
### Oct