using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform target;
    private Vector3 offsetStation;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target.position);
        offsetStation = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetStation + target.position;

    }
}