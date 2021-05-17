using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*This file is for Events in Animations. 
 * Mostly to add the effect on animation*/



public class SpawnningEffect : MonoBehaviour
{
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private TrailRenderer trailPrefab;
    [SerializeField] private GameObject BleedPrefab;
     // Start is called before the first frame update
    void Start()
    {
        trailPrefab.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //HIT EFFECT
    void Spawn_NormalAttackEffect()
    {
        if (this.GetComponent<PlayerController>().MissingHit == false)
        {
            Instantiate(hitPrefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
            Debug.Log("Hit Particle");
            this.GetComponent<PlayerController>().MissingHit = true;
        } 
    }

    //TRAIL EFFECT START
    void Spawn_TrailAttackEffect()
    {
        trailPrefab.enabled = true;
        //trailPrefab.emitting = true;
        Debug.Log("Trail Particle");
        
    }

    //TRAIL EFFECT END
    void Stop_TrailAttackEffect()
    {
        trailPrefab.enabled = false;
        //trailPrefab.emitting = false;
        Debug.Log("Trail Stop");
    }

    //BLEEDING EFFECT ON FATAL BITE
    void BleedingBite()
    {
        Instantiate(BleedPrefab, transform.position , transform.rotation);
        Debug.Log("Bleed Particle");
    }
}
