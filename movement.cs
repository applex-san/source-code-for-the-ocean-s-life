using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class movement : MonoBehaviour
{

    public float speed = 4;
    private float startSpeed;
    public float rotationSpeed = 100f;

    public weatherConditions wCon;

    private Vector3 targetPos;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (oceanHealth.canMOve == true)
        {
            if (Input.GetMouseButton(0))
            {
                SetTargetPos();
                if (isMoving)
                {
                    Move();
                }
                
            }
            if (wCon.startRain)
            {
                speed = 2;

            }
            if (!wCon.startRain)
            {
                speed = startSpeed;
            }
        }
        
        
    }
    void SetTargetPos()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;

        isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position == targetPos)
        {
            isMoving = false;
        }
    }
}
