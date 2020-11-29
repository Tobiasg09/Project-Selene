FAQ


== Q: Why Pivot Points on feet of player?
A: The player is 2 tiles high. Imagine player walking in front of a plant. 
If the player's pivot (if at centre, will be 0.5 the height of the player, or 1 tile high), surpasses the plant's pivot (0.5 tiles high), then the player will be rendered behind the plant if the player is closer than 0.5 tiles away. Looks really bad..

== Q: Why then the Pivot Points of tiles down as well?
A: Because otherwise we have the opposite effect. This is usually less bad tho, as usually the bottom of the sprite is solid. But then the problem happens at the top of sprites which are passable. (E.g. a plant sprite that is 2 tiles high). Can solve this by putting these tiles on a layer which is always on top of player. But then, they'll always be on top of player.. Which might not be desirable.

Alternatively, just make pivot points of tiles at the bottom

== Q: How do I set the tilemaps accordingly?
First, slice tileset image with pivot point at bottom. But then if you drag those tiles into a tile palette, you'll notice that they are misaligned. To change this, go to palette prefab, open prefab, and you'll see in 'Layer1' a Tile Anchor under the Tilemap component. Change this accordingly (so to x=0.5, y=0). Now, sprites will look good in Tile Palette. However, you still cannot place them perfectly on the Tilemap grid. To change this, go to the desired Tilemap, where you can also find a Tile Anchor property under the Tilemap component. Also change to whatever you want. 

Now everything renders correctly, if any items you make with multiple tiles at least do not consist of multiple walk-through tiles stacked vertically .. Then you'll still have to fiddle with putting them on tilemap layers that always stay on top of player. Or for more complex objects, just put them into gameobjects.

If you have trouble with colliders of tilemaps acting funky, just reset the anchor on the tilemap collider.





== Q: How do I update Tile Palettes associated to a tilesheet

DISCLAIMER: this workflow assumes that every possible sprite in your spritesheet is filled. This is obviously not possible, and an easy workaround is just putting a filler (e.g. red dot) in every unused tile.

The usual workflow for getting a Tile Palette setup is go to your tilesheet image, slice it, drag n drop it onto Tile Palette window, which will create the individual tiles. The basic relation is (a bit convoluted, but still): tilesheet -> sliced tilesheet -> Tile Palette -> Tiles -> Tilemap grid. In words, the tilesheet is sliced into sliced images, which can be dragged onto the tile palette, which saved each individual sliced image as a tile, which is actually what the tilemap grid remembers (I think). However, once you have an updated tilesheet, what do you do? If you do the process above again, you'll notice that you'll be prompted to overwrite your existing tiles and that, after pressing play or reloading the game, many of your tiles in-game will receive a red-pinkish colour. This is because the tilemap grid has lost the reference to whatever tile was there (because you overwrote it, albeit with the same slice of the sprite sheet, but the tilemap doesn't know that), so it'll show up pink. The solution is different depending on what you want to do:

-simply update an existing sprite: don't reslice and drag 'n drop it. Just update the actual image and the update will carry through. They will work consistently through plays and restarts. The downside is that the icon of the Tile assets in the inspector will still be the old icon - but the sprite renderer will know better. (One might see a trick coming already: just set the size of the sprite sheet beforehand et voila.)

-if you need to extend the original sprite sheet: (this assumes that the extension is in the form of an added row on the bottom) if you add an extra row and save the png, you'll see that the Tile Palette changed (they all moved a row up) and subsequently, the tilemap grid is messed up (even though you didn't change the tile assets themselves). This is because both the Tile assets and Tile Palette remember which part of the slice spritesheet they came from. If you open the tilesheet image in the sprite editor, you'll notice the problem: the initial order of the slices is messed up. To solve this, simply make sure every slice has the original numbering (this is why it is important to fill every slot, as well as add no extra columns while expanding the sprite sheet, as otherwise this step will be much, much more tedious). If you added an extra row to the bottom of your tilesheet, simply slice the tilesheet again. This will give the old tiles their old numbering back and create new tilesheet slices for the new tiles. Now you'll notice that the Tile Palette and Tilemap grid look the same as before. Now, what remains is getting the new tilesheet slices into the Tile Palette. Now, be careful not to simply drag 'n drop your whole tilesheet into the Tile Palette, but rather only the new tilesheet slices. If you prefer, reorganise them to look similar to the tilesheet image (highly recommended). Now it is fixed! 

The key is that the Tilemap grid looses its reference to the tile asset that was actually there. The tile sprite renderer does update automatically, so if you just save the new png, no problems




