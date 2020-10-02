using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private AvatarAnimationController animator;

    private Animator animatorComp;
    
    private SphereCollider bound;
    
    private CharacterCombat combat;

    private PlayerStats PlayerDamage;
    
    [SerializeField]
    private Joystick joystick;

    private CharacterController controller;

    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<AvatarAnimationController>();
        bound = GetComponent<SphereCollider>();
        combat = GetComponent<CharacterCombat>();
        PlayerDamage = GetComponent<PlayerStats>();

        animatorComp = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
    }

    private void Update()
    {
        Movement();
    }

    public void BasicAttack()
    {
        animator.ZombieAttack1();
        CollisionCheck(PlayerDamage.damage);
    }

    public void SpecialAttack()
    {
        animator.ZombieAttack2();
        CollisionCheck(PlayerDamage.SpecialDamage);
    }

    void CollisionCheck(Stat damage)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, bound.radius);
        Debug.Log(hitColliders.Length);
        
        if (hitColliders.Length > 0)
        {
            //Debug.Log("Hitting enemy");
            foreach (var hit in hitColliders)
            {
                //Debug.Log(hit);
                CharacterStats targetStats = hit.gameObject.GetComponent<EnemyStats>();
                if (targetStats != null)
                {
                    Debug.Log(targetStats);
                    combat.Attack(damage, targetStats);
                }
            }
        }
    }
    
    private void Movement()
    {
        //Get inputs from the player
        float horizontal = joystick.Horizontal * speed + Input.GetAxis("Horizontal") * speed;
        float vertical = joystick.Vertical * speed + Input.GetAxis("Vertical") * speed;

        //Get player Direction
        Vector3 dir = new Vector3(horizontal, 0f, vertical);
        //Get player movement
        Vector3 movement = new Vector3(horizontal, 0, vertical); ;

        //If player isn't moving then the direction won't change
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);
        
        //Move the player
        controller.Move(movement * speed * Time.deltaTime);
        
        // Play animation
        
        if (movement != Vector3.zero)
        {
            animator.ZombieRun();
        }

        if (movement == Vector3.zero
            && animatorComp.GetCurrentAnimatorStateInfo(0).IsName("Zombie Run"))
        {
            animator.ZombieIdle();
            print("IDLE");
        }
    }
}
