using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BioInterface : MonoBehaviour
{
    public abstract void ReceiveDamage(int damage);
    public abstract void Die();
}
