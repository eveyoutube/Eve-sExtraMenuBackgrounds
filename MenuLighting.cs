using System;
using UnityEngine;

namespace ExtraMenuBackgrounds
{
    public class MenuLighting : MonoBehaviour
    {
        private static readonly Color DefaultColor = new Color(0.28f, 0.364f, 0.481f, 1);
        public Color color;

        public void Update() => RenderSettings.ambientLight = color;
        public void OnDisable() => RenderSettings.ambientLight = DefaultColor;
    }
}