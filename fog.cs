using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog : MonoBehaviour
{
    private ParticleSystem ps;

    public weatherConditions wCon;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.emissionRate = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (wCon.startFog == true)
        {
            ps.emissionRate = 40;
        }
        if (wCon.startFog == false)
        {
            ps.emissionRate = 0;
        }
    }
}
