using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilesPrefabs;

    private Transform playerTransform;
    private float spawnZ = -50.0f;
    private float tileLength = 50.0f;

    private float safeZone = 200.0f;
    
    private int amnTilesOnScreen = 7;

    private List<GameObject> activeTiles;

    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 3)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;

        if (prefabIndex == -1)
        {
            go = Instantiate(tilesPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilesPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        activeTiles.Add (go);
            
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex() 
    {
        if (tilesPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = (UnityEngine.Random.Range(0,tilesPrefabs.Length));
        }

        lastPrefabIndex = randomIndex;

        return randomIndex;

    }
}
