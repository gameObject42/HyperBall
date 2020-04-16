using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefab;

    public float zSpawn = 0;
    public float tileLength = 0;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTrans;

    private void Start()
    {
        for(int i =0; i<numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else {
                SpawnTile(Random.Range(1, tilePrefab.Length));
            }
        }
    }
    private void Update()
    {
        if (playerTrans.position.z - 75 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefab.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject tileInstasite = Instantiate(tilePrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tileInstasite);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
