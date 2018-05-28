using UnityEngine;
using System.Collections;

public class ColorBase : MonoBehaviour
{
    public static ColorBase instance;

    public Material gold;
    public Material red;

    void Awake()
    {
        instance = this;
    }
}
