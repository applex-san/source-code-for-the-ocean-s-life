using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oil : MonoBehaviour
{
    public weatherConditions wCon;
    public spawner spawn;

    private bool canSpawnTime;

    private void Start()
    {
        canSpawnTime = true;
    }
    public void Update()
    {
        spawn.timeBTWSpawnEnd = spawn.timeBTWSpawnEnd - 0.0005f;
        spawn.timeBTWSpawnStart = spawn.timeBTWSpawnStart - 0.0005f;
        if (wCon.startOil)
        {
            //oil
            canSpawnTime = true;
            spawn.timeBTWSpawnStart = 1;
            spawn.timeBTWSpawnEnd = 1;
        }
        else
        {
            if(canSpawnTime == true)
            {
                spawn.timeBTWSpawnStart = spawn.timeBTWSpawnStart + 5;
                spawn.timeBTWSpawnEnd = spawn.timeBTWSpawnEnd + 5;
                canSpawnTime = false;
            }
            
            
        }
        if(wCon.startOil == false)
        {
            if(oceanHealth.isDead == false)
            {
                
            }
            else
            {
                StartCoroutine(spawnyboi());
            }
            
        }
      
    }

    IEnumerator spawnyboi()
    {
        spawn.timeBTWSpawnEnd = 0.2f;
        spawn.timeBTWSpawnStart = 0.2f;
        yield return new WaitForSeconds(4);
        spawn.timeBTWSpawnEnd = 8000;
        spawn.timeBTWSpawnStart = 5000;
    }
}
