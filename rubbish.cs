using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rubbish : MonoBehaviour
{
    public float rubbishCleanUpTime;
    private float startRubbishCleanUpTime;
    public float rubbishDamage;

    public GameObject healthObj;
    private oceanHealth health;

    private GameObject gm;
    private weatherConditions wCon;

    public AudioSource teey;

    private bool canDie = false;

    public GameObject deathEff;
    // Start is called before the first frame update
    void Start()
    {
        healthObj = GameObject.FindGameObjectWithTag("healthBar");
        gm = GameObject.FindGameObjectWithTag("GameController");
        wCon = gm.GetComponent<weatherConditions>();
        health = healthObj.GetComponent<oceanHealth>();
        startRubbishCleanUpTime = rubbishCleanUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        health.health -= rubbishDamage;
        if(wCon.startWaves == true)
        {
            rubbishCleanUpTime = rubbishCleanUpTime * 1.5f;
        }
        else if(wCon.startWaves == false)
        {
            rubbishCleanUpTime = startRubbishCleanUpTime;    
        }
        if (oceanHealth.isDead)
        {
            Destroy(gameObject, 10f);
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("yo");
        canDie = true;
        //rubbish actions
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("YEEEET");
            StartCoroutine(yeet());
            
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        canDie = false;
    }
    IEnumerator yeet()
    {
        yield return new WaitForSeconds(rubbishCleanUpTime);
        if (Input.GetKey(KeyCode.Space))
        {
            if (canDie)
            {
                GameObject eff = (GameObject)Instantiate(deathEff, transform.position, transform.rotation);
                teey.Play();
                Destroy(gameObject);
                
                Destroy(eff, 5);
            }
            
        }
    }

  


}
