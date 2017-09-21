# basic-rpg
Unity 5 rpg game

## Config
* Open Unity 5
* Import package `AxeyWorks` in the asset store, [link](https://www.assetstore.unity3d.com/en/#!/content/58821)
  
After that you are ready to go, just open the scene `main` inside the folder `Assests/_scenes/`

## Features

* NavMesh for navigation (left mouse button)
* Interactable objects (tag to specify which object is interactable)
* Simple [Dialogue System](Assets/_scripts/DialogueSystem.cs)
  * You can add lines to an object Dialogue and you can pass clicking in the continue button
* Simples [Stat system](Assets/_scripts/Stat)
* Simple Item system, consists of:
  * ObjectSlug: [string] of the prefab name
  * ItemName: [string] that represents the item name in the game
  * Description: [string] that describes the item in the game
  * ItemType: [string] type of the item, is checked for some actions (it is an Enum, created in the Item.cs class), can only be one of these:
    * Weapon
    * Consumable
  * ActionName: [string] for the action to use the item (it is shown in the invetory button)
  * ItemModifier: [boolean] 
  * Stats: [list] of possible stats, each stat consists of:
    * BaseValue: [int] value for the specific stat
    * StatName: [string] name of the stat, should be one of the CharacterStat
      * Attack
      * Defense
      * Vitality
      * Agility
* Item Database from a [JSON file](Assets/_resources/Resources/json/Items.json)
  * Added `Json.Net.Unity3D` Unity package to read itens from JSON file, can be found [here](https://github.com/GameGrind/Json.Net.Unity3D/releases)
* Simple [Inventory system](Assets/_scripts/Inventory), with a list of itens and its description
  * Press `I` to open Inventory window
* Simple weapons [scripts](Assets/_scripts/Weapons) and [prefabs](Assets/_resources/Resources/weapon), with 2 simples attacks and [animations](Assets/_animations)
  * Press `X` for basic attack
  * Press `Z` for secondary attack
* Simple projectile objects 
  * Fireball, triggered using staff attacks
  * It is destroyed if it collides to any object (if it is an object with tag `Enemy`, this object takes damage)
  * It is destroyed if reach specif distance (max distante is customizable)
* Enemy with simple AI
  * Has a aggro sphere that follows player if it enters in that sphere
  * Attacks if it is close enough
  * Stops chasing if player gets outside aggro sphere, and it returns to its original position
* Beginning of Character UI
* Added script execution order because it was generating an error (Edit > Project Settings > Script Execution Order)
  * UIEventHandler > ItemDatabase > InventoryController > Player > PlayerWeaponController > others
  
## Contributions
If you want to contribute you are welcome to, but if you use a new asset package, add it to the `.gitignore` and in the **Config** part. Otherwise you will add all the assets to the git repository.
