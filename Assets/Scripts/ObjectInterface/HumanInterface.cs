using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HumanInterface : BioInterface
{
    public string type;
    
    private BioProperty bioProperty;
    private NavMeshAgent agent;
    public Animator animatorController;
    //public GameObject gameManager;
    private DropItemsInterface dropItemsInterface;
    
    private Vector3 targetPoint;
    private Vector3 facePoint;
    private bool isDead = false;

    private bool isCreatedLifebar = false;
    private Slider slider; 
        
    void Awake()
    {
        bioProperty = GetComponent<BioProperty>();
        dropItemsInterface = GetComponent<DropItemsInterface>();
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
        SetCurrentHealth(bioProperty.CURRENT_HP+value); 
    }

    public void SetCurrentHealth(int currentHealth)
    {
        if (!isCreatedLifebar)
        {
            CreateLifeSlider();
        }
        
        
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
            }
        }
        else
        {
            bioProperty.CURRENT_HP = currentHealth;
        }
        
        slider.value = bioProperty.CURRENT_HP;

        if (isDead)
        {
            Die();
        }

    }

    public bool isDie()
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
        //GameManager.AddMessage("BrainAddOne");
        animatorController.SetTrigger("Dead");
        taskObserver.NotifyAllListener(ObjectEventType.EVENT_DIE);
        StartCoroutine(DestoryMethod());
    }

    private IEnumerator DestoryMethod()
    {
        yield return new WaitForSeconds(2); 
        dropItemsInterface.DropItems(transform.position);
        Destroy(gameObject);
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

    private Slider CreateLifeSlider()
    {
        isCreatedLifebar = true;
        GameObject lifeBar = Resources.Load("Prefab/UI/CreatureLifeBar") as GameObject;
        GameObject ins = Instantiate(lifeBar, transform.position, lifeBar.transform.rotation);
        ins.transform.parent = transform;
        ins.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,6.5f,0);
        slider = ins.GetComponent<CreatureLifebarController>().slider;
        slider.maxValue = bioProperty.MAX_HP;
        //slider.value = bioProperty.CURRENT_HP;
        return slider;
    }
    
}
