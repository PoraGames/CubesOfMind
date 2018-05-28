using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    #region VARIABLES
    public GameObject cubePrefab;
    public Vector3Int mapSize;

    private Cube[,,] mapCubes;
    #endregion

    void Start()
    {
        StartGenerateMap();
    }

    void Update()
    {
        GlobalGravitationSimulate();
    }

    /// <summary>
    /// Начальная генерация карты
    /// </summary>
    void StartGenerateMap()
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

    /// <summary>
    /// Заявление движения на соседнюю свободную клетку
    /// </summary>
    void MoveElement(Vector3Int cubeAddress, Vector3Int moveDirection)
    {
        Cube targetCube = mapCubes[cubeAddress.x, cubeAddress.y, cubeAddress.z];

        if (targetCube == null)
        {
            Debug.LogError("Обращение к пустой ячейке");
            return;
        }

        // TODO: move correct check

        // Позиция, в которую хотим переместиться
        Vector3Int PositionAfterMove = cubeAddress + moveDirection;

        // Перемещение самого объекта
        mapCubes[cubeAddress.x, cubeAddress.y, cubeAddress.z].SetNeedPosition(PositionAfterMove);

        // Перемещение в массиве
        mapCubes[PositionAfterMove.x, PositionAfterMove.y, PositionAfterMove.z] =
            mapCubes[cubeAddress.x, cubeAddress.y, cubeAddress.z];
        mapCubes[cubeAddress.x, cubeAddress.y, cubeAddress.z] = null;
    }

    /// <summary>
    /// Проверка доступности ячейки
    /// </summary>
    public bool CheckAddress(Vector3Int addressForCheck)
    {
        //Симуляция пола
        if (addressForCheck.y < 0)
            return false;

        return mapCubes[addressForCheck.x, addressForCheck.y, addressForCheck.z] == null;
    }

    /// <summary>
    /// Проверка на возможность падения для всех элементов
    /// </summary>
    void GlobalGravitationSimulate()
    {
        for(int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    if (mapCubes[x, y, z] != null)
                        GravitationSimulate(new Vector3Int(x, y, z));
                }
            }
        }
    }

    /// <summary>
    /// Проверка на возможность падения для конкретного элемента
    /// </summary>
    void GravitationSimulate(Vector3Int cubeAddress)
    {
        Vector3Int tmp = cubeAddress + Vector3Int.down;
        if (CheckAddress(tmp))
            MoveElement(cubeAddress, Vector3Int.down);
    }
}
