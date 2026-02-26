using UnityEngine;
using UnityEngine.Tilemaps;

public class BattlefieldManager : MonoBehaviour
{
    private Tilemap m_Tilemap;

    public int fieldX, fieldY, zoneA, zoneB;

    public Tile[] zoneTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        for (int x = 0; x < fieldX; x++)
        {
            for (int y = 0; y < fieldY; y++)
            {
                if (x < zoneA)
                {
                    m_Tilemap.SetTile(new Vector3Int(x, y, 0), zoneTiles[0]);
                }
                else if (x < zoneB)
                {
                    m_Tilemap.SetTile(new Vector3Int(x, y, 0), zoneTiles[1]);
                }
                else
                {
                    m_Tilemap.SetTile(new Vector3Int(x, y, 0), zoneTiles[2]);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
