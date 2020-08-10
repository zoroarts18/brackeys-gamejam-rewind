using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    
    void Start()
    {
        Invoke("backToMenu", 65);
    }

    void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
 
}
