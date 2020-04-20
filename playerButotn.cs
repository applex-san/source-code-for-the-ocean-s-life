using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerButotn : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(yeet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator yeet()
    {
        yield return new WaitForSeconds(10);
        anim.SetBool("enter", true);
    }

    public void LoadLevel()
    {
        Debug.Log("YEEEET");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
