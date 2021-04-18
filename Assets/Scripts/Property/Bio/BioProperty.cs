using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BioProperty : MonoBehaviour
{
    public int MAX_HP;
    public int CURRENT_HP;
    public int ATK;
    public int DEF;
    public int PHYSIC_POWER;
    public int CURRENT_PHYSIC_POWER;
    public int ARMOR;
    public float CRI;
    public float CRI_DAMAGE;
    public int MANA;
    public int CURRENT_MANA;
    public float ABILITY_POWER;

    public virtual int GetGeneralAttackValue()
    {
        if (Random.value<this.CRI)
        {
            return (int)(this.ATK * (1 + this.CRI_DAMAGE));
        }
        else
        {
            return this.ATK;
        }
    }

    public virtual int GetAbilityAttackValue()
    {
        if (Random.value<this.CRI)
        {
            return (int)((this.ATK * (1 + this.ABILITY_POWER)) * (1 + this.CRI_DAMAGE));
        }
        else
        {
            return (int)(this.ATK * (1 + this.ABILITY_POWER));
        }
    }

    public virtual int GetGeneralDamage(int attackValue)
    {
        int realDamage = (attackValue - this.ARMOR);
        if (realDamage > this.DEF)
        {
            return (int)(realDamage * (1 - ((float)this.DEF /realDamage)));
        }
        else
        {
            return 0;
        }
    }

    public virtual int GetAbilityDamage(int attackValue)
    {
        return (int)(attackValue * ((float)attackValue/ (attackValue+ this.DEF)));
    }
}
