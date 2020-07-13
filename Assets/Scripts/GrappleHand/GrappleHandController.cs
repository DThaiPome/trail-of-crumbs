﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHandController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private KeyCode launchKey;
    [SerializeField]
    private float speed;

    private Rigidbody rb;
    private Rigidbody playerRb;
    
    private enum ControlState
    {
        Resting, Launching, Retracting, PullingPlayer
    }

    private ControlState controlState;

    void Start()
    {
        this.playerRb = player.GetComponent<Rigidbody>();
        this.rb = this.GetComponent<Rigidbody>();
        controlState = ControlState.Resting;
    }

    void Update()
    {
        switch(this.controlState)
        {
            case ControlState.Resting:
                this.RestingUpdate();
                break;
            case ControlState.Launching:
                this.LaunchingUpdate();
                break;
            case ControlState.Retracting:
                this.RetractingUpdate();
                break;
            case ControlState.PullingPlayer:
                this.PullingPlayerUpdate();
                break;
        }
    }

    private void RestingUpdate()
    {
        this.transform.SetParent(this.player.transform);

        if (Input.GetKeyDown(this.launchKey))
        {
            this.controlState = ControlState.Launching;
            this.player.transform.DetachChildren();
        }
    }

    private void LaunchingUpdate()
    {

    }

    private void RetractingUpdate()
    {

    }

    private void PullingPlayerUpdate()
    {

    }

    void FixedUpdate()
    {
        switch (this.controlState)
        {
            case ControlState.Resting:
                this.RestingFixedUpdate();
                break;
            case ControlState.Launching:
                this.LaunchingFixedUpdate();
                break;
            case ControlState.Retracting:
                this.RetractingFixedUpdate();
                break;
            case ControlState.PullingPlayer:
                this.PullingPlayerFixedUpdate();
                break;
        }
    }

    private void RestingFixedUpdate()
    {

    }

    private void LaunchingFixedUpdate()
    {
        Vector3 offset = this.transform.position + (this.transform.forward * this.speed * Time.fixedDeltaTime);
        this.rb.MovePosition(offset);
    }

    private void RetractingFixedUpdate()
    {

    }

    private void PullingPlayerFixedUpdate()
    {

    }
}
