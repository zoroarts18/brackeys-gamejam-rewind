using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzGenerator : MonoBehaviour
{
   

    public GameObject Player;
    public GameObject BlitzObj;
    public Vector2 PlayerPos;
    public Animator BlitzAnim;

    public float TimeBetweenBlitz = 0;

    public bool BlitzImGang;

    public GameObject BlitzPanel;
    void Start()
    {
        BlitzPanel.SetActive(false);
       
    }

    private void Update()
    {
        //Ab 160 hört Gewitter auf
        
            if (BlitzImGang == false && TimeBetweenBlitz > 6 && Player.transform.position.x <= 160)
            {
                StartCoroutine(Blitz());
                BlitzImGang = true;

                TimeBetweenBlitz = 0;
            }

            if (TimeBetweenBlitz < 6)
            {
                TimeBetweenBlitz += Time.deltaTime;
            }
        
        


    }
    public void GetPlayerPos()
    {
        PlayerPos = Player.transform.position;

    }


    public IEnumerator Blitz()
    {
        GetPlayerPos();
        GameObject currentBlitz = Instantiate(BlitzObj, 
            new Vector2(PlayerPos.x = Mathf.Clamp(PlayerPos.x, PlayerPos.x, PlayerPos.x -= 1.5f) , 7.21f), 
            Quaternion.identity);

        yield return new WaitForSeconds(1.3f);
        BlitzAnim = currentBlitz.GetComponent<Animator>();
        BlitzAnim.SetTrigger("Blitz");
        BlitzPanel.SetActive(true);
        //Invoke("DeactivateBlitzPanel", 0.5f);
        Destroy(currentBlitz, 0.3f);

        yield return new WaitForSeconds(0.5f);

        BlitzPanel.SetActive(false);
        BlitzImGang = false;
    }

    
}
