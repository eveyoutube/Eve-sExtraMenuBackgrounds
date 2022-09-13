using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.Audio;

namespace ExtraMenuBackgrounds;

public static class HiveMenuStyle
{
    private static GameObject MenuStyle;
    private static GameObject ContentPrefab;
    private static GameObject AudioSourcePrefab;


    private static readonly Dictionary<string, Vector3> PositionOverrides = new()
    {
        { "hive_light_effect (18)", new Vector3(49f, 0f, 150f) },
        { "hive_pillar_set (7)", new Vector3(-30f, 0f, 150f) },
        { "hive_pillar_set (12)", new Vector3(32f, 0f, 166.6f) },
        { "hive_pillar_set (13)", new Vector3(50f, 0f, 124f) },
    };

    public static (string, GameObject, int, string, string[], MenuStyles.MenuStyle.CameraCurves, AudioMixerSnapshot)
        Register(MenuStyles stylesParent)
    {
        MenuStyle = new GameObject("Hive_Style");

        var ggStyleT = stylesParent.gameObject.transform.GetChild(5);
        UObject.Instantiate(ggStyleT.GetChild(4).gameObject, MenuStyle.transform, true); // vignette_large_v01
        UObject.Instantiate(ggStyleT.GetChild(5).gameObject, MenuStyle.transform, true); // BG_colour
        UObject.Instantiate(ggStyleT.GetChild(7).gameObject, MenuStyle.transform, true); // BG_colour (2)

        AudioSourcePrefab = stylesParent.transform.GetChild(9).GetChild(17).gameObject; // :zote:/Singing

        if (ContentPrefab is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
        return ("HIVE", MenuStyle, -1, "", null, null, null);
    }


    public static void Populate(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        if (ContentPrefab is not null) return;
        ContentPrefab = new GameObject("Style_Content");

        foreach (var (objName, obj) in preloadedObjects["Hive_02"])
        {
            if (objName == "_SceneManager") continue;
            obj.transform.SetParent(ContentPrefab.transform, true);
            if (PositionOverrides.ContainsKey(objName))
                obj.transform.position = PositionOverrides[objName];
            else
                obj.transform.SetPosition2D(0, 0);
            obj.SetActive(true);
        }

        var audioSource = UObject.Instantiate(AudioSourcePrefab, ContentPrefab.transform, true)
            .GetComponent<AudioSource>();
        audioSource.clip = ReflectionHelper
            .GetField<SceneManager, MusicCue>(preloadedObjects["Hive_02"]["_SceneManager"].GetComponent<SceneManager>(),
                "musicCue").GetChannelInfo(MusicChannels.Main).Clip;
        audioSource.Play();

        UObject.Instantiate(Camera.current.transform.Find("SceneParticlesController/hive_drip_particles"),
            ContentPrefab.transform).gameObject.SetActive(true);
        ContentPrefab.AddComponent<MenuLighting>().color = new Color(0.874f, 0.678f, 0.430f, 1.000f);
        
        ContentPrefab.SetActive(false);
        UObject.DontDestroyOnLoad(ContentPrefab);
        
        if (MenuStyle is not null)
            UObject.Instantiate(ContentPrefab, MenuStyle.transform, true).SetActive(true);
    }
}