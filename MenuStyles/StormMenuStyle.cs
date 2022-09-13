using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.Audio;

namespace ExtraMenuBackgrounds;

public static class StormMenuStyle
{
    public static GameObject MenuStyle;
    public static GameObject ContentPrefab;

    public static (string, GameObject, int, string, string[], MenuStyles.MenuStyle.CameraCurves, AudioMixerSnapshot)
        Register(MenuStyles stylesParent)
    {
        MenuStyle = new GameObject("Storm_Menu_Style");
        if (ContentPrefab is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
        return ("STORMLAND", MenuStyle, -1, "", null, null, null);
    }

    public static void Populate(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        if (ContentPrefab is not null) return;
        ContentPrefab = new GameObject("Style_Contents");

        foreach (var (objName, obj) in preloadedObjects["GG_Land_of_Storms"])
        {
            obj.transform.SetParent(ContentPrefab.transform, true);
            obj.SetActive(true);
        }

        ContentPrefab.transform.SetPosition3D(-86.7f, -12f, 0);

        // Object.Instantiate(Camera.current.transform.Find("SceneParticlesController/ruins_interior_particles"),ContentPrefab.transform, true).gameObject.SetActive(true);
        
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);

        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}