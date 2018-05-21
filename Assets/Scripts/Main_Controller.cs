using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;
using UnityEngine.Experimental.UIElements;

public class Main_Controller : MonoBehaviour {

    private Rigidbody rb;
    private SerialPort stream;
    private Thread serialThread;
    private byte data = 0;
    private bool flag = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Renderer>().enabled = false;
        stream = new SerialPort("\\\\.\\COM17", 9600, Parity.None, 8, StopBits.One);
        Connect();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Connect()
    {
        try
        {
            stream.Open();
            stream.ReadTimeout = 400;
            stream.Handshake = Handshake.None;
            Debug.Log("Open");
        }
        catch (Exception e)
        {
            Debug.Log("Error opening = " + e.Message);
        }
    }
    private void recData()
    {
        while (flag == true)
        {
            if ((stream != null) && (stream.IsOpen))
            {
                try
                {
                    data = (byte)stream.ReadByte();
                    if(data == '1')
                    {
                        Do_Controller.serialData = 49;
                    }
                    else if (data == '2')
                    {
                        Re_Controller.serialData = 50;
                    }
                    else if (data == '3')
                    {
                        Me_Controller.serialData = 51;
                    }
                    else if (data == '4')
                    {
                        Fa_Controller.serialData = 52;
                    }
                    else if (data == '5')
                    {
                        So_Controller.serialData = 53;
                    }
                    //Debug.Log(data);
                    stream.BaseStream.Flush();
                }
                catch (Exception e)
                {
                    Debug.Log("Error reading = " + e.Message);
                }
            }
        }
    }
    public void Click()
    {
        flag = !flag;
        if (flag == true)
        {
            serialThread = new Thread(recData);
            serialThread.Start();
        }
    }
    private void OnApplicationQuit()
    {
        flag = false;
        stream.Close();
    }
}
