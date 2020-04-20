using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject instance;
    public float delay;

    private bool startSpawn = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {

        if (startSpawn)
        {
            GameObject inst = (GameObject)Instantiate(instance, transform.position, transform.rotation);
            rb = inst.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-3250, 0));
        }
        


    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(delay);
        startSpawn = true;
    }
}
