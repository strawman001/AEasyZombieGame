using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewmonsterAI : MonoBehaviour
{
    public const int Null = 2;


    public const float followUpDistance = 3.0f;
    public const float attackDistance = 2.0f;

    public const float maxFollow = 20.0f;
    public const float speed = 5.0f;


    public Rect vRect = new Rect(0, 0, 10, 10);

    public Vector2 Dis;
    public Vector2 srcPoint;

 
    public int StartState;
    public int LostState;
    // Use this for initialization
    void Start()
    {
        StartState = 0;
        LostState = Null;
        srcPoint = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        switch (StartState)
        {
            case 0:
                if (StartState != LostState)
                {
                    LostState = StartState;
                }
                GetPatrolPosition();
                StartState = 1;
                break;
            case 1:
                if (StartState != LostState)
                {
                    LostState = StartState;
                }
                PatrovRect();
                if (Vector2.Distance(Dis, new Vector2(transform.position.x, transform.position.z)) < 0.4f)
                {       
                    StartState = 0;
                }
                break;
        }

    }

    private void PatrovRect()
    {
        transform.LookAt(new Vector3(Dis.x, transform.position.y, Dis.y));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void GetPatrolPosition()
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
