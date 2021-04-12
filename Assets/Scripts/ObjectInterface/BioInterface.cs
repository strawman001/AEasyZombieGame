using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BioInterface : MonoBehaviour
{
    public abstract void ReceiveGeneralDamage(int damage);
    public abstract void ReceiveAbilityDamage(int damage);
    public abstract void Die();
}
