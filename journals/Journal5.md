### Nov 19

While brainstorming and looking online for examples of looping game. I found themes such as *infinite hallways*, *never ending platforms*, *supermarket worker*, and many more. The one that called out to me the most is the *supermarket loop* where the player clocks in and plays as a store employee, completing tasks until closing time.
The loop in this case is the constant repetition of opening and closing the shop every day for a week or so. I think this could be an interesting, but simple enough prototype to work on. 

The plan:
- It'll be a 2D game with very simple visual graphics.
- The tasks will be: restocking shelves, mopping the floors and manning the register.
- The looping mechaning will be the opening and closing cycle of the shop.
- I'm thinking of adding disturbances like shadows, customers who speak gibberish, and the shelves rearanging themselves, moving or just dissapearing.

Extra:
- If I have time, I want to create different endings: a normal, a bad and a good ending.

I'm taking inspirations from previous supermarket horror games like *Night of The Consumers*, *Shift at Mightnight* and *Hellmart*. Although I won't be adding the anomaly or dopplegager detection aspect because I want the changes to be gradual over the days.

Vladim recommended moving it to a night employee to make the prototype easier. The player would be cleaning and restoking shelves only without having to talk to customers.
In this case, I'm going to map larger than the camera view so that it follows the player chracter around. This way I can have falling shelves, moving or dissapearing items that the player just used or placed down, shadows and creatures appearing from the corner of the screen. 

___

### Nov 22

I started brainstorming for ideas before starting anything. I was thinking of having using a task-based check to call the end of a shift rather than using time. This way, I can play as fast as I want without feeling rushed. It would give me time to explore and experience the whole scale of the prototype.

*However*, it made me worry that if I implemented this, some players could spend too much time on a singular task without moving on.
So a possible solution would to utilise both: 
- I have a timer that gives players enough time to complete all their tasks, espcially towards the last days when players will have to face anomalies. 
- I will still keep the task-based idea where players can end the night shift earlier if they complete all tasks. 

I also thought of a few things and changes to the anomalies that appear over days. I asked: "What else can I add? Other than shadows and moving objects?"
Then an idea poped up. What if towards the last 2 or 3 days, I had a monster/anomaly appear periodically to prevent the players from completing their tasks quickly? 
The monster's appearence would be anounced by a sound effect or message, then it would patrol around the shop in an attempt to catch the player. If the player's caught, the day restarts. 
It would appear periodically for 2 days, and on the last day, it would be constantly patroling the shop. 

All of this would play over the vanishing objects and the anomalies. The player's goal would be to finish their tasks before the timer runs out *and* without being caught by the monster. 


I found a [tileset asset](https://reakain.itch.io/gb-studio-7-11-tileset) by Reakain and followed this [tutorial](https://www.youtube.com/watch?v=DTp5zi8_u1U) to create the tileset tiles to draw on the grid and create my shop template. 
The retro style reminds me of Pokemon Green, a game that came out in 1996. The visual aesthetic fulfils both the familiar but creepy style I wanted. 

I decided to use tilemaps to make it easier to draw the whole scene. I'll layer the Obstacle, Wall and Ground layers and add colliders to make it possible to walk and complete tasks. 

For each day, I'll create - copy and paste the first scene - different scenes, starting with day 1 and add a Menu and ending scene for each day. For now, I made a prefab of the grid to place in every scene.

I'll work on the colliders and the player movement another time. I might reuse the player movement from my Prototype 2 and any script I've used that might work well for this specific project. 

___

### Nov 23

I had added a tilemap collider and a composite collider to all but the grouund tilemap. After doing some research to understand what the different composite operation types did, I seperated my shelves adn freezers into several tilemaps to use merge composite so that multiple grids making up a shape are merged into *one* collider. I made seperate tilemaps for the storage room, where the players will collide to trigger a box retrieval to restock shelves, and doors for the player to collide to trigger the end of their shift. 
I also created a playermovement script for the player, but I'll reuse what I can from the P2 project.

Another idea came to mind relating to the timer. Players will have a 15 or 30 second warning towards the end of the shift to leave the store. If they fail to reach the door by the end of their shift, they lose and have to restart the day. First time players won't be expecting it, so I'm hoping it'll be something unexpected. It will also make players more inclined to finish their tasks and exit as quickly as possible, even with the creature patrolling the store. 

I continued working on it later in the day. I had a look at the P2 snakes script and decided it would be better if I reused the player paddle script from my P1 instead. It was much simpler and fit the player movement more than the snake's. I placed the PlayerMovement on the player object and locked the RigidBody's Z rotation. It works smoothly.

I created a CameraFollow following this smooth camera follow [tutorial](https://youtu.be/8rnRvotQmdg?si=2v1nxoIGZDnxnqy1) to make the camera follow the player as they move around the store. 
The camera damping adds a small drag to the camera moement as it follows the player. I foudn it interesting, especially for a horro themed game where the player would have to move slow and steady to hide from the patrol.  I think it would encourage player to mvoe more carefully if the camera takes a few seconsd to complete the same moement as the player.
To compensate slightly with this handicap, I widened the camera range for the player to look at the next and/or rpevious rows. This way, the player will be able to watch the patrol's movement and path. 

I downloaded 2 orher asset packs from the same creator for extra sprites to use. It keeps the same GameBoy theme/style.

I picked the [first](https://reakain.itch.io/gb-studio-trains) one for the emotes and the character asset I can utilise later on.
The the [second](https://reakain.itch.io/gb-studio-outdoor-tileset) one was for the larger files of otudoor assets I could use as sprites for trash.

I duplicated the outdoor pack to trim out everything, but the sprite I need for the trash and converted it into an image. This way, I can creat multiple, individual gameObjects for the player to clean up.
Since I want a random amount of trash to spawn at the start of the scene at random position, I'll have to use Random.Range. I followed this [Unity](https://generalistprogrammer.com/tutorials/unity-spawn-object-at-random-position?utm_source=chatgpt.com) tutorial.
The amount randomiser works, but the random position doesn't, it keeps spawning at (0,0). I'll work on it tomorrow since it's getting late. 
___

### Nov 25

I figured out why the trash sprite always kept spawning at (0,0). I forgot to assign the max and min position in the empty object called TrashSpawner. That's why. Now I have to prevent it from spawning in the shelves. 

While the initial issue is fixed, another one that popped up is that some trash are created on shelves. I tried using OverlapBox(), but it still doesn't work. Worst case scenario, if I can't get it fixed because the use of tilemaps might create a complication, I'll draw the paths myself on Unity.
