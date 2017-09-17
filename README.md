# basic-rpg
Unity 5 rpg game

## Config
* Open Unity 5
* Import package `AxeyWorks` in the asset store, [link](https://www.assetstore.unity3d.com/en/#!/content/58821)
  
After that you are ready to go, just open the scene `main` inside the folder `Assests/_scenes/`

## Features

* NavMesh for navigation (left mouse button)
* Interactable objects (tag to specify which object is interactable)
* Simple Dialogue System
  * You can add lines to an object Dialogue and you can pass clicking in the continue button
* Simples Stat system
* Simple Item system
* Simple Inventory system (for now just an empty object `hand` that you can equip weapons)
  * Press `V` to equip basic sword
  * Press `F` to equip basic staff
* Simple weapon, with 2 simples attacks and animations
  * Press `X` for basic attack
  * Press `Z` for secondary attack
* Simple projectile objects
  * Fireball, triggered using staff attacks
  * It is destroyed if it collides to any object (if it is an object with tag `Enemy`, this object takes damage)
  * It is destroyed if reach specif distance (max distante is customizable)

## Contributions
If you want to contribute you are welcome to, but if you use a new asset package, add it to the `.gitignore` and in the **Config** part. Otherwise you will add all the assets to the git repository.
