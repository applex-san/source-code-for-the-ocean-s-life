using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public Vector3 center;
    public Vector3 size;

    public AudioSource aSource;

    public float timeBTWSpawnStart;
    public float timeBTWSpawnEnd;

    private int rand;

    public int counter;
    private bool yeet;

    public int numberOfending;

    public GameObject enemySPawn;

   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("haha", Random.Range(timeBTWSpawnStart, timeBTWSpawnEnd));
        yeet = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(oceanHealth.isDead == true)
        {
            yeet = true;
        }
        if (yeet == true)
        {
            if (counter <= numberOfending)
            {
                Invoke("haha", 0.1f);
                counter = counter + 1;
            }

        }

    }
 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    void haha()
    {
        StartCoroutine(spawnObjects());
    }

    IEnumerator spawnObjects()
    {
        rand = Random.Range(0, spawnObject.Length);
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject effect = (GameObject)Instantiate(enemySPawn, pos, Quaternion.identity);
        aSource.Play();
        if(oceanHealth.isDead == false)
        {
            yield return new WaitForSeconds(1);
        }
       
        Destroy(effect);
        
        Instantiate(spawnObject[rand], pos, Quaternion.Euler(0, 0, 0));
        if(yeet == false)
        {
            Invoke("haha", Random.Range(timeBTWSpawnStart, timeBTWSpawnEnd));
        }
        
        
    }
}
