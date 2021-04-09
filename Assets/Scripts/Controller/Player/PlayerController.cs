using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    private PlayerController(){}
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new PlayerController();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    private PlayerInterface playerInterface;
    private CharacterController controller;
    private SphereCollider bound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    
    private float joyStickHorizontalValue = 0f;
    private float joyStickVectorialValue = 0f;
    private float cameraDirectionY = 0f;

    private bool isBasicAttacking = false;
    private bool isSpecialAttacking = false;
    private bool isAttackingCoolDown = false;
    
    public float speed = 3.0f;
    private void Start()
    {
        playerInterface = GetComponent<PlayerInterface>();
        controller = GetComponent<CharacterController>();
        bound = GetComponent<SphereCollider>();
        audioSource1 = transform.GetComponents<AudioSource>()[0];
        audioSource2 = transform.GetComponents<AudioSource>()[1];
        controller.detectCollisions = false;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        
        //Get inputs from the player
        float horizontal = joyStickHorizontalValue * speed + Input.GetAxis("Horizontal") * speed;
        float vertical = joyStickVectorialValue * speed + Input.GetAxis("Vertical") * speed;
        
        //Get player Direction
        Vector3 dir = (Quaternion.Euler(0,cameraDirectionY,0) * new Vector3(horizontal, 0f, vertical)).normalized ;

        //If player isn't moving then the direction won't change
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            controller.Move(dir * speed * Time.deltaTime);
            playerInterface.GetAnimator().SetBool("Run",true);
        }
        else
        {
            playerInterface.GetAnimator().SetBool("Run",false);
        }
            
        
        //Move the player
        
        
        // Play animation
        /*
        if (movement != Vector3.zero)
        {
           // animator.ZombieRun();
        }

        if (movement == Vector3.zero)
            //&& animatorComp.GetCurrentAnimatorStateInfo(0).IsName("Zombie Run"))
        {
            //animator.ZombieIdle();
            //print("IDLE");
        }*/
    }

    public void BasicAttack()
    {
        if (!isBasicAttacking && !isAttackingCoolDown)
        {
            Debug.Log("Basic Attack");
            isAttackingCoolDown = true;
            isBasicAttacking = true;
            playerInterface.GetAnimator().SetTrigger("Attack");
            audioSource1.Play();
            MakeDamage(playerInterface.GetPhysicAttackValue());
            isBasicAttacking = false;
            StartCoroutine(AttackingCoolDown());
        }
        
    }

    public void SpecialAttack()
    {
        if (!isSpecialAttacking && !isAttackingCoolDown)
        {
            Debug.Log("Special Attack");
            isAttackingCoolDown = true;
            isSpecialAttacking = true;
            playerInterface.GetAnimator().SetTrigger("Attack");
            audioSource2.Play();
            MakeDamage(playerInterface.GetPhysicAttackValue());
            isSpecialAttacking = false;
            StartCoroutine(AttackingCoolDown());
        }
        
    }

    private void MakeDamage(int damage)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, bound.radius);
        if (hitColliders.Length > 0)
        {
            //Debug.Log("Hitting enemy");
            foreach (Collider hit in hitColliders)
            {
                if (hit.CompareTag("Enemy"))
                {
                    BioInterface targetInterface = hit.gameObject.GetComponent<BioInterface>();
                    targetInterface.ReceiveDamage(damage);
                }
                
            }
        }
    }

    public void SetJoyStick(float horizontalValue,float vectorialValue)
    {
        joyStickHorizontalValue = horizontalValue;
        joyStickVectorialValue = vectorialValue;
    }

    public void SetViewDirection(float directionY)
    {
        cameraDirectionY = directionY;
    }
    
    private IEnumerator AttackingCoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        isAttackingCoolDown = false;
    }
}
