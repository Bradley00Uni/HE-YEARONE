using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cellButtons : MonoBehaviour
{
    public Text componentName;
    public Text componentInfo;

    public Button amyloplast;
    public Button vacuole;
    public Button membrane;
    public Button mitochondria;
    public Button chloroplast;
    public Button golgi;
    public Button wall;
    public Button ribosome;
    public Button er;
    public Button nucleus;
    public Button cytoplasm;
    public static List<Button> buttons = new List<Button>();

    public Sprite unclicked;
    public Sprite clicked;

    static string n = "";
    static string i = "";
    static string v = "";

    public void Start()
    {
        buttons = new List<Button>() { amyloplast, vacuole, membrane, mitochondria, chloroplast, golgi, wall, ribosome, er, nucleus, cytoplasm };
    }

    public void Update()
    {
        componentName.text = n;
        componentInfo.text = i;

        foreach (var b in buttons)
        {
            if(v == b.name)
            b.GetComponent<Image>().sprite = clicked;
            else
            {
                b.GetComponent<Image>().sprite = unclicked;
            }
        }
    }

    public void Amyloplast()
    {
        n = "Amyloplast";
        i = "Amyloplasts are leucoplasts that function mainly in starch storage. They are colourless and are found in plant tissues that do not undergo photosynthesis (like the roots and seeds). They synthesize temporary starch that is not permanently stored in the chloroplasts. They also help to orient root growth downward, towards the directions of gravity.";
        v = amyloplast.name;
    }

    public void Vacuole()
    {
        n = "Vacuole";
        i = "Vacuoles are much larger in plant cells than animal cells. They can store food or any or any variety of nutrients a cell might need to survive. They will even store waste products so that the rest of the cell is protected from contamination. Eventually those waste products will be removed from the cell. The vacuole can sometimes take up more than half the cells’ volume. The contents inside the vacuole are more commonly known as ‘Sap’.";
        v = vacuole.name;
    }

    public void Membrane()
    {
        n = "Cell Membrane";
        i = "All cells are contained by a cell membrane. These are found between the cytoplasm and cell wall of a plant cell. It is semi-permeable, meaning it will allow specific substances to pass through it while preventing the passage of others. It can also be another layer of protection for the contents of the cell.";
        v = membrane.name;
    }

    public void Mitochondria()
    {
        n = "Mitochondria";
        i = "They are known as the powerhouses of the cell. They act like a digestive system in a cell, they take in nutrients, break them down and create energy rich molecules for the cell. They are more commonly recognised for Aerobic Respiration (requires oxygen and glucose to produce carbon dioxide, water and energy), as this respiration’s reactions occur in the mitochondria. They are working organelles that maintain a strong amount of energy for the cell.";
        v = mitochondria.name;
    }

    public void Chloroplast()
    {
        n = "Chloroplast";
        i = "These are not found in animal cells and are key in a plant cell. Photosynthesis takes place in the chloroplast, hence why they are known as the food producers. They work to convert light energy of the sun into sugars that can be used by cells ( this is the photosynthesis process). Chloroplasts all contain chlorophyll, which is what the photosynthesis depends on to occur, the chlorophyll sit on the surface of each chloroplast and capture light energy from the sun. The chloroplast requires carbon dioxide and water to produce glucose and oxygen.";
        v = chloroplast.name;
    }

    public void Golgi()
    {
        n = "Golgi Body";
        i = "The Golgi Body is responsible for transporting, modifying and packaging the proteins and lipids into vesicles that can then be transported to where they are needed within the plant.";
        v = golgi.name;
    }

    public void Wall()
    {
        n = "Cell Wall";
        i = "Cell walls are made of cellulose, and only surround plant cells and a few other organisms. The cellulose inside is a specialised sugar that is classified as a structural carbohydrate. As well as protecting the cell, they also allow plants to grow to great heights. The wall can be slightly elastic for smaller plants, leaves and thin branches. ";
        v = wall.name;
    }

    public void Ribosome()
    {
        n = "Ribosomes";
        i = "Ribosomes are used when a cell is in need to make proteins. They are the protein builders/photosynthesizers of the cell. They can be found floating in the cytoplasm or in the endoplasmic reticulum (ER). The main role is to manufacture and assemble all the proteins in the cell.";
        v = ribosome.name;
    }

    public void ER()
    {
        n = "ER";
        i = "Endoplasmic Reticulum has two major regions: the smooth ER and the rough ER. Rough ER contains ribosomes whilst smooth ER does not. Rough ER manufacturers membranes and synthesises proteins, but smooth ER serves as a transitional area for transport vesicles. The ER in general plays a role in the productions, processing and transport of proteins and liquids.";
        v = er.name;
    }

    public void Nucleus()
    {
        n = "Nucleus";
        i = "The nucleus contains most of the cell’s genetic material (DNA) and contains the cell’s activities including growth, metabolism, cell division and protein synthesis. It controls gene expression and mediates in its own nuclear membrane and it generally just acts as the brain of the cell.";
        v = nucleus.name;
    }

    public void Cytoplasm()
    {
        n = "Cytoplasm";
        i = "Cytoplasm is the liquid that fills a cell, like the blood in other organisms. ‘Cyto’ means cell and ‘plasm’ means blood. The cytoplasm is responsible for giving the cell its shape. They contain molecules such as enzymes which are responsible in the cell for breaking down waste and aid in metabolic activity.";
        v = cytoplasm.name;
    }
}
