using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wait : MonoBehaviour {
    public Animator anim;

    private void Start()
    {
        StartCoroutine(play());
    }

    private void Update()
    {
        
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(20);
        anim.SetBool("enter", true);
    }


}
