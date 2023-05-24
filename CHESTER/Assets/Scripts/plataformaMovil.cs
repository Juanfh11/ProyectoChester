using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public Transform[] pose;

    public float speed;

    public int ID;

    public int suma;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pose[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pose[ID].position)
        {
            ID += suma;
        }

        if (ID == pose.Length - 1)
        {
            suma = -1;
        }

        if (ID == 0)
        {
            suma = 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, pose[ID].position, speed * Time.deltaTime);
    }
}
