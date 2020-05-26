using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChange2 : MonoBehaviour
{
    public Text elementName;
    public Text elementInfo;

    public GameObject Hydrogen1;
    public GameObject Hydrogen2;
    public GameObject Oxygen1;
    public GameObject Oxygen2;

    List<GameObject> Oxygen = new List<GameObject>();
    List<GameObject> Hydrogen = new List<GameObject>();

    void Start()
    {
        Hydrogen = new List<GameObject>() { Hydrogen1, Hydrogen2 };
        Oxygen = new List<GameObject>() { Oxygen1, Oxygen2 };
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 40000.0f))
            {
                foreach (var o in Oxygen)
                {
                    if (hit.transform.name == o.name)
                    {
                        elementInfo.text = "Oxygen is an important part of the atmosphere. It makes up most of the mass of living organisms and it comprises most of its mass in water. Oxygen is a member of the chalcogen group in the periodic table and is a highly reactive non-metallic element. With the chemical symbol ‘O’ and the atomic number 8. It is used in cellular respiration by most living organisms on Earth.";
                        elementName.text = "Oxygen";
                    }
                }
                foreach (var h in Hydrogen)
                {
                    if (hit.transform.name == h.name)
                    {
                        elementInfo.text = "Hydrogen is the lightest element and despite its stability, it can form many bonds and is present in many different compounds. It is the smallest chemical element, due to only consisting of one proton in its nucleus. With the chemical symbol ‘H’ and the atomic number 1. Hydrogen is the most abundant chemical substance in the universe.";
                        elementName.text = "Hydrogen";
                    }
                }
            }
        }
    }
}
