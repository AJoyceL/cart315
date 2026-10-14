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

### Oct 