using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.Audio;

namespace ExtraMenuBackgrounds;

public static class CityMenuStyle
{
    public static GameObject MenuStyle;
    public static GameObject ContentPrefab;

    public static (string, GameObject, int, string, string[], MenuStyles.MenuStyle.CameraCurves, AudioMixerSnapshot)
        Register(MenuStyles stylesParent)
    {
        MenuStyle = new GameObject("City_Menu_Style");
        if (ContentPrefab is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
        return ("MAP_NAME_CITY", MenuStyle, -1, "", null, null, null);
    }

    public static void Populate(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        if (ContentPrefab is not null) return;
        ContentPrefab = new GameObject("Style_Contents");

        foreach (var (objName, obj) in preloadedObjects["Ruins1_27"])
        {
            obj.transform.SetParent(ContentPrefab.transform, true);
            obj.SetActive(true);
        }

        ContentPrefab.transform.SetPosition3D(-14.7867f, -5.8182f, -2.18f);

        Object.Instantiate(Camera.current.transform.Find("SceneParticlesController/ruins_interior_particles"),
            ContentPrefab.transform, true).gameObject.SetActive(true);
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);

        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}