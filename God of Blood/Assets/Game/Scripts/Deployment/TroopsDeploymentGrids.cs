using System.Collections.Generic;
using UnityEngine;

public abstract class TroopsDeploymentGrids : MonoBehaviour
{
    [SerializeField] private int _gridSizeX = 10;
    public int GridSizeX => _gridSizeX;
    [SerializeField] private int _gridSizeY = 13;
    public int GridSizeY => _gridSizeY;

    [SerializeField] private Transform _warGroupsContainer;
    [SerializeField] private TroopsGroup _groupPrefab;

    private Vector2Int GridSize; 

    private TroopsGroup[,] grid;
    private TroopsGroup _flyingTroopsGroup;
    private Camera mainCamera;

    protected virtual void Awake()
    {
        GridSize = new Vector2Int(_gridSizeX, _gridSizeY);

        grid = new TroopsGroup[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
    }

    protected virtual void Start()
    {

    }

    public virtual void StartDeployGroup()
    {
        if (_flyingTroopsGroup != null)
        {
            Destroy(_flyingTroopsGroup.gameObject);
        }

        _flyingTroopsGroup = Instantiate(_groupPrefab, _warGroupsContainer);
    }
    protected virtual void Update()
    {
        if (_flyingTroopsGroup != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 

            if(groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0.5f || x > GridSize.x - _flyingTroopsGroup.size.x) available = false;
                if (y < 0.5f || y > GridSize.y - _flyingTroopsGroup.size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                _flyingTroopsGroup.transform.position = new Vector3(x, 0, y);

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x, y);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(_flyingTroopsGroup.gameObject);
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingTroopsGroup.size.x; x++)
        {
            for (int y = 0; y < _flyingTroopsGroup.size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    protected virtual void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingTroopsGroup.size.x; x++)
        {
            for (int y = 0; y < _flyingTroopsGroup.size.y; y++)
            {
                grid[placeX + x, placeY + y] = _flyingTroopsGroup;
            }
        }

        _flyingTroopsGroup = null;
    }

    protected virtual void DeleteGroupQuantity()
    {

    }

}
