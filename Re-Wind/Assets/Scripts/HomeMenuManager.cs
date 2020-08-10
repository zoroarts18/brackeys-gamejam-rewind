using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class HomeMenuManager : MonoBehaviour
{
    public GameObject LevelSelection;
    public GameObject Controls;

    public Animator clouds;
    public UnityEngine.UI.Button Level1;
    public UnityEngine.UI.Button Level2;
    public UnityEngine.UI.Button Level3;
    public UnityEngine.UI.Button Level4;

    
    private void Start()
    {
        Controls.SetActive(false);

        if (PlayerPrefs.GetInt("Level1Done") == 1)
            Level2.interactable = true;
        else
            Level2.interactable = false;

        if (PlayerPrefs.GetInt("Level2Done") == 1)
            Level3.interactable = true;
        else
            Level3.interactable = false;

        if (PlayerPrefs.GetInt("Level3Done") == 1)
            Level4.interactable = true;
        else
            Level4.interactable = false;


        

        LevelSelection.SetActive(false);
    }

    public void openControls()
    {
        Controls.SetActive(true);
    }

    

    public void closeControls()
    {
        Controls.SetActive(false);
    }

    public void openCredits()
    {
        clouds.SetTrigger("End");
        Invoke("goToCredits", 1.5f);

    }
    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void openLevelSelection()
    {
        LevelSelection.SetActive(true);
    }

    public void closeLevelSelection()
    {
        LevelSelection.SetActive(false);
    }

    public void EnterLevel1()
    {
        clouds.SetTrigger("End");
        Invoke("changeToLevel1",1.5f);
    }

    public void EnterLevel2()
    {
        clouds.SetTrigger("End");
        Invoke("changeToLevel2",1.5f);
    }

    public void EnterLevel3()
    {
        clouds.SetTrigger("End");
        Invoke("changeToLevel3", 1.5f);
    }

    public void EnterLevel4()
    {
        clouds.SetTrigger("End");
        Invoke("changeToLevel4", 1.5f);
    }



    public void changeToLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void changeToLevel2()
    {
        SceneManager.LoadScene("Strand");
    }
    public void changeToLevel3()
    {
        SceneManager.LoadScene("Hafen");
    }
    public void changeToLevel4()
    {
        SceneManager.LoadScene("Gewitter");
    }


    void Update()
    {
        
    }
}
