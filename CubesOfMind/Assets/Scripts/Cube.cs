using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3Int needPosition;

    void Awake()
    {
        needPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
    }

    void Update()
    {
        transform.position = needPosition; // Временно
    }

    public void SetNeedPosition(Vector3Int newNeedPosition)
    {
        needPosition = newNeedPosition;
    }

    public void AddNeedPosition(Vector3Int shiftVector)
    {
        needPosition += shiftVector;
    }
}
