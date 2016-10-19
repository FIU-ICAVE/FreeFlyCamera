# FreeFlyCamera for getReal3D

### What Is It?

FreeFlyCamera is a script for Unity and getReal3D that allows you to move no-clipped. Currently it does not support collisions as it does not check for collisions.


### Usage

Use the getRealPlayerController prefab from getReal3D, and remove all the scripts it has attatched except for *getRealVRSettingsUI* and *getRealScaleReference*  
Then simply attatch the FreeCam.cs script to the getRealPlayerController prefab.  
  
Make sure to set up the following buttons in the getReal3D input manager
| Button Name  | Definition |
| ------------- | ------------- |
| Speed  | Base rotation speed for camera  |
| Reset  | Button to reset camera position and rotation  |

   
### Customization
  
The script offers several editable fields accessible from the editor.

| Field Name  | Definition |
| ------------- | ------------- |
| Reset Position  | Vector3 of where camera will be moved when Reset button is pressed  |
| Reset Rotation  | Vector3 of the camera rotation to set when Reset button is pressed  |
| Movement Speed  | Base movement speed for camera  |
| Rotation Speed  | Base rotation speed for camera  |
| Bonus Speed  | Movement speed multiplier for when the Speed button is held down  |
| Speed Button  | String name of button that will be used as speed button  |
| Reset Button  | String name of button that will be used as reset button  |
