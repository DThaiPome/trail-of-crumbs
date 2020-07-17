﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightBehavior : MonoBehaviour
{
    // x rotation values
    public float xPosnOne = 90;
    public float xPosnTwo = 25;

    // in case light hits player
    public Transform player;
    // attached light object
    //public Light spotlight;

    Quaternion posnOneRot;
    Quaternion posnTwoRot;
    Quaternion maxRotation;
   
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        float yAngle = this.transform.localEulerAngles.y;
        float zAngle = this.transform.localEulerAngles.z;

        posnOneRot = Quaternion.Euler(new Vector3(xPosnOne, yAngle, zAngle));
        posnTwoRot = Quaternion.Euler(new Vector3(xPosnTwo, yAngle, zAngle));
        maxRotation = posnTwoRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.isGameOver)
        {
            if (transform.rotation == posnOneRot)
            {
                //Quaternion.Set(x, y, z, w);
                maxRotation = posnTwoRot;
            }
            else if (transform.rotation == posnTwoRot)
            {
                maxRotation = posnOneRot;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation,
                maxRotation, Time.deltaTime);
        } else
        {
            transform.LookAt(this.player);
        }
    }
}

