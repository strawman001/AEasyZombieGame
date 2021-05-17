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
        playerSkillHolder = new PlayerSkillHolder();
    }


    private PlayerInterface playerInterface;
    private CharacterController controller;
    private SphereCollider bound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private PlayerSkillHolder playerSkillHolder;

    private float joyStickHorizontalValue = 0f;
    private float joyStickVectorialValue = 0f;
    private float cameraDirectionY = 0f;

    private bool isBasicAttacking = false;
    private bool isSpecialAttacking = false;
    private bool isAttackingCoolDown = false;
    private bool isBiteavailable = true;
    private bool isDashavailable = true;
    private bool dealtDamage = false;

    public bool MissingHit = true;
    public float speed = 3.0f;

    private Vector3 _dir;


    public Vector3 dir   // property
    {
        get { return _dir; }   // get method
        set { _dir = value; }  // set method
    }

    public float dashSpeed = 200f;
    public float dashTime = 0.25f;

    ///PARTICLES
    [SerializeField] private ParticleSystem Dashparticle;
    [SerializeField] private ParticleSystem Bleedparticle;

    private void Start()
    {
        playerInterface = GetComponent<PlayerInterface>();
        controller = GetComponent<CharacterController>();
        bound = GetComponent<SphereCollider>();
        audioSource1 = transform.GetComponents<AudioSource>()[0];
        audioSource2 = transform.GetComponents<AudioSource>()[1];
        controller.detectCollisions = false;
       // cameraDirectionY = Camera.main.transform.eulerAngles.y;
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
        dir = (Quaternion.Euler(0,cameraDirectionY,0) * new Vector3(horizontal, 0f, vertical)).normalized ;

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

        //Dash
        if (Input.GetKeyDown(KeyCode.E) && isDashavailable)
        {
            playDashParticle();
            StartCoroutine(Dash());
            playerInterface.GetAnimator().SetBool("Run", true);
            Debug.Log("DASH");
        }

        //Fatal Bite
        if (Input.GetKeyDown(KeyCode.Q) && isBiteavailable)
        {
            FatalBite();
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
            //playerInterface.GetAnimator().SetTrigger("Attack");
            audioSource1.Play();
            MakeDamage(playerInterface.GetGeneralAttackValue());
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
            //playerInterface.GetAnimator().SetTrigger("Attack");
            audioSource2.Play();
            MakeDamage(playerInterface.GetGeneralAttackValue());
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
                    MissingHit = false;
                    playerInterface.GetAnimator().SetTrigger("Attack");
                    BioInterface targetInterface = hit.gameObject.GetComponent<BioInterface>();
                    targetInterface.ReceiveGeneralDamage(damage);
                }
                else
                {
                    playerInterface.GetAnimator().SetTrigger("Attack");
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

    public void LifeSteal(int damage)
    {
        //This will be implemented correctly when a skill tree
        bool unlocked = playerSkillHolder.CheckForUnlock(PlayerSkillHolder.Skill.LifeSteal);

        unlocked = true;

        if (unlocked == false)
        {
            Debug.Log("not unlocked");
        }
        else
        {
            Debug.Log("unlocked lifesteal");
        }
        int percentage = 0;
        int rand = UnityEngine.Random.Range(1, 10);


        if (unlocked == true)
        {
            if (dealtDamage == true)
            {
                Debug.Log("LifeSteal");

                //10% Life Steal
                percentage = (playerInterface.GetGeneralAttackValue() / 10);

                //50% chance to enable double health
                if (rand <= 5 && unlocked == true)
                {
                    //Adding Health 2 times the amount normal (through skill upgrade)
                    playerInterface.ChangeCurrentHealth(percentage * 2);
                    Debug.Log("Double Health Gained: " + percentage * 2);
                }
                else
                {
                    //Adding Health
                    playerInterface.ChangeCurrentHealth(percentage);
                    Debug.Log("health Gained: " + percentage);
                }

                Debug.Log("Total Health: " + playerInterface.GetCurrentHealth());

                dealtDamage = false;

            }
        }
    }

    //SKILLS ACTIVATE
    private IEnumerator Dash()
    {
        float StartTime = Time.time;
        while (Time.time < StartTime + dashTime)
        {

            controller.Move(dir * dashSpeed * Time.deltaTime);

            isDashavailable = false;
            StartCoroutine(dashCooldown());
            yield return null;
        }

    }

    private void FatalBite()
    {
        playerInterface.GetAnimator().SetTrigger("Bite");
    }

    //SKILLS COOLDOWN
    private IEnumerator dashCooldown()
    {
        yield return new WaitForSeconds(5);
        isDashavailable = true;


    }

    //SKILLS PARTICLES
    private void playDashParticle()
    {
        Dashparticle.Play();
    }

    private void playBleedParticle()
    {
        Bleedparticle.Play();
    }

}
