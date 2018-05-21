using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.Experimental.UIElements;

public class Do_Controller : MonoBehaviour {

    private Rigidbody rb;
    public static byte serialData = 0;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update ()
    {
        if (serialData == '1')
        {
            rb.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            rb.GetComponent<Renderer>().enabled = false;
        }
        serialData = 0;
    }
}