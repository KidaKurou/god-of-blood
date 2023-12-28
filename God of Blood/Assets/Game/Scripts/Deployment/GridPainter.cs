using UnityEngine;
public class GridPainter : MonoBehaviour
{
    private const float ZOFFSET = 0.5f;
    private const float YOFFSET = 0.001f;
    private const float XOFFSET = 0.5f;
    private const float YROTATEOFFSET = 90f;

    [SerializeField] private TroopsDeploymentGrids TroopsDeploymentGrids;
    [SerializeField] private Transform GridContainer;
    [SerializeField] private GameObject tilePrefab;

    private int _gridSizeX = 0;
    private int _gridSizeY = 0;
    private float _tileSize = 1f;

    private void Awake()
    {
        _gridSizeX = TroopsDeploymentGrids.GridSizeX;
        _gridSizeY = TroopsDeploymentGrids.GridSizeY;
    }

    private void Start()
    {
        PaintGridX();
        PaintGridY();
    }

    private void PaintGridX()
    {
        for (int x = 0; x < _gridSizeX; x++)
        {
            for (int z = 0; z < _gridSizeY; z++)
            {
                Vector3 position = new Vector3(x * _tileSize + XOFFSET, YOFFSET, z * _tileSize + ZOFFSET);
                Instantiate(tilePrefab, position, Quaternion.identity, GridContainer);
            }
        }
    }

    private void PaintGridY()
    {
        for (int x = 0; x < _gridSizeX; x++)
        {
            for (int z = 0; z < _gridSizeY; z++)
            {
                Vector3 position = new Vector3(x * _tileSize + XOFFSET, YOFFSET, z * _tileSize + ZOFFSET);
                Instantiate(tilePrefab, position, Quaternion.Euler(0, YROTATEOFFSET, 0), GridContainer);
            }
        }
    }
}