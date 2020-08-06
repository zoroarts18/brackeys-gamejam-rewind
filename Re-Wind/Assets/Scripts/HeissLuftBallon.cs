using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeissLuftBallon : MonoBehaviour
{
    public GameObject DeathVFX;
    public Transform KorbPunkt;
    public GameObject Korb;
    public GameObject NotePanel;
    public GameObject WonPanel;

    private Vector3 startPos;
    void Start()
    {
        WonPanel.SetActive(false);
        startPos = transform.position;

        NotePanel.SetActive(true);
        Invoke("DeactivateNote", 6);
    }

    public void DeactivateNote()
    {
        NotePanel.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Dead();
        }
    }

    public void Dead()
    {
        Instantiate(DeathVFX, transform.position, Quaternion.identity);
        Instantiate(Korb, KorbPunkt.position, Quaternion.identity);

        Invoke("RestartScene", 2);

        this.gameObject.SetActive(false);
    }


    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);


    }
    
}
