using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPoliceController : MonoBehaviour
{
    public Vector3[] patrolPoints;
    public Bullet bullet;
    public float attackDistence = 30f;
    public float viewDistence = 40f;
    
    private AudioClip audioClip;
    private AudioSource audioSource;
    private HumanInterface humanInterface;
    
    private int patrolPointIndex = 0;
    private GameObject target; 
    private bool isAttackingCoolDown = false;
    private bool isSearching = false;
    private bool isBeginSearching = false;
    private bool isCallDead = false;
    private Vector3 lastPos;
    private bool viewFlag = false;
    
    private BehaviorTree behaviorTree;

    // Start is called before the first frame update
    void Start()
    {
        humanInterface = GetComponent<HumanInterface>();
        target = GameObject.Find("Player");
        //获取当前GameObject的AudioSource组件的AduioPlayer
        audioClip = gameObject.GetComponent<AudioSource>().clip;
        //获取当前GameObject的AudioSource组件
        audioSource = this.gameObject.GetComponent<AudioSource>();

        initBehaviorTree();
    }

    // Update is called once per frame
    void Update()
    {
        behaviorTree.Tick();
    }

    private void initBehaviorTree()
    {
        SelectorNode root = new SelectorNode();
        behaviorTree = new BehaviorTree(root);
        
        SequenceNode deadSequenceNode = new SequenceNode();
        deadSequenceNode.AddNode(BehaviorTree.MakeNoParamConditionNode(IsDie))
            .AddNode(BehaviorTree.MakeNoParamActionNode(behaviorTree,"Dead",DieAction));
        
        SequenceNode lookSequenceNode = new SequenceNode();
        SelectorNode attackOrChaseSelectorNode = new SelectorNode();
        lookSequenceNode.AddNode(BehaviorTree.MakeNoParamConditionNode(IsInViewScope)).AddNode(attackOrChaseSelectorNode);
        SequenceNode attackSequenceNode = new SequenceNode();
        attackOrChaseSelectorNode.AddNode(attackSequenceNode
            .AddNode(BehaviorTree.MakeNoParamConditionNode(IsInAttackScope))
            .AddNode(BehaviorTree.MakeNoParamActionNode(behaviorTree, "Shoot", AttackAction)))
                                .AddNode(BehaviorTree.MakeNoParamActionNode(behaviorTree,"Chase",ChaseAction).SetLeaveMethod(StopChaseAction));
        
        SequenceNode searchSequenceNode = new SequenceNode();
        searchSequenceNode.AddNode(BehaviorTree.MakeNoParamConditionNode(IsGoToSearch))
            .AddNode(BehaviorTree.MakeNoParamActionNode(behaviorTree, "Search", SearchAction).SetLeaveMethod(StopSearchAction));

        root.AddNode(deadSequenceNode)
            .AddNode(lookSequenceNode)
            .AddNode(searchSequenceNode)
            .AddNode(BehaviorTree.MakeNoParamActionNode(behaviorTree, "Patrol", PatrolAction).SetLeaveMethod(StopPatrolAction));
        
    }
    
    
    private void PatrolAction()
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
        StopCoroutine(Searching());
        isBeginSearching = false;
        isSearching = false;
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
        bool inView = humanInterface.DetectViewScope("Player", ref target,viewDistence);
        if (inView)
        {
            viewFlag = inView;
            isSearching = false;
        }

        if (viewFlag&&!inView)
        {
            isSearching = true;
        }
        
        return inView;
    }
    
    private bool IsGoToSearch()
    {
        return isSearching;
    }
    
    private IEnumerator AttackingCoolDown()
    {
        yield return new WaitForSeconds(1);
        isAttackingCoolDown = false;
    }
    
    private IEnumerator Searching()
    {
        yield return new WaitForSeconds(3);
        viewFlag = false;
        isSearching = false;
        isBeginSearching = false;
    }

    private bool IsDie()
    {
        return humanInterface.isDie();
    }

    private void DieAction()
    {
        if (!isCallDead)
        {
            isCallDead = true;
            //humanInterface.Die();
        }
        
    }
}
