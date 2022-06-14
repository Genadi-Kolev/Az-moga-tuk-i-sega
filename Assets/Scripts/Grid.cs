using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : Singleton<Grid>
{
    private Cinemachine.CinemachineVirtualCamera cam;

    [SerializeField] private int m;
    [SerializeField] private int n;
    public GameObject QueenImg;


    private Tile[,] tiles;
    public Tile[,] Tiles { get => tiles; }
    
    [SerializeField] private GameObject tilePrefab;

    private void Awake()
    {
        cam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
    }

    private void Start()
    {
        GenerateGridTiles();
        FocusOnCentre();
    }

    private void FocusOnCentre()
    {
        var centre = new GameObject(name: "camera center point");
        centre.transform.position = new Vector2((float)(m-1) / 2, (float)(n-1) / 2);
        cam.LookAt = centre.transform;
        cam.Follow = centre.transform;
    }

    private void GenerateGridTiles()
    {
        int m = GameManager.Instance.m;
        int n = GameManager.Instance.n;
        tiles = new Tile[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var tile = Instantiate(tilePrefab, new Vector2(j, i), Quaternion.identity, gameObject.transform);
                tile.name = $"{j} : {i}";

                var tileComp = tile.GetComponent<Tile>();
                tileComp.x = j;
                tileComp.y = i;
                tileComp.Available = true;
                Tiles[i, j] = tileComp;
            }
        }
    }


}
