using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returnButton : MonoBehaviour
{
    public void returnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
