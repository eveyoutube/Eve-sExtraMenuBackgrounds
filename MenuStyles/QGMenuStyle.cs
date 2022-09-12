using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.Audio;

namespace ExtraMenuBackgrounds;

public static class QGMenuStyle
{
    public static GameObject MenuStyle;
    public static GameObject ContentPrefab;


    public static (string, GameObject, int, string, string[], MenuStyles.MenuStyle.CameraCurves, AudioMixerSnapshot)
        Register(MenuStyles stylesParent)
    {
        MenuStyle = new GameObject("Queens_Gardens_Style");
        UObject.DontDestroyOnLoad(MenuStyle);
        if (ContentPrefab is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
        return ("MAP_NAME_ROYAL_GARDENS", MenuStyle, -1, "", null, null, null);
    }

    public static void Populate(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        if (ContentPrefab is not null) return;
        ContentPrefab = new GameObject("Style_Contents");
        foreach (var (objName, obj) in preloadedObjects["Fungus3_50"])
        {
            obj.transform.SetParent(ContentPrefab.transform, true);
            obj.SetActive(true);
        }

        ContentPrefab.transform.SetPosition3D(5.7418f, -118.296f, 1.5727f);
        ContentPrefab.transform.SetScaleZ(0.7f);
        UObject.Instantiate(Camera.current.transform.Find("SceneParticlesController/royal_garden_particles"),
            ContentPrefab.transform, true).gameObject.SetActive(true);
        
        
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);
        
        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}