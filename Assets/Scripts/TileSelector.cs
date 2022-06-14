using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : Singleton<TileSelector>
{   
    public Tile highlightedTile;

    private Tile selectedTile;
    public Tile SelectedTile
    {
        set {
            if (!value.Available) return;

            selectedTile = value;
            PlaceQueen();
        }
    }

    private void PlaceQueen()
    {
        var tileObject = selectedTile.gameObject;
        var queen = tileObject.AddComponent<Queen>();
        queen.x = selectedTile.x;
        queen.y = selectedTile.y;
        Destroy(selectedTile);
    }
}
