using UnityEngine;

public class InputConroller : MonoBehaviour
{
    private GameObject currentCell = null;
    void Update()
    {
        if (SpawnState.SpawnEnabled)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Cell cellComponent = hit.collider.gameObject.GetComponent<Cell>();
                if (cellComponent != null)
                {
                    GameObject hitCell = hit.collider.gameObject;

                    HandleMouseHover(hitCell);

                    if (Input.GetMouseButtonDown(0))
                    {
                        HandleMouseClick(cellComponent);
                    }
                }
            }
            else
            {
                if (currentCell != null)
                {
                    ResetCellColor(currentCell);
                    currentCell = null;
                }
            }
        }
        else
        {
            if (currentCell != null)
            {
                ResetCellColor(currentCell);
                currentCell = null;
            }
        }
    }

    void HandleMouseHover(GameObject cell)
    {
        if (cell != currentCell)
        {
            if (currentCell != null)
            {
                ResetCellColor(currentCell);
            }

            currentCell = cell;

            SetCellColor(currentCell, Color.blue);
        }
    }

    void HandleMouseClick(Cell cellPosition)
    {
        if (MapModel.Map[cellPosition.Position.X, cellPosition.Position.Y] == ObjectsEnum.Empty)
        {
            var mob = Resources.Load<GameObject>(SpawnState.MobType.ToString());

            var properties = Instantiate(mob, currentCell.transform.position, Quaternion.identity, transform).GetComponent<BaseMobModel>();

            properties.Health = 2;
            properties.Damage = 1;
            properties.AttackRange = 1;
            properties.Position = cellPosition.Position;
            properties.MobType = SpawnState.MobType.Value;
            properties.IsEnemy = SpawnState.MobType.Value == ObjectsEnum.FurcasEnemy;
            MapModel.Map[cellPosition.Position.X, cellPosition.Position.Y] = SpawnState.MobType.Value;

            SpawnState.SpawnEnabled = false;
            SpawnState.MobType = null;
            ResetCellColor(currentCell);
        }
    }

    void SetCellColor(GameObject cell, Color color)
    {
        SpriteRenderer spriteRenderer = cell.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }

    void ResetCellColor(GameObject cell)
    {
        SpriteRenderer spriteRenderer = cell.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
