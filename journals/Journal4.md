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