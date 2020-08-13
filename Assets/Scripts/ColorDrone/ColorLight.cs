﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpotlightDetectPlayer))]
[RequireComponent(typeof(Light))]
public class ColorLight : MonoBehaviour
{
    [SerializeField]
    private ColorDroneSpotlightColor color;

    private SpotlightDetectPlayer sdp;
    private Light light;

    void Start()
    {
        this.sdp = this.GetComponent<SpotlightDetectPlayer>();
        this.light = this.GetComponent<Light>();
    }

    void Update()
    {
        this.SetColor();
        this.UpdateLight();
    }

    private void UpdateLight()
    {
        this.SetEnabled(ColorFlipper.activeColor == this.color);
    }

    private void SetEnabled(bool enabled)
    {
        this.light.enabled = enabled;
        this.sdp.enabled = enabled;
    }

    private void SetColor()
    {
        switch(this.color)
        {
            case ColorDroneSpotlightColor.Red:
                this.light.color = Color.red;
                break;
            case ColorDroneSpotlightColor.Blue:
                this.light.color = Color.blue;
                break;
            default:
                this.light.color = Color.white;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        this.Start();
        this.SetColor();
    }
}
