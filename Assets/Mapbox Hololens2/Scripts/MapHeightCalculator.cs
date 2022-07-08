using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapHeightCalculator : MonoBehaviour
{
    public float minVal=0;
    public List<float> yValues = new List<float>();
    public float calibratedMapPositionY;

    public static MapHeightCalculator instance;


    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        var tileList = MapTileManager.instance.tileList;
        for (int i=0; i< tileList.Count; i++)
        {
            if (yValues[i] != tileList[i].mesh.bounds.min.y)
            {
                yValues[i] = tileList[i].mesh.bounds.min.y;
            }
        }
        if (yValues.Count > 0)
        {
            minVal = yValues.Min();
        } 
    }
}
