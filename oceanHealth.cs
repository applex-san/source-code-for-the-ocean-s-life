using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oceanHealth : MonoBehaviour
{
    private float startHealth = 100f;
    public float health;
    public Image healthBar;

    public AudioSource music;

    public Camera cam;

    public static bool canMOve = true;
    public static bool isDead = false;
    private float zoomSize = 5;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        canMOve = true;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.fillAmount = health/startHealth;
        if(health <= 0)
        {
            canMOve = false;
            isDead = true;
            StartCoroutine(death());
            health = -1;
        }
      
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(5);
        //die
        
        

        if (zoomSize <= 50)
        {
            cam.orthographicSize = zoomSize;
            zoomSize += 0.1f;
        }
        if(zoomSize >= 50)
        {
            if(zoomSize <= 900)
            {
                zoomSize += 10f;
                cam.orthographicSize = zoomSize;
            }
            
        }
    }
}
