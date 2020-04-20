using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class weatherConditions : MonoBehaviour
{
    public bool startRain = false;
    public bool startFog = false;
    public bool startOil = false;
    public bool startWaves = false;
    public TMP_Text text;

    public AudioSource rain;
    public AudioSource music;
    public AudioSource fog;

    public bool canPlay = true;

    private string oil = "OIL SPILL!";
    private string fogTExt = "FOG!";
    private string rainTExt = "RAIN!";
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Rain", Random.Range(Random.Range(10, 30), Random.Range(50, 80)));
        Invoke("Fog", Random.Range(Random.Range(5, 20), Random.Range(30, 90)));
        Invoke("Oil", Random.Range(Random.Range(12, 23), Random.Range(43, 94)));
        Invoke("Waves", Random.Range(Random.Range(7, 27), Random.Range(63, 70)));
    }

    // Update is called once per frame
    void Update()
    {
        if(oceanHealth.canMOve == false)
        {
            startRain = false;
            startFog = false;
            startOil = false;
            startWaves = false;
        }
        if(!startFog && !startRain)
        {
            text.enabled = false;
            
            if (canPlay)
            {
                music.Play();
                canPlay = false;
            }
            
        }
        else
        {
            music.Stop();
            canPlay = true;
            StartCoroutine(waitTHENdisable());
        }
    }
    IEnumerator waitTHENdisable()
    {
        text.enabled = true;
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
    void Rain()
    {
        StartCoroutine(StartRain());
        rain.Play();
    }
    void Fog()
    {
        StartCoroutine(StartFog());
        fog.Play();
    }

    void Oil()
    {
        StartCoroutine(StartOil());
    }

    /*void Waves()
    {
        StartCoroutine(StartWaves());
    }*/

    IEnumerator StartWaves()
    {
        Debug.Log("StartWaves");
        
        startWaves = true;
        
        yield return new WaitForSeconds(Random.Range(Random.Range(7, 17), Random.Range(15, 30)));
        startWaves = false;
        Invoke("Waves", Random.Range(Random.Range(7, 27), Random.Range(63, 70)));
    }
    IEnumerator StartOil()
    {
        startOil = true;
        text.text = oil;
        yield return new WaitForSeconds(Random.Range(Random.Range(3, 31), Random.Range(32, 35)));
        startOil = false;
        Invoke("Oil", Random.Range(Random.Range(23, 55), Random.Range(50, 73)));
    }

    IEnumerator StartRain()
    {
        Debug.Log("startRain");
        startRain = true;
        text.text = rainTExt;
        yield return new WaitForSeconds(Random.Range(Random.Range(5, 12), Random.Range(12, 20)));
        startRain = false;
        rain.Stop();
        Invoke("Rain", Random.Range(Random.Range(30, 50), Random.Range(60, 100)));
    }

    IEnumerator StartFog()
    {
        Debug.Log("startFog");
        startFog = true;
        text.text = fogTExt;
        yield return new WaitForSeconds(Random.Range(Random.Range(5, 12), Random.Range(12, 20)));
        startFog = false;
        fog.Stop();
        Invoke("Fog", Random.Range(Random.Range(20, 30), Random.Range(40, 80)));
    }
}
