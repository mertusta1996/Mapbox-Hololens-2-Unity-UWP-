using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHeightFixer : MonoBehaviour
{
    void FixedUpdate()
    {
        if (MapZoom.instance.mapCalibrated)
        {
            var map = MapTileManager.instance.map;
            map.transform.position = new Vector3(map.transform.position.x,
                MapHeightCalculator.instance.calibratedMapPositionY - MapHeightCalculator.instance.minVal, map.transform.position.z);
        }
    }
}
