using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{   
    public int x;
    public int y;

    [SerializeField] private bool available;
    public bool Available
    {
        get => available;
        set {
            available = value;
            if (!available) GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    private void OnMouseDown()
    {
        TileSelector.Instance.SelectedTile = this;
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        TileSelector.Instance.highlightedTile = this;
    }

    private void OnMouseExit()
    {
        if (Available)
            GetComponent<SpriteRenderer>().color = Color.white;
        else
            GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
