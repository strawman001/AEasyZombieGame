using UnityEngine;

public class HitReaction : MonoBehaviour
{
    public int isHit = 0;

    void OnCollisionEnter(Collision collision)
    {
        isHit ++;
        if (collision.gameObject.tag == "Bat")
        {
            Debug.Log("Punch you");
        }
    }

}
