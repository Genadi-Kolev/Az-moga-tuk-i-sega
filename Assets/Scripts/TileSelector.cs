using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : Singleton<TileSelector>
{   
    public Tile highlightedTile;
    [SerializeField] private GameObject queen1, queen2;
    [SerializeField] private GameObject player1UI, player2UI;

    private Tile selectedTile;
    public Tile SelectedTile
    {
        set {
            if (!value.Available) return;

            selectedTile = value;
            PlaceQueen();
        }
    }

    private void OnEnable() => Queen.OnQueenPlaced += SwitchPlayers;
    private void OnDisable() => Queen.OnQueenPlaced -= SwitchPlayers;

    private void Start() => SwitchPlayers();

    private void PlaceQueen()
    {
        var tileObject = selectedTile.gameObject;
        var queen = tileObject.AddComponent<Queen>();
        queen.x = selectedTile.x;
        queen.y = selectedTile.y;
        Destroy(selectedTile);
    }

    private void SwitchPlayers()
    {
        var enumState = (int)GameManager.PlayerState;
        player1UI.SetActive(enumState == 1);
        player2UI.SetActive(enumState == -1);
        Queen.QueenImg = (enumState == 1) ? queen1 : queen2;
    }
}
