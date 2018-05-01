using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class So_Controller : MonoBehaviour {

    private Rigidbody rb;
    public static byte serialData;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialData == '5')
        {
            rb.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            rb.GetComponent<Renderer>().enabled = true;
        }
        serialData = 0;
    }
}
