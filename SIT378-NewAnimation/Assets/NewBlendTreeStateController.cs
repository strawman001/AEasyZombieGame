using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlendTreeStateController : MonoBehaviour
{
    Animator animator;
    Vector3 verticalSpeed;

    //Basic Info
    [Header (header:"Movement")]
    public float basicSpeed = 1.0f;
    public float velocity = 0.0f;
    public float gravity = -9.81f;
    public float acceleration = 1.5f;
    public float deceleration = 1.5f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    //Gravity System
    [Header(header: "Jump(Gravity)  - GroundCheck")]
    public float groundDistance = 0.4f;
    public float jumpHeight = 1.0f;
    public LayerMask groundMask;
    bool isGrounded;

    //Smooth Rotation Angle
    [Header(header: "Rotation Angle")]
    float turnsmoothVelocity;
    public float turnSmoothTime = 0.1f;

    [Header(header: "Attack")]
    public float attackTimer = 0.0f;
    public float attackCoolTime = 2.0f;
    public float attackDamage = 20.0f;
    public float attackSpeed = 1.0f;

    //Roll
    [Header(header: "Roll")]
    public float rollCoolTime = 1.5f;
    public float rollTimer = 0.0f;

    /*REFERENCE - Get Component*/
    [Header(header: "REFERENCE")]
    public CharacterController controller;
    public Transform groundCheck;
    public Transform cam;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        VelocityHash = Animator.StringToHash("Velocity");

    }


    void playerPositionMove(float vertical, float horizontal)
    {
        Vector3 moveDir;

        //地面检测
        //Check Is Ground?
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //攻击限制(空中)
        //Attack Limit （In The Air）
        animator.SetBool("isGrounded", isGrounded);


        //重置下落位移值-y
        //Reset fall speed - y
        if (isGrounded && verticalSpeed.y < 0)
        {
            verticalSpeed.y = -2.0f;
        }

        //取得用户水平面输入
        //Get user's input value (X-Z Plane)
        Vector3 dir = new Vector3(horizontal, 0.0f, vertical).normalized;

        if ( dir != new Vector3(0, 0, 0))
        {
            /*
             * 根据二元反切函数输出角,之后使用Mathf.Rad2Deg函数将弧度转角度
             * （推荐不要直接使用，unity中旋转角度为四元数需要转换，如果要强行使用可用eulerAngles函数进行处理）
             * 
            * Output the Angle according to the binary inverse tangent function, and then use the 'mathf.rad2deg()' function to turn radians into angles
            * (It is recommended not to use it directly. In Unity, a quaternion rotation requires conversion, but if you want to force it, you can use 'eulerAngles' function)
           */
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //经过Unity 标准的平滑角度过度
            //Unity standard Angle of smooth processing
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnSmoothTime);

            /*
             * 调整角色面向角度 - 使用四元数欧拉角（返回值为一个旋转角度，绕z轴旋转z度， 绕x轴旋转x度， 绕y轴旋转y度）
             * 最终得出可用的旋转角度
             * 
             * Adjust the character's face Angle - using quad Euler angles
             * Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis;
             */
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            //取得位移方向
            //Obtain displacement direction
            moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * new Vector3(0, 0, 1);

            //平面位移-移动角色
            //Plane Movement - Move the character
            controller.Move(moveDir * velocity * basicSpeed * Time.deltaTime);

            //DEBUG
            //Debug.Log("velocity:" + velocity + "  moveDir: " + moveDir);
            //Debug.Log("moveDir: " + moveDir);
            //Debug.Log("Euler:" + Quaternion.Euler(0.0f, targetAngle, 0.0f));
            //Debug.Log("angle: " + angle);
        }

        //垂直高度移动 - 跳跃
        //Vertical height movement - jump
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            verticalSpeed.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            //animator.SetTrigger("Jump");
        }

        //Roll
        Roll( vertical, horizontal );

        //Attack
        Attack();

        //垂直高度移动 - 下落
        //Vertical height movement - fall
        verticalSpeed.y += gravity * Time.deltaTime;
        controller.Move(verticalSpeed * Time.deltaTime);

    }
    
    void movementAnimationPlay(bool isMoving, bool runPressed, float currentMaxVelocity)
    {
        //加速
        //Speed up
        if (isMoving && velocity < currentMaxVelocity)
        {
            velocity += Time.deltaTime * acceleration;
        }

        //减速
        //Slow down
        if (!isMoving && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        //垂直速度 - 不动
        //Reset velocity value - NOT MOVING
        if (!isMoving && velocity < 0)
        {
            velocity = 0.0f;
        }

        //重置速度 - 走 & 跑
        //Reset velocity value - WALKING & RUNNING
        if (isMoving && runPressed && velocity > currentMaxVelocity)
        {
            velocity = currentMaxVelocity;
        }
        else if (isMoving && velocity > currentMaxVelocity)
        {
            velocity -= Time.deltaTime * deceleration;
            if (velocity > currentMaxVelocity && velocity < (currentMaxVelocity + 0.05f))
            {
                velocity = currentMaxVelocity;
            }
        }
        else if (isMoving && velocity < currentMaxVelocity && velocity > (currentMaxVelocity - 0.05f))
        {
            velocity = currentMaxVelocity;
        }

        //移动动画播放
        //Movement Animation play
        animator.SetFloat(VelocityHash, velocity);

    }
    
    void Roll(float vertical, float horizontal)
    {
        if (rollTimer > 0)
        {
            rollTimer -= Time.deltaTime;
        }

        if (rollTimer < 0)
        {
            rollTimer = 0;
        }

        if (rollTimer == 0 && Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            controller.Move(Vector3.forward * basicSpeed * Time.deltaTime);
            animator.SetTrigger("Roll");
            rollTimer = rollCoolTime;
        }

    }

    void Attack()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (attackTimer == 0 && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Debug.Log("Attack");
            attackTimer = attackCoolTime;
        }
    }


    // Update is called once per frame 
    void Update()
    {

        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        bool isMoving = forwardPressed || backPressed || leftPressed || rightPressed;
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        movementAnimationPlay(isMoving, runPressed, currentMaxVelocity);
        playerPositionMove(vertical, horizontal);
        
        //Debug.Log("vertical:" + vertical + " horizontal:" + horizontal);

    }
}
