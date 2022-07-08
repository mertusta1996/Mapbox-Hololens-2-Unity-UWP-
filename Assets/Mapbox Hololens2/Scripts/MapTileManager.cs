using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;
using Mapbox.Unity.MeshGeneration.Data;

public class MapTileManager : MonoBehaviour,IMixedRealityPointerHandler
{
    public AbstractMap map;

    public List<MeshFilter> tileList = new List<MeshFilter>();

    public static MapTileManager instance;

    void Awake()
    {
        instance = this;

        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        CreateTileList();
    }

    public void CreateTileList()
    {
        Invoke("GenerateTileList", 1f);
    }
    public void GenerateTileList()
    {
        tileList.Clear();
        MapHeightCalculator.instance.yValues.Clear();

        for (int i = 0; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).GetComponent<UnityTile>() != null 
                && map.transform.GetChild(i).GetComponent<MeshFilter>() != null 
                && map.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                tileList.Add(map.transform.GetChild(i).GetComponent<MeshFilter>());
                MapHeightCalculator.instance.yValues.Add(0);
            }
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (CoreServices.InputSystem.FocusProvider.PrimaryPointer.Result.Details.Object.layer != 6)
        {
            return;
        }

        var a = map.WorldToGeoPosition(eventData.Pointer.BaseCursor.Position);
        map.SetCenterLatitudeLongitude(a);
        map.UpdateMap();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
    }
    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }
    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }
}
