using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallSpwner : MonoBehaviour
{
    public GameObject[] colorPrefab;

    public float zSpawn = 0;
    public float colorPrefabLength = 0;
    public int numberOfColorPrefab = 5;
    private List<GameObject> activecolorPrefab = new List<GameObject>();

    public Transform playerTrans;

    private void Start()
    {
        
        for (int i = 0; i < numberOfColorPrefab; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, colorPrefab.Length));
            }
        }
    }
    private void Update()
    {
        if (playerTrans.position.z - 75 > zSpawn - (numberOfColorPrefab * colorPrefabLength))
        {
            SpawnTile(Random.Range(1, colorPrefab.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject tileInstasite = Instantiate(colorPrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activecolorPrefab.Add(tileInstasite);
        zSpawn += colorPrefabLength;
    }
    private void DeleteTile()
    {
        Destroy(activecolorPrefab[0]);
        activecolorPrefab.RemoveAt(0);
    }
}
