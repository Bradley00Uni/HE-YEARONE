using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;
    public GameObject object8;
    public GameObject object9;
    public GameObject object10;
    public GameObject object11;
    public GameObject object12;
    public GameObject object13;
    public GameObject object14;
    public GameObject object15;
    public GameObject object16;
    public GameObject object17;
    public List<GameObject> wires = new List<GameObject>();
    public List<GameObject> boxes = new List<GameObject>();
    public List<GameObject> lights = new List<GameObject>();

    public GameObject Biology;
    public GameObject Chemistry1;
    public GameObject Chemistry2;
    public GameObject Physics1;
    public GameObject Physics2;

    public void LoadBiology()
    {
        SceneManager.LoadScene("Biology");
    }

    public void LoadChemistry1()
    {
        SceneManager.LoadScene("Chemistry1");
    }

    public void LoadChemistry2()
    {
        SceneManager.LoadScene("Chemistry2");
    }

    public void LoadPhysics1()
    {
        SceneManager.LoadScene("Physics1");
    }

    public void LoadPhysics2()
    {
        SceneManager.LoadScene("Physics2");
    }

    public void ExitSoftware()
    {
        Application.Quit();
    }

    public void Start()
    {
        wires = new List<GameObject>() { object1, object2, object3, object4, object5, object6, object7, object8, object9, object14, object15, object16, object17 };
        boxes = new List<GameObject>() { object12, object13 };
        lights = new List<GameObject>() { object10, object11 };

        foreach (var w in wires)
        {
            w.GetComponent<Renderer>().material.color = Color.red;
        }
        foreach (var b in boxes)
        {
            b.GetComponent<Renderer>().material.color = Color.grey;
        }
        foreach (var l in lights)
        {
            l.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 40000.0f))
            {
                if(hit.transform.name == Biology.name)
                {
                    LoadBiology();
                }
                if (hit.transform.name == Chemistry1.name)
                {
                    LoadChemistry1();
                }
                if (hit.transform.name == Chemistry2.name)
                {
                    LoadChemistry2();
                }
                if (hit.transform.name == Physics1.name)
                {
                    LoadPhysics1();
                }
                if (hit.transform.name == Physics2.name)
                {
                    LoadPhysics2();
                }
            }
        }
    }
}
