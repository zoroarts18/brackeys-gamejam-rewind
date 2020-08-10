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
    public GameObject Föhn;
    public GameObject Kabel;
    public AudioSource WinSound;

    public ParticleSystem FöhnPart;

    public AreaEffector2D FöhnWind;

    public GameObject Rope1;
    public GameObject Rope2;

    public AudioSource BackGroundMusic;
    public AudioSource BackGroundSFX;
    public AudioSource FöhnSound;

    public int Level;

    public GameObject RainBow;

    public bool moved = false;

    private Vector3 startPos;
    public float distanceToGo;

    public AudioSource DeathSFX;

    public Color DefaultColor;
    public Color UnbesiegbarColor = new Color(255, 255, 255, 40);
    void Start()
    {
        FöhnWind = Föhn.GetComponent<AreaEffector2D>();
        
        DefaultColor = GetComponent<SpriteRenderer>().color;
        startPos = transform.position;

        RainBow.SetActive(false);
        WonPanel.SetActive(false);
        startPos = transform.position;

        NotePanel.SetActive(true);
        Invoke("DeactivateNote", 6);
    }

    public void Unbesiegbar()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = UnbesiegbarColor;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Rope1.SetActive(false);
        Rope2.SetActive(false);
        Föhn.GetComponent<Foehn>().enabled = false;
        FöhnWind.enabled = false;
        FöhnSound.Stop();
        FöhnPart.enableEmission = false;
    }

    public void Besiegbar()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = DefaultColor;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Rope1.SetActive(true);
        Rope2.SetActive(true);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Föhn.GetComponent<Foehn>().enabled = true;
        

    }

    public void EndLevel()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Kabel.SetActive(false);
        Föhn.SetActive(false);
        BackGroundMusic.Stop();

        if(Level == 3 )
        {
            BackGroundSFX.Stop();
        }

        if(Level == 2)
        {
            BackGroundSFX.Stop();
        }
        

        //WinSound.Play();
        
        switch(Level)
        {
            case 1:
                PlayerPrefs.SetInt("Level1Done", 1);
                return;

            case 2:
                PlayerPrefs.SetInt("Level2Done", 1);
                return;

            case 3:
                PlayerPrefs.SetInt("Level3Done", 1);
                return;

        }
    }

    void Update()
    {
        if(Level == 3)
        {
            if (transform.position.y <= -7.5f)
                Dead();
        }
        
        if(transform.position.x >= distanceToGo )
        {
            moved = true;
        }

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

        if(collision.gameObject.tag == "Goal")
        {
            StartCoroutine(ReachedGoal());
        }
    }

    

    IEnumerator ReachedGoal()
    {
        RainBow.SetActive(true);
        GetComponent<Rigidbody2D>().isKinematic = true;
        EndLevel();

        yield return new WaitForSeconds(3);

        WonPanel.SetActive(true);

    }

    public void Dead()
    {
        DeathSFX.Play();
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
