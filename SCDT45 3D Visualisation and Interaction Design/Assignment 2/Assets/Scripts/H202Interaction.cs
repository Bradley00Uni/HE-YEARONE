using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H202Interaction : MonoBehaviour
{
    public GameObject model;
    bool isSpinning = false;
    bool isBackwards = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isBackwards = true;
            isSpinning = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isBackwards = false;
            isSpinning = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBackwards = false;
            isSpinning = false;
        }
        if (isSpinning)
        {
            model.transform.Rotate(0f, 1f, 0f);
        }
        if (isBackwards)
        {
            model.transform.Rotate(0f, -1f, 0f);
        }
    }
}
