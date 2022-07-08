using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Mapbox.Unity.Map;

public class MapZoom : MonoBehaviour
{
    // zoomDiff = +1 , for zoom-In
    // zoomDiff = -1 , for zoom-Out

    [SerializeField]
    Mapbox.Unity.Map.AbstractMap _mapManager;

    
    public bool mapCalibrated = false;
    public int mapScale = 1;

    public static MapZoom instance;
    void Awake()
    {
        instance = this;
    }

    public void CalibrateMap()
    {
        MapHeightCalculator.instance.calibratedMapPositionY = MapTileManager.instance.map.transform.position.y + MapHeightCalculator.instance.minVal;

        _mapManager.GetComponent<ManipulationHandler>().enabled = false;

        mapCalibrated = true;
    }

    public void ChangeMapScale(bool isIncrease)
    {
        if (isIncrease && mapScale < 3)
        {
            mapScale++;
        }
        else if (!isIncrease && mapScale > 1)
        {
            mapScale--;
        }
        else
        {
            return;
        }

        var mapExtentOptions = _mapManager._options.extentOptions;
        mapExtentOptions.extentType = MapExtentType.RangeAroundCenter;
        mapExtentOptions.defaultExtents.rangeAroundCenterOptions.north = mapScale;
        mapExtentOptions.defaultExtents.rangeAroundCenterOptions.south = mapScale;
        mapExtentOptions.defaultExtents.rangeAroundCenterOptions.west = mapScale;
        mapExtentOptions.defaultExtents.rangeAroundCenterOptions.east = mapScale;

        ExtentOptions extentOptions = new ExtentOptions();

        var currentOptions = _mapManager._options.extentOptions.GetTileProviderOptions();

        if (currentOptions.GetType() == extentOptions.GetType())
        {
            currentOptions = extentOptions;
        }

        _mapManager.OnTileProviderChanged();
        _mapManager.UpdateMap();
        MapTileManager.instance.GenerateTileList();
    }

    public void GetZoomAction(double lat, double lon, int zoomDiff)
    {
        var MapTileInstance = MapTileManager.instance;
        float zoom = MapTileInstance.map.AbsoluteZoom + zoomDiff;
        MapTileInstance.map.UpdateMap(new Mapbox.Utils.Vector2d(lat, lon), zoom);
    }

    public void ZoomIn()
    {
        _mapManager.SetZoom(_mapManager.Zoom + 1f);
        _mapManager.UpdateMap();
    }

    public void ZoomOut()
    {
        _mapManager.SetZoom(_mapManager.Zoom - 1f);
        _mapManager.UpdateMap();
    }
}
