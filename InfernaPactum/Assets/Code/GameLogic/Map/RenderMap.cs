using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMap : MonoBehaviour
{
    public GameObject squarePrefab;
    private void Start()
    {
        MapModel.Initialize();
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < MapModel.Map.GetLength(0); x++)
        {
            for (int y = 0; y < MapModel.Map.GetLength(1); y++)
            {
                if (MapModel.Map[x, y] == ObjectsEnum.Empty)
                {
                    var cell = Instantiate(squarePrefab, new Vector3(x * ConstProvider.CellSize + transform.position.x, y * ConstProvider.CellSize + transform.position.y, 0), Quaternion.identity, transform);
                    cell.GetComponent<Cell>().Position = new Point(x, y);
                }
            }
        }
    }

}
