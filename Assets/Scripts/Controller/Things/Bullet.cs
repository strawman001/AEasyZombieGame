using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50.0f;
    public int damage = 10;
    public float flyDistence = 100.0f;
    
    private Vector3 orignalPos;
    // Start is called before the first frame update
    void Start()
    {
        orignalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        OutOfRange();
    }

    private void Move()
    {
        Vector3 dir = ( Quaternion.Euler(new Vector3(0,transform.rotation.y,0)) * Vector3.forward).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BioInterface>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Lose Target");
        }
    }

    private void OutOfRange()
    {
        if (Vector3.Distance(orignalPos,transform.position)>flyDistence)
        {
            Destroy(gameObject);
        }
    }
}
