using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Scene nextScene;
    public Animator clouds;

    public GameObject PausePanel;
    public bool isPaused = false;

    public GameObject Player;

    public void Start()
    {
        PausePanel.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !isPaused )
        {
            pauseGame();
        }

       
    }
    public void NextLevel()
    {
        

        clouds.SetTrigger("End");
        Invoke("changeToNextLevel", 1.5f);
    }

    public void changeToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void pauseGame()
    {
        isPaused = true;
        Player.GetComponent<HeissLuftBallon>().Unbesiegbar();
        PausePanel.SetActive(true);
    }

    public void resumeGame()
    {
        if(isPaused)
        {
            Player.GetComponent<HeissLuftBallon>().Besiegbar();
            isPaused = false;
            
            PausePanel.SetActive(false);
        }
        
    }

    public void BackToMenu()
    {
        clouds.SetTrigger("End");
        Invoke("changeToMenu", 1.5f);
    }

    public void changeToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
