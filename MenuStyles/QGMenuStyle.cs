using System.Collections.Generic;
using Modding;
using SFCore.Utils;
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
        foreach (var (objName, obj) in preloadedObjects["Fungus3_05"])
        {
            obj.transform.SetParent(ContentPrefab.transform, true);
            obj.SetActive(true);
        }

        var fogT = ContentPrefab.FindGameObjectInChildren("royal_garden_fog(Clone)").transform;
        fogT.position = new Vector3(34.8294f, 50.0336f, 6.7f);
        fogT.localScale = new Vector3(4.8767f, 4.8767f, 4.8767f);
        
        ContentPrefab.transform.SetPosition3D(-20.3059f, -39.2744f, 0);
        
        UObject.Instantiate(Camera.current.transform.Find("SceneParticlesController/royal_garden_particles"),
            ContentPrefab.transform, true).gameObject.SetActive(true);

        ContentPrefab.AddComponent<MenuLighting>().color = new Color(0.8888f*0.8f, 1.0074f*0.8f, 0.9518f*0.8f, 1);
        
        
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);
        
        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}