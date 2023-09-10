using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _mainCam;

    void CreateGrid()
    {
        for (int y = _height; y > 0 ; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, -(y - _height)), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {-(y - _height)}";

                var isBlack = (x % 2 != 0 && y % 2 == 0) || (x % 2 == 0 && y % 2 != 0);
                spawnedTile.Init(isBlack);
            }
        }

        

        _mainCam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(); 
    }

}
