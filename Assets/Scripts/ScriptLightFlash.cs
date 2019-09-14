﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLightFlash : MonoBehaviour
{
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
