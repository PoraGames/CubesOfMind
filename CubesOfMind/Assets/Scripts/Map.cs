using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject cubePrefab;
    public Vector3Int mapSize;

    private Cube[,,] mapCubes;

    // Use this for initialization
    void Start()
    {
        mapCubes = new Cube[mapSize.x, mapSize.y, mapSize.z];

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    int r = Random.Range(0, 10);
                    if (r == 4)
                        mapCubes[x, y, z] = 
                            Instantiate(cubePrefab, new Vector3(x, y, z), Quaternion.identity).GetComponent<Cube>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
