using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageWires : MonoBehaviour
{
    public GameObject staticWire1;
    public GameObject staticWire2;
    public GameObject staticWire3;
    public GameObject staticWire4;
    public GameObject movingWire1;
    public GameObject movingWire2;
    public GameObject movingWire3;
    public GameObject movingBulb;
    public GameObject staticBulb;
    public GameObject switchBox;
    public GameObject switchLight;
    public GameObject powerWire1;
    public GameObject powerWire2;

    public GameObject lightObject;
    public Light toggleLight;


    public Material active;
    public Material off;

    public bool on;
    public Color wire;
    public bool connected;

    public List<GameObject> staticWires = new List<GameObject>();
    public List<GameObject> movingObjects = new List<GameObject>();

    void Start()
    {
        on = false;
        connected = true;
        staticWires.Add(staticWire1);
        staticWires.Add(staticWire2);
        staticWires.Add(staticWire3);
        staticWires.Add(staticWire4);

        movingObjects.Add(movingWire1);
        movingObjects.Add(movingWire2);
        movingObjects.Add(movingWire3);

        switchBox.GetComponent<Renderer>().material.color = Color.gray;
        powerWire1.GetComponent<Renderer>().material.color = Color.red;
        powerWire2.GetComponent<Renderer>().material.color = Color.red;

        foreach (var m in movingObjects)
        {
            m.GetComponent<Renderer>().material.color = Color.gray;
        }
        foreach (var s in staticWires)
        {
            s.GetComponent<Renderer>().material.color = Color.gray;
        }

        toggleLight = lightObject.GetComponent<Light>();
        toggleLight.enabled = false;
        movingBulb.GetComponent<Renderer>().material = off;
    }


    void Update()
    {
        if (on)
        {
            wire = Color.gray;
            switchLight.GetComponent<Renderer>().material.color = Color.green;
            staticBulb.GetComponent<Renderer>().material = active;
        }
        if (!on)
        {
            wire = Color.red;
            switchLight.GetComponent<Renderer>().material.color = Color.red;
            staticBulb.GetComponent<Renderer>().material = off;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            on = !on;

            foreach(var s in staticWires)
            {
                s.GetComponent<Renderer>().material.color = wire;
            }

            if (connected)
            {
                foreach(var m in movingObjects)
                {
                    m.GetComponent<Renderer>().material.color = wire;
                }
            }

            if (!connected)
            {
                toggleLight.enabled = false;
            }
            else if (connected)
            {
                if (!on)
                {
                    toggleLight.enabled = false;
                    movingBulb.GetComponent<Renderer>().material = off;
                }
                if (on)
                {
                    toggleLight.enabled = true;
                    movingBulb.GetComponent<Renderer>().material = active;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (connected)
            {
                movingWire1.transform.Translate(200, 0, 0);
                movingWire2.transform.Translate(200, 0, 0);
                movingWire3.transform.Translate(0, 0, 200);
                movingBulb.transform.Translate(200, 0, 0);

                foreach (var m in movingObjects)
                {
                    m.GetComponent<Renderer>().material.color = Color.gray;
                }
                toggleLight.enabled = false;
                movingBulb.GetComponent<Renderer>().material = off;
            }
            if (!connected)
            {
                movingWire1.transform.Translate(-200, 0, 0);
                movingWire2.transform.Translate(-200, 0, 0);
                movingWire3.transform.Translate(0, 0, -200);
                movingBulb.transform.Translate(-200, 0, 0);
                
                if(staticWire1.GetComponent<Renderer>().material.color == Color.red)
                {
                    foreach (var m in movingObjects)
                    {
                        m.GetComponent<Renderer>().material.color = Color.red;
                        toggleLight.enabled = true;
                        movingBulb.GetComponent<Renderer>().material = active;
                    }
                }
            }
            connected = !connected;
        }
    }
}
