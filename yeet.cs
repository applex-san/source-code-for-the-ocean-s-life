using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class yeet : MonoBehaviour
{
    public Animator anim;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oceanHealth.isDead)
        {
            music.pitch = Random.Range(-0.5f, 1);
            StartCoroutine(startAnim());
        }
    }

    IEnumerator startAnim()
    {
        yield return new WaitForSeconds(14);
        music.Stop();
        anim.SetBool("start", true);
    }
}
