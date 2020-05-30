using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewmonsterAI : MonoBehaviour
{
    public const int AI_Null = 10;
    public const int AI_Idle = 0;
    public const int AI_Patrol = 1;
    public const int AI_Pursuit = 2;
    public const int AI_Attack = 3;
    public const int AI_Attack_Idle = 4;
    public const int AIA_BackPoint = 5;

    public const float followUpDistance = 3.0f;
    public const float attackDistance = 2.0f;

    public const float vAttackDeltaTime = 1.0f;

    public const float maxFollow = 20.0f;
    public const float speed = 2.0f;
    public const float runSpeed = 3.0f;
    public const float vEscapeSpeed = 6.0f;

    public Rect vRect = new Rect(0, 0, 10, 10);

    public Vector2 Dis;
    public Vector2 srcPoint;

    public GameObject player;
    public int vStartState;
    public int vLostState;
    // Use this for initialization
    void Start()
    {
        vStartState = AI_Idle;
        vLostState = AI_Null;
        srcPoint = new Vector2(transform.position.x, transform.position.z);
        player = GameObject.Find("Viking");
    }

    // Update is called once per frame
    void Update()
    {
        switch (vStartState)
        {
            case AI_Idle:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                    Debug.Log("1");
                }
                fGetPatrolPosition();
                vStartState = AI_Patrol;
                break;
            case AI_Patrol:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                    Debug.Log("2");
                }
                fPatrovRect();
                if (Vector2.Distance(Dis, new Vector2(transform.position.x, transform.position.z)) < 0.4f)
                {
            

                    vStartState = AI_Idle;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < followUpDistance)
                {
                    vStartState = AI_Pursuit;
                }

                break;
            case AI_Pursuit:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                    Debug.Log("3");
                }
                fPursuitHero();
                if (Vector3.Distance(new Vector3(srcPoint.x, transform.position.y, srcPoint.y), transform.position) > maxFollow && Vector3.Distance(transform.position, player.transform.position) > followUpDistance)
                {
                    vStartState = AIA_BackPoint;
                }
                if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
                {
                    vStartState = AI_Attack;
                }
                break;
            case AI_Attack:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                    Debug.Log("4");
                }
                fAttackHero();
                if (Time.time - backUptime >= 0.2f)
                {
                    backUptime = Time.time;
                    vStartState = AI_Attack_Idle;
                }
                break;
            case AI_Attack_Idle:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                }
                vStartState = AI_Pursuit;
                break;
            case AIA_BackPoint:
                if (vStartState != vLostState)
                {
                    vLostState = vStartState;
                }
                fBackPoint();
                if (Vector2.Distance(srcPoint, new Vector2(transform.position.x, transform.position.z)) < 1)
                {
                    vStartState = AI_Idle;
                }
                break;
        }

    }

    private void fBackPoint()
    {
        transform.LookAt(new Vector3(srcPoint.x, transform.position.y, srcPoint.y));
        transform.Translate(Vector3.forward * vEscapeSpeed * Time.deltaTime);
    }
    public float backUptime;
    private void fAttackHero()
    {

    }

    private void fPursuitHero()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        //transform.Translate(Vector3.forward * vEscapeSpeed * Time.deltaTime);
    }

    private void fPatrovRect()
    {
        transform.LookAt(new Vector3(Dis.x, transform.position.y, Dis.y));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void fGetPatrolPosition()
    {
        Vector2 vCur;
        do
        {
            float minX = srcPoint.x - vRect.width / 2;
            float minY = srcPoint.y - vRect.height / 2;
            float maxX = srcPoint.x + vRect.width / 2;
            float maxY = srcPoint.y + vRect.height / 2;
            float disX = Random.Range(minX, maxX);
            float disY = Random.Range(minY, maxY);
            Dis = new Vector2(disX, disY);
            vCur = new Vector2(transform.position.x, transform.position.z);
        }
        while (Vector2.Distance(Dis, vCur) < 5);
    }
}
