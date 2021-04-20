using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HumanInterface : BioInterface
{
    public string type;
    
    private BioProperty bioProperty;
    private NavMeshAgent agent;
    public Animator animatorController;
    public GameObject gameManager;

    private Vector3 targetPoint;
    private Vector3 facePoint;
    private bool isDead = false;
    void Awake()
    {
        bioProperty = GetComponent<BioProperty>();
        
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        DebugRayTest();
        Move();
        FaceTarget();
//        Debug.Log(targetPoint.x+":"+targetPoint.y+":"+targetPoint.z);
    }

    public int GetCurrentHealth()
    {
        return bioProperty.CURRENT_HP;
    }

    public void ChangeCurrentHealth(int value)
    {
        SetCurrentHealth(bioProperty.CURRENT_HP+= value); 
    }

    public void SetCurrentHealth(int currentHealth)
    {
        if (currentHealth > bioProperty.MAX_HP)
        {
            bioProperty.CURRENT_HP = bioProperty.MAX_HP;
        }
        else if (currentHealth < 0)
        {
            bioProperty.CURRENT_HP = 0;
            if (!isDead)
            {
                isDead = true;
                Die();
            }
           
        }
    }

    public bool isDid()
    {
        return isDead;
    }

    public int GetMaxHealth()
    {
        return bioProperty.MAX_HP;
    }

    public void SetMaxHealth(int maxHealth)
    {
        bioProperty.MAX_HP = maxHealth;
    }

    public int GetGeneralAttackValue()
    {
        return bioProperty.GetGeneralAttackValue();
    }
    
    public override void ReceiveGeneralDamage(int damage)
    {
        ChangeCurrentHealth(-bioProperty.GetGeneralDamage(damage));
    }

    public override void ReceiveAbilityDamage(int damage)
    {
        ChangeCurrentHealth(-bioProperty.GetAbilityDamage(damage));
    }

    public override void Die()
    {
        GameManager.AddMessage("BrainAddOne");
        animatorController.SetTrigger("Dead");
        StartCoroutine(Des());
    }

    private IEnumerator Des()
    {
        yield return new WaitForSeconds(2); 
        DropItems();
        Destroy(gameObject);
    }

    public void DropItems()
    {
        foreach (GameObject item in gameManager.GetComponent<DropAssets>().DropOutItems(type))
        {
            Instantiate(item, transform.position, item.transform.rotation);
        }
        
    }

    public void Move()
    {
        if (targetPoint!=Vector3.zero)
        {
            SetFaceDirection(targetPoint);
            agent.SetDestination(targetPoint);
        }
        
    }
    
    public void FaceTarget()
    {
        Vector3 dir = (facePoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        //transform.Rotate(lookRotation * Time.deltaTime * 5.0f);
    }

    public void SetMoveTargetPoint(Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
    }

    public void SetFaceDirection(Vector3 facePoint)
    {
        this.facePoint = facePoint;
    }

    public void SetAgentSpeed(float speed)
    {
        agent.speed = speed;
    }
    
    public bool IsArravied()
    {
        //Debug.Log(Vector3.Distance(transform.position,targetPoint));
        return Vector3.Distance(transform.position,targetPoint)<=8.0f;
        
      
    }

    public void StopMove()
    {
        targetPoint = Vector3.zero;
        agent.ResetPath();
        agent.SetDestination(transform.position);
    }

    public bool DetectViewScope(String tag, ref GameObject target,float distence)
    {
        
        RaycastHit hit;
        int[] startAngle = {0, 30, 0, -30};
        int[] endAngle = {30, 60, -30, -60};
        if (target == null)
        {
            //120 ViewAngle Every 30 degree, 2 rays
            // 8 rays to detect player
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    bool isHitted = Physics.Raycast(pos, transform.rotation * Quaternion.Euler(0,Random.Range(startAngle[i],endAngle[i]),0) * Vector3.forward, out hit, distence);
                    //Debug.Log(isHitted);
                    if (isHitted && hit.collider.CompareTag(tag))
                    {
                        target = hit.collider.gameObject;
                        //Debug.Log("Find Player");
                        return true;
                    }
                }
            } 
        }
        else
        {
            if (Vector3.Distance(transform.position,target.transform.position)>distence)
            {
                target = null;
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    

    private void DebugRayTest()
    {
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,60,0) * Vector3.forward * 40f,Color.green);
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,-60,0) * Vector3.forward * 40f,Color.green);
        
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,12,0) * Vector3.forward * 40f,Color.green);
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,36,0) * Vector3.forward * 40f,Color.green);
        
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,-12,0) * Vector3.forward * 40f,Color.green);
        Debug.DrawRay(transform.position, transform.rotation * Quaternion.Euler(0,-36,0) * Vector3.forward * 40f,Color.green);
    }
    
    
}
