using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
namespace ExtraMenuBackgrounds;

public class MenuParallax : MonoBehaviour
{
    // Unused. This was just an experiment, may return to it.
    private Vector3 basePosition;
    public float strength = 1.0f;
    public float snappiness = 0.5f;
    
    public void Start()
    {
        basePosition = transform.position;
    }

    public void Update()
    {
        transform.SetPositionX(Mathf.Lerp(transform.position.x, basePosition.x + strength*(Camera.current.ScreenToViewportPoint(Input.mousePosition).x - 0.5f), Mathf.Pow(0.5f, 50*Time.deltaTime)));
    }
}