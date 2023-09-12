using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _mainCam;

    private void Awake()
    {
        Instance = this;
    }


    private Dictionary<Vector2, Tile> _tiles;

    public void CreateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int y = _height; y > 0 ; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, -(y - _height)), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {-(y - _height)}";
               
                var isBlack = (x % 2 != 0 && y % 2 == 0) || (x % 2 == 0 && y % 2 != 0);
                spawnedTile.Init(isBlack);

                _tiles[new Vector2(x, -(y - _height))] = spawnedTile;
            }
        }

        

        _mainCam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeGameState(GameState.SpawnWhite);
    }

    public Tile GetCheckersSpawnTile(Faction faction)
    {
        foreach (var tile in _tiles)
        {
            switch(faction)
            {
                case Faction.White:
                    if (tile.Key.y - 1 < _height / 2 && tile.Value.isWalkable)
                    {
                        if ((tile.Key.y + tile.Key.x) % 2 == 1)
                        {
                            return tile.Value;
                        }
                    }
                    break;
                case Faction.Black:
                    if (tile.Key.y - 1 >= _height / 2 && tile.Value.isWalkable)
                    {
                        if ((tile.Key.y + tile.Key.x) % 2 == 1)
                        {
                            return tile.Value;
                        }
                    }
                    break;
            }
            
            
        }
        return null;
    }

   
}
