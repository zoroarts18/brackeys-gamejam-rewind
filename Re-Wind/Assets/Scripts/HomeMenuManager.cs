using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    public GameObject LevelSelection;

    private void Start()
    {
        LevelSelection.SetActive(false);
    }
    public void openLevelSelection()
    {
        LevelSelection.SetActive(true);
    }
    public void EnterLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EnterLevel2()
    {
        SceneManager.LoadScene("Strand");
    }

    public void EnterLevel3()
    {
        SceneManager.LoadScene("Hafen");
    }

    public void EnterLevel4()
    {
        SceneManager.LoadScene("Gewitter");
    }


    void Update()
    {
        
    }
}
