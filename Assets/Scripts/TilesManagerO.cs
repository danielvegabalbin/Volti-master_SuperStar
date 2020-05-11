using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManagerO : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    public GameObject CUBE;
    public Transform playerTransform;
    
    public float spawnZ = -50.0f;
    public float tileLength = 50.0f;

    private int lastPrefabIndex = 0;

    public float distanceLastT;

    public int nTiles = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = nTiles; i < 10; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnTile();
        }

        if (distanceLastT > 20)
        {
            SpawnTile();
        }

        distanceLastT = playerTransform.position.z - spawnZ * -1 ;
    }

    private void SpawnTile()
    {
        GameObject go;

        go = Instantiate(CUBE) as GameObject;

        go.transform.position = Vector3.forward * spawnZ;
        go.transform.SetParent(transform);
        spawnZ += tileLength;

        

    }
    //private int RandomPrefabIndex()
    //{
    //    if (tilesPrefabs.Length <= 1)
    //    {
    //        return 0;
    //    }
    //    int randomIndex = lastPrefabIndex;

    //    while (randomIndex == lastPrefabIndex)
    //    {
    //        randomIndex = (UnityEngine.Random.Range(0, tilesPrefabs.Length));
    //    }

    //    lastPrefabIndex = randomIndex;

    //    return randomIndex;

    //}
}
