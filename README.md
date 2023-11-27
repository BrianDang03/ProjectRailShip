*******************************************************
* Name      : Brian Dang
* Date      : 11/26/2023
*******************************************************
Project RailShip
*******************************************************
Objective: Defend the planet and destroy the enemies. 
*******************************************************
* Description of Game
*******************************************************
1. Move the ship by using W, A, S, D keys.
2. Fire lasers by using left mouse click.
3. Destroy the enemies to gain points.
4. Avoid the enemies and the obstacles.
*******************************************************
* C# Scripts
*******************************************************
Name: CollisionHandler, handles the collision for the player ship. When player collides, disables player controls, lasers, ship renderer, collisions, instantiate playerExplosion VFX and SFX, and invokes ReloadLevel. 

Name: Enemy, handles the enemy object. Adds Rigidbody at runtime, has a health and the number damage it takes when getting hit by a laser, process hits and death particles/sounds, increments the scoreBorad when hit and destroyed.

Name: MusicPlayer, plays the music on awake. Only plays one time and loops. Prevents the music from playing again when reloading a level. 

Name: PlayerController, handles the left mouse fire input, W, A, S, D movement inputs with euler and quaternion influence.

Name: ScoreBoard, handles the score value displayed on the UI. Has a public function for the Enemy.cs script to use and increment score.

Name: SelfDestruct, handles the clean up of the instantiated explosion game objects.
*******************************************************
* Circumstances of Game
*******************************************************
It is in a good place to stop development for now. Will be worked on in the future.

Ideas for the future: Boss fights, full flushed out story, more particles assets, etc.  
*******************************************************
