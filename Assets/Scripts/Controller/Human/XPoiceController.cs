using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XPoiceController : MonoBehaviour
{
    public Vector3[] patrolPoints;
    public Bullet bullet;
    public float attackDistence = 30f;
    public float viewDistence = 40f;
    
    private AudioClip audioClip;
    private AudioSource audioSource;
    private HumanInterface humanInterface;
    
    private bool isRunning = false;
    private bool isSearching = false;
    private bool isPatroling = true;
    private bool isChasing = false;
    private bool isAttacking = false;
    
    private int patrolPointIndex = 0;
    private GameObject target; 
    private bool isAttackingCoolDown = false;
    private bool isSearchFinished = false;
    private Vector3 lastPos;
    private bool isBeginSearching = false;
    
    // Start is called before the first frame update
    void Start()
    {
        humanInterface = GetComponent<HumanInterface>();
        target = GameObject.Find("Player");
        //获取当前GameObject的AudioSource组件的AduioPlayer
        audioClip = gameObject.GetComponent<AudioSource>().clip;
        //获取当前GameObject的AudioSource组件
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         Tick();
    }

    public void PatrolAction()
    {
        humanInterface.animatorController.SetFloat("Speed", 15f);
        humanInterface.SetMoveTargetPoint(patrolPoints[patrolPointIndex]);
        if (humanInterface.IsArravied())
        {
            patrolPointIndex++;
            patrolPointIndex %= patrolPoints.Length;
        }
    }

    public void StopPatrolAction()
    {
        humanInterface.StopMove();
    }

    public void AttackAction()
    {
        if (!isAttackingCoolDown && !ReferenceEquals(target,null))
        {
            //humanInterface.StopMove();
            audioSource.PlayOneShot(audioClip, 0.4f);
            lastPos = target.transform.position;
            isAttackingCoolDown = true;
            GameObject tempTarget = target;
            humanInterface.SetFaceDirection(target.transform.position);
            Vector3 nowPos = transform.position;
            Vector3 direction = (tempTarget.transform.position - nowPos).normalized;
            humanInterface.animatorController.SetTrigger("Fire");
            Bullet newBullet = Instantiate(bullet, new Vector3(nowPos.x,nowPos.y + 5,nowPos.z),Quaternion.LookRotation(direction));
            int damage = humanInterface.GetGeneralAttackValue();
            Debug.Log("Police Damage:"+damage);
            newBullet.GetComponent<Bullet>().damage = damage;
            StartCoroutine(AttackingCoolDown());
        }
    }

    public void StopAttackAction()
    {
        
    }

    public void ChaseAction()
    {
        if (!ReferenceEquals(target,null))
        {
            humanInterface.animatorController.SetFloat("Speed", 30f);
            lastPos = target.transform.position;
            humanInterface.SetMoveTargetPoint(lastPos);
        }
    }
    
    public void StopChaseAction()
    {
        humanInterface.StopMove();
    }

    public void SearchAction()
    {
        humanInterface.SetMoveTargetPoint(lastPos);
        if (humanInterface.IsArravied())
        {
            if (!isBeginSearching)
            {
                isBeginSearching = true;
                humanInterface.animatorController.SetFloat("Speed", 0f);
                StartCoroutine(Searching());
            }
        }
        
    }
    
    public void StopSearchAction()
    {
        isSearchFinished = false;
        //humanInterface.StopMove();
    }

    public bool IsInAttackScope()
    {
        if (!ReferenceEquals(target,null))
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackDistence;
        }
        else
        {
            return false;
        }
        
    }

    public bool IsInViewScope()
    {
        return humanInterface.DetectViewScope("Player", ref target,viewDistence);
    }
    
    private bool IsSearchFinished()
    {
        bool temp = isSearchFinished;
        if (temp)
        {
            isBeginSearching = false;
        }
        return temp;
    }

    //State machine!
    private void Tick()
    {
        if (!isRunning)
        {
            isRunning = true;
            if (isPatroling)
            {
                PatrolAction();
            }
            else if (isChasing)
            {
                ChaseAction();   
            }
            else if (isAttacking)
            {
                AttackAction();
            }
            else if (isSearching)
            {
                SearchAction();
            }
            ConditionListener();
            isRunning = false;
        }
    }

    private void ConditionListener()
    {
        bool viewFlag = IsInViewScope();
        bool attackFlag = false;
        if (viewFlag)
        {
            attackFlag = IsInAttackScope();
        }
        
        if (isPatroling)
        {
            if (viewFlag && attackFlag)
            {
                StopPatrolAction();
                isAttacking = true;
                isPatroling = false;
            }
            else if (viewFlag)
            {
                StopPatrolAction();
                isChasing = true;
                isPatroling = false;
            } 
            
        }
        else if (isChasing)
        {
            if (!viewFlag)
            {
                StopChaseAction();
                isSearching = true;
                isChasing = false;
            }
            else if (attackFlag)
            {
                StopChaseAction();
                isAttacking = true;
                isChasing = false;
            }
        }
        else if (isAttacking)
        {
            if (!attackFlag && viewFlag)
            {
                StopAttackAction();
                isChasing = true;
                isAttacking = false;
            }
            else if (!viewFlag)
            {
                StopAttackAction();
                isSearching = true;
                isAttacking = false;
            }
        }
        else if (isSearching)
        {
            if (attackFlag)
            {
                StopSearchAction();
                isAttacking = true;
                isSearching = false;
            }
            else if (viewFlag)
            {
                StopSearchAction();
                isChasing = true;
                isSearching = false;
            }
            else if (IsSearchFinished())
            {
                StopSearchAction();
                isPatroling = true;
                isSearching = false;
            }
           
        }
    }
    
    /*
    private void Tick()
    {
        if (!isRunning)
        {
            isRunning = true;
            
            if (isInViewScope())
            {
                if (isInAttackScope())
                {
                     AttackAction();
                }
                else
                {
                     ChaseAction();
                }
            }
            else if (ReferenceEquals(target,null))
            {
                PatrolAction();
            }
            else if (isSearching)
            {
                 SearchAction();
            }
            isRunning = false;
        }
    }*/

    private IEnumerator AttackingCoolDown()
    {
        yield return new WaitForSeconds(1);
        isAttackingCoolDown = false;
    }
    
    private IEnumerator Searching()
    {
        yield return new WaitForSeconds(3);
        isSearchFinished = true;
    }
/*
    private IEnumerator Searching()
    {
        
        Vector3[] searchPoints = new[] {GetRandomSearchPoint(), GetRandomSearchPoint(), GetRandomSearchPoint()};
        foreach (Vector3 point in searchPoints)
        {
           // humanInterface.Move(point);
            yield return new WaitUntil(()=>true);
        }
    }

    private Vector3 GetRandomSearchPoint()
    {
        return new Vector3(transform.position.x + Random.Range(-10f,10f),transform.position.y,transform.position.z + Random.Range(-10f,10f));
    }
*/
  

   
    
}
