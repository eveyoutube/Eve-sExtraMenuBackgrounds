using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.Audio;

namespace ExtraMenuBackgrounds;

public static class PeakMenuStyle
{
    public static GameObject MenuStyle;
    public static GameObject ContentPrefab;

    public static (string, GameObject, int, string, string[], MenuStyles.MenuStyle.CameraCurves, AudioMixerSnapshot)
        Register(MenuStyles stylesParent)
    {
        MenuStyle = new GameObject("Crystal_Peak_Style");
        UObject.Instantiate(stylesParent.transform.GetChild(1).GetChild(2).gameObject, MenuStyle.transform,
            true); // yoink the vignette from hd menu style
        if (ContentPrefab is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
        return ("MAP_NAME_MINES", MenuStyle, -1, "", null, null, null);
    }

    public static void Populate(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        if (ContentPrefab is not null) return;
        ContentPrefab = new GameObject("Style_Contents");

        foreach (var (objName, obj) in preloadedObjects["Mines_30"])
        {
            obj.transform.SetParent(ContentPrefab.transform, true);
            obj.SetActive(true);
        }

        ContentPrefab.transform.SetPosition3D(-82.9f, 1.53f, -8.65f);
        ContentPrefab.transform.SetScaleZ(0.5f);

        Object.Instantiate(Camera.current.transform.Find("SceneParticlesController/mines_particles"),
            ContentPrefab.transform, true).gameObject.SetActive(true);
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);
        
        ContentPrefab.AddComponent<MenuParallax>();

        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}