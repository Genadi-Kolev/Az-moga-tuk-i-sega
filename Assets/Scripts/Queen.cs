using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Tile
{
    private Tile[,] tiles;
    private int desiredX;
    private int desiredY = 0;

    public static GameObject QueenImg;

    public static event System.Action OnQueenPlaced;

    private void Start()
    {
        KillAvailable();
        OnQueenPlaced?.Invoke();
    }

    public void KillAvailable()
    {
        Instantiate(QueenImg, new Vector2(x, y), Quaternion.identity, gameObject.transform);
        tiles = Grid.Instance.Tiles;
        foreach(var tile in tiles)
        {
            desiredY = tile.y;
            desiredX = this.x - (this.y - desiredY);
            if (tile.x == desiredX && tile.y == desiredY)
                tile.Available = false;
            if (tile.x == this.x)
            {
                tile.Available = false;
            }
            if (tile.y == this.y)
            {
                tile.Available = false;
            }
        }
        foreach(var tile in tiles)
        {
            desiredY = tile.y;
            desiredX = this.x + (this.y - desiredY);
            if (tile.x == desiredX && tile.y == desiredY)
                tile.Available = false;
        }
    }
}
