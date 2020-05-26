using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seriesManage : MonoBehaviour
{
    public GameObject wire1;
    public GameObject wire2;
    public GameObject wire3;
    public GameObject wire4;
    public GameObject wire5;
    public GameObject moveWire;
    public GameObject powerWire1;
    public GameObject powerWire2;
    public List<GameObject> wires = new List<GameObject>();

    public GameObject bulb1;
    public GameObject bulb2;

    public GameObject lightObject;
    public Light toggleLight;

    public GameObject switchBox;
    public GameObject switchLight;

    public Color state;
    public bool flow;
    public bool power;

    public Material on;
    public Material off;
    void Start()
    {
        wires.Add(wire1);
        wires.Add(wire2);
        wires.Add(wire3);
        wires.Add(wire4);
        wires.Add(wire5);
        wires.Add(moveWire);
        switchBox.GetComponent<Renderer>().material.color = Color.gray;

        power = false;
        flow = true;

        foreach (var w in wires){ w.GetComponent<Renderer>().material.color = Color.gray;}
        moveWire.GetComponent<Renderer>().material.color = Color.gray;

        toggleLight = lightObject.GetComponent<Light>();
        toggleLight.enabled = false;

        powerWire1.GetComponent<Renderer>().material.color = Color.red;
        powerWire2.GetComponent<Renderer>().material.color = Color.red;
    }


    void Update()
    {
        if (power)
        {
            state = Color.red;
            switchLight.GetComponent<Renderer>().material.color = Color.green;
            bulb1.GetComponent<Renderer>().material = on;
            bulb2.GetComponent<Renderer>().material = on;
        }
        if (!power)
        {
            state = Color.gray;
            switchLight.GetComponent<Renderer>().material.color = Color.red;
            bulb1.GetComponent<Renderer>().material = off;
            bulb2.GetComponent<Renderer>().material = off;
        }

        if (flow)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                power = !power;

                foreach (var w in wires)
                {
                    w.GetComponent<Renderer>().material.color = state;
                }

                
            }
            foreach (var w in wires)
            {
                w.GetComponent<Renderer>().material.color = state;
            }
        }
        if (!flow)
        {
            power = false;
            foreach (var w in wires)
            {
                w.GetComponent<Renderer>().material.color = state;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (flow)
            {
                moveWire.transform.Translate(0, 0, 300);
            }
            if (!flow)
            {
                moveWire.transform.Translate(0, 0, -300);
            }
            flow = !flow;
        }

        if (power)
        {
            toggleLight.enabled = true;
        }
        if (!power)
        {
            toggleLight.enabled = false;
        }
    }
}
