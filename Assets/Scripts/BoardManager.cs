using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private Tilemap m_Tilemap;
    private Grid m_Grid;

    public int length, depth;

    public Tile[] groundTiles;
    public Tile[] wallTiles;

    public class CellData
    {
        public bool Passable;
    }

    private CellData[,] m_BoardData;

    public PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();

        m_BoardData = new CellData[length, depth];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < depth; y++)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();

                if (x == 0 ||  y == 0 || x == length - 1 || y == depth - 1)
                {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)];
                    m_BoardData[x, y].Passable = false;
                }
                else
                {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                    m_BoardData[x, y].Passable = true;
                }

                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        player.Spawn(this, new Vector2Int(3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= length
            || cellIndex.y < 0 || cellIndex.y >= depth)
        {
            return null;
        }

        return m_BoardData[cellIndex.x, cellIndex.y];
    }
}
