### Nov 5

Brianstormign activity for Prototype 4:
- I could add swinging pool doors to creae a seperation between the forest and the pool room.
- I could add flickering lights to enhance the atmosphere when the place walks around the room. The longer the player stays sin the room, the more lights flicker. 

Recommendation: work with the environment!
- Moving walls.
- Appearing and dissapearing objects.
- Peeping heads and footsteps soemwhere in the maze.
- Distorted pathways.
- Fake door that leads back to the start.
- Floating objects.

All of these work in a way to enhance the environemnt and atmosphere of my liminal space project.

___

### Nov 8

I had to create a new project because I kept running into a problem when duplicating the prevous P3 folder. I couldn't save it in my github desktop and it won't appear in my repo, so I just duplicated everything into the new P4 project fodler.

My first enhancement will be a peeping figure seen in The Backrooms' games. Those shapeless figures that don't seem friendly but dissapear whenever the player gets closer. 

I couldn't find a reference on how to use State Machine to rotate the monster. Every single one showed how to do it with script, so I ended up just coding it to rotate. I used OnTriggerEnter and Exit to call the rotation following this [reference](https://youtu.be/xcb5ChiIOH0).
When using the same line for both ente and exit, the monster woudn't return to its previous position when exiting the trigger box and continued to rotate by 45 degrees whenever I stepped back into the trigger box. I found this [reference](https://www.youtube.com/watch?v=LnQudtIKfnw) for to make the OnTriggerExit work. 

I decided to use quaternion.euler for both enter and exit. Then made the trigger's Box Collider thinner so that the action starts and ends quickly, for it to conclude in a quick blink. I wanted to try and make the game it shocking, but it lacks the pop. I'll have to add sound effects when the monster's rotated and stop when it's gone.

I made the original Monster parent a prefab and placed four around the map to have more occasions to trigger it. 

I'm thinking of using the last reference I found to make chairs float anf rotate towards the player. To make it feel like there's always somethng following or looking at you wherever you go. 

___ 

### Nov 10

I started with making a somewhat realistic bench. I picked a park bench out of all possible furnitures becuase it would fit in with the forest and park theme I was going for. All parks have benches. 

I followed the [reference](https://www.youtube.com/watch?v=LnQudtIKfnw) and created a new script for rotating the park benches to make it follow the player as they move around. I called an object target to target the player object. Then used LookAt() to control the rotation.

For now, it does what I want it to do, constantly following the player in an unerving way. I might duplicate this script for other objects, but I have 2 test examples in the walking sim at the moment. 
If it fits, I'll add more objects to add to the ambience of a Liminal space. 

___

### Nov 11

I replaced the last bench with the rotating one and added 2 park benches to the forest to add more environemental interaction with the player.

I decided to replace my old script with the given Cart315 First Player prefab. It worked smoother nd cleaner than my current script:
- The player footstep didn't have a delay.
- The player jump is always called when I press space.
- The movement was smoother and easier to control.

I alo decided not to add sound to the peerping monster because I want it to stay a surprise. I feel like it would be better if it was a soundless pop up when the player turns around rather than a loud boom. It would be less surprising to catch it from th ecorner of the eye rather than looking for a sound when you can't find the source.

___

### Nov 12

After listening to the class lesson, I think I might use terrain and visual colours to nudge the player to follow a path. I might add bright and contrasting or assets to use and draw a path to follow. 

I added grass sparcely to show a path to follow without forcing it. A subtle yellow rather than a bright and attention-grabbing red.

I downloaded a VFX dust asset from the store. I wanted to enhance the image of a dark and danky environment. The players stirs dust up as they walk, the VFX follows the player and leaves a trail behind and around. 

I decided to add a fake exit door that'll send players back to the start when collided with. It's a play on how the backrooms is infinite. I made it a bright red so that it attracts attention and calls the player to see what it is. 
I used a OntriggerEnter to call the reset at an empty object spawnpoint. It's not working at the moment, but I'll fix it later or tomorrow. 

However, if I don't have enough enhancement, I'm thinking of addign an actual monster that walks around the place and will chase the player. I'll find reference scripts before I start this.

