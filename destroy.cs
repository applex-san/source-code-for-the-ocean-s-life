using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oceanHealth.isDead == true)
        {
            //StartCoroutine(death());
        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(11);
        gameObject.SetActive(false);
    }
}
