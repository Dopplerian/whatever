Documentation
============

# Game Scenes

This AR project has one scene in which we start and play the game.
Inside this scence we will have the game objects.

# Game Objects:
**Bullet**

Unity object that is created after touching the screen that will fly in a straight direction untill it collides with either the floor or another object

**NPCs**

Object created randomly on the screen that at a certain rate will be either an enemy or an ally.

# Game Mechanics
This game consists on moving the device as the aim of the camera will change so the user can shoot efectively on NPCs beign generated.

This game contains a time which starts with the game and will last around 1 minute, after this time finished the game will be over.

This game contains a score counter that will keep the acumulated score of the player will go up for each enemy killed and rest one for each ally shot.

There is a OnCollisionEnter method inside the bullet controller that is triggered everytime it collides with and object, this method will update the score of the player.

Play Instructions
=================

This game uses AR experience for a shooting range where we can move our device to aim and touche the screen to shoot at different objectives.

First we will have a welcome page where we start the game after clicking the continue button.

When the game starts we will start seeing different objects appearing on screen, some of them are enemies, some of them allies.

The enemies are in form of cubes and the allies in form of cilinders.

After the timer finishes the game will be over.
