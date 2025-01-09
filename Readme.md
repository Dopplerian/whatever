# Documentation

## Game Scenes

This AR project has one scene in which we start and play the game. Inside this
scene we will have the game objects.

## Game Objects:

**Bullet**

Unity object that is created after touching the screen that will fly in a
straight direction until it collides with either the floor or another object

**NPCs**

Object created randomly on the screen that at a certain rate will be either an
enemy or an ally.

## Game Mechanics

This game consists on moving the device as the aim of the camera will change, so
the user can shoot effectively on NPCs being generated.

This game contains a time which starts with the game and will last around 1
minute, after this time finished the game will be over.

There is also a score counter that will keep the accumulated score of the player
will go up for each enemy killed and rest one for each ally that was shot.

There is a `OnCollisionEnter` method inside the bullet controller that is
triggered every time it collides with and object, this method will update the
score of the player.

### Scripts

*Logger.cs*

This Controller has the goal to log every event that we desire inside the
application, during its initialization defines the path where the log file will
be stored and will contain a sole Log method that will receive the message that
would like to be logged, and Log into the file while appending it into the
current date time of the moment the method was called.

*BulletController.cs*

This controller has the task to handle all the mechanics a bullet will produce,
at first when it's declared it will instance a logger object and set a time, to
destroy this object if it wasn't able to hit anything in 3 seconds.

Then it contains a method called `OnCollisionEnter` will be triggered after the
event of this bullet colliding with an object, inside this method there is a
different behaviour for any kind on object that is being hit, could be and
enemy, ally that will affect the player's score and destroy the bullet object,
and if it collides the environment or any unknown object, it will log that
event.

Also, it contains the score method that updates the player's score after hitting
an enemy or allay and also logging it.

*Timer.cs*

This controller has the task to display to the player the amount of time
remaining this player has, this clock will start at 01:00 and will go backwards
as long the game continues.

On its initialization, it will call the logger controller and the
`NPCController` of the scene.

Inside this controller we have the Update method that updated the value on
screen and makes sure that the values don't go negative, and another method that
updates the timer display.

Finally, the `OnTimerEnd` that logs the end of the game and uses the
`NPCController` to stop generating more NPCs

*BulletSpawner.cs*

This is a simple script that ensures the gun object is always aligned with the
camera and that has a `Shoot` method that is called when the button in the
middle of the screen is pressed.

*UIManager.cs*

A simple script that hides the greeting prompt and unhides the shoot button
after you press the "Continue" button.

## Play Instructions

This game uses AR experience for a shooting range where we can move our device
to aim and touch the screen to shoot at different objectives.

First we will have a welcome page where we start the game after clicking the
continue button.

When the game starts we will start seeing different objects appearing on screen,
some of them are enemies, some of them allies.

The enemies are in form of cubes and the allies in form of cylinders.

After the timer finishes the game will be over.
