using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChange : MonoBehaviour
{
    public Text elementName;
    public Text elementInfo;
    public GameObject Hydrogen1;
    public GameObject Hydrogen2;
    public GameObject Hydrogen3;
    public GameObject Hydrogen4;
    public GameObject Carbon;
    public GameObject model;
    List<GameObject> Hydrogen = new List<GameObject>();
    List<GameObject> Chemicals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Hydrogen = new List<GameObject>() { Hydrogen1, Hydrogen2, Hydrogen3, Hydrogen4 };
        Chemicals = new List<GameObject>() { Hydrogen1, Hydrogen2, Hydrogen3, Hydrogen4, Carbon };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 40000.0f))
            {
                if(hit.transform.name == Carbon.name)
                {
                    elementInfo.text = "Despite Carbon’s ability to make 4 bonds and its presence in many compounds, it is highly unreactive in normal conditions. With the chemical symbol ‘C’ and the atomic number 6. Carbon has different allotropes (different forms in which it can exist), which include graphite and diamond, both with vastly different properties.";
                    elementName.text = "Carbon";
                }
                foreach (var h in Hydrogen)
            {
                if(hit.transform.name == h.name)
                {
                    elementInfo.text = "Hydrogen is the lightest element and despite its stability, it can form many bonds and is present in many different compounds. It is the smallest chemical element, due to only consisting of one proton in its nucleus. With the chemical symbol ‘H’ and the atomic number 1. Hydrogen is the most abundant chemical substance in the universe.";
                    elementName.text = "Hydrogen";
                }
            }
            }
            
        }
    }
}
