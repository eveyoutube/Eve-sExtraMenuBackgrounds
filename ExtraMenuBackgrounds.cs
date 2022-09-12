global using UObject = UnityEngine.Object;
using Modding;
using System;
using System.Collections.Generic;
using SFCore;
using UnityEngine;

namespace ExtraMenuBackgrounds
{
    public class ExtraMenuBackgrounds : Mod
    {
        internal static ExtraMenuBackgrounds Instance;
        
        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();
        
        public override List<ValueTuple<string, string>> GetPreloadNames() => 
            new()
            {
                ("Hive_02", "Hive flying Bee particles"),
                ("Hive_02", "Hive flying Bee particles"),
                ("Hive_02", "hive_moving diamonds"),
                ("Hive_02", "hive_moving diamonds (1)"),
                ("Hive_02", "hive_scenery_bg (12)"),
                ("Hive_02", "hive_light_effect (18)"),
                ("Hive_02", "hive_pillar_set (7)"),
                ("Hive_02", "hive_pillar_set (12)"),
                ("Hive_02", "hive_pillar_set (13)"),
                ("Hive_02", "_SceneManager"),
                
                ("Fungus3_50", "fung_BG_v08 1 (3)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (6)"),
                ("Fungus3_50", "BG_bush_set (1)"),
                ("Fungus3_50", "fung_BG_v08 1 (2)"),
                ("Fungus3_50", "fung_BG_v08 1 (5)"),
                ("Fungus3_50", "royal_garden_fog"),
                ("Fungus3_50", "royal_garden_fog (1)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (1)"),
                ("Fungus3_50", "fung_BG_v08 1 (1)"),
                ("Fungus3_50", "fung_BG_v08 1 (4)"),
                ("Fungus3_50", "royal_garden_fog"),
                ("Fungus3_50", "fung_BG_v08 1"),
                ("Fungus3_50", "royal_garden_BG_small_plant"),
                ("Fungus3_50", "royal_garden_BG_small_plant (3)"),
                ("Fungus3_50", "royal_garden_BG_structure_0000_Layer-4"),
                ("Fungus3_50", "BG_bush_set (2)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (2)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (5)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (7)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (10)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (9)"),
                ("Fungus3_50", "rg_mantis_extras_0006_bg_tooth_01"),
                ("Fungus3_50", "royal_garden_BG_small_plant (4)"),
                ("Fungus3_50", "Lazy Flyer (1)"),
                ("Fungus3_50", "royal_garden_fog (2)"),
                ("Fungus3_50", "royal_garden_BG_small_plant (8)"),
                
                ("Mines_30", "crys_cave_small_BG"),
                ("Mines_30", "cd_room_beam_glow (5)"),
                ("Mines_30", "cd_room_beam_glow (1)"),
                ("Mines_30", "mines_fog (1)"),
                ("Mines_30", "mines_fog (2)"),
                ("Mines_30", "mine_spike_33 (7)"),
                
                ("Ruins1_27", "layered_BG_building"),
                ("Ruins1_27", "Exterior Rain Audio"),
                ("Ruins1_27", "Exterior Rain Audio (1)"),
                ("Ruins1_27", "_Scenery/ruind_fountain"),
                ("Ruins1_27", "_Scenery/ruins_fog"), // there are like 4 gos with this name, hope it always pulls the same one lol
                ("Ruins1_27", "_Scenery/ruins_mid_wall_back"),
                ("Ruins1_27", "_Scenery/ruins_mid_wall_back (1)"),
                ("Ruins1_27", "_Scenery/ruins_rain"),
                ("Ruins1_27", "_Scenery/ruins_bg_building_mid"),
                ("Ruins1_27", "_Scenery/ruins_bg_building_mid (1)"),
                ("Ruins1_27", "_Scenery/ruins_sign3"),

                
                ("GG_Land_of_Storms", "shell_mounds_0003_1"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (19)"),
                ("GG_Land_of_Storms", "dunes_0002_a (15)"),
                ("GG_Land_of_Storms", "dunes_0003_a (2)"),
                ("GG_Land_of_Storms", "ruins_rain"),
                ("GG_Land_of_Storms", "lightning_set"),
                ("GG_Land_of_Storms", "dunes_0003_a (1)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (8)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (9)"),
                ("GG_Land_of_Storms", "dunes_0003_a (3)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (3)"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4 (1)"),
                ("GG_Land_of_Storms", "dunes_0003_a (5)"),
                ("GG_Land_of_Storms", "dunes_0002_a (18)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (18)"),
                ("GG_Land_of_Storms", "Particle System (1)"),
                ("GG_Land_of_Storms", "dream_particle_03 (1)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (2)"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4"),
                ("GG_Land_of_Storms", "dunes_0003_a (4)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (7)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (1)"),
                ("GG_Land_of_Storms", "shell_mounds_0003_1 (10)"),
                ("GG_Land_of_Storms", "dunes_0002_a (2)"),
                ("GG_Land_of_Storms", "black_fader"),
                ("GG_Land_of_Storms", "town_particle_set"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4_back"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4_back (14)"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4_back (5)"),
                ("GG_Land_of_Storms", "gg_waterways_0003_4_back (2)"),
                ("GG_Land_of_Storms", "dunes_0000_a (6)"),
                ("GG_Land_of_Storms", "gg_waterways_0002_5 (7)"),
                ("GG_Land_of_Storms", "Audio Field"),
                ("GG_Land_of_Storms", "Audio Field (1)"),
                ("GG_Land_of_Storms", "Audio Field (2)"),
            };

        public ExtraMenuBackgrounds() : base("ExtraMenuBackgrounds")
        {
            Instance = this;
            Log("Registering Menus");
            ModHooks.LanguageGetHook += OnLanguageGetHook;
            MenuStyleHelper.AddMenuStyleHook += PeakMenuStyle.Register;
            MenuStyleHelper.AddMenuStyleHook += QGMenuStyle.Register;
            MenuStyleHelper.AddMenuStyleHook += HiveMenuStyle.Register;
            MenuStyleHelper.AddMenuStyleHook += CityMenuStyle.Register;
            MenuStyleHelper.AddMenuStyleHook += StormMenuStyle.Register;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Populating Menus");
            HiveMenuStyle.Populate(preloadedObjects);
            QGMenuStyle.Populate(preloadedObjects);
            PeakMenuStyle.Populate(preloadedObjects);
            CityMenuStyle.Populate(preloadedObjects);
            StormMenuStyle.Populate(preloadedObjects);
        }

        private static string OnLanguageGetHook(string key, string sheetTitle, string orig)
        {
            // Menu names appear to need to be in CP3
            // Since all my menu names are already localized in different sheets we redirect language requests
            if (sheetTitle != "CP3") return orig;
            return key switch
            {
                "HIVE" => Language.Language.Get(key, "Map Zones"),
                "MAP_NAME_ROYAL_GARDENS" => Language.Language.Get(key, "UI"),
                "MAP_NAME_MINES" => Language.Language.Get(key, "UI"),
                "MAP_NAME_CITY" => Language.Language.Get(key, "UI"),
                "STORMLAND" => $"{Language.Language.Get("STORMLAND_SUPER", "CP3")} {Language.Language.Get("STORMLAND_MAIN", "CP3")} {Language.Language.Get("STORMLAND_SUB", "CP3")}",
                _ => orig
            };
        }
    }
}