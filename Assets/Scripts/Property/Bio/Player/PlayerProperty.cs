using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerProperty: MonoBehaviour
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

    public  int GetGeneralAttackValue()
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

    public int GetAbilityAttackValue()
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

    public int GetGeneralDamage(int attackValue)
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

    public int GetAbilityDamage(int attackValue)
    {
        return (int)(attackValue * ((float)attackValue/ (attackValue+ this.DEF)));
    }

    public int STRENGTH;
    public int LIFE;
    public int STAMINA;
    public int INTELLIGENCE;
    public int EXPLOSION;

    public virtual int CalATK(int strength)
    {
        if (strength <= 10)
        {
            return strength * 5;
        }
        else
        {
            return strength * 5 + (int)((strength - 10) * 1.5f);
        }
    }

    public virtual int CalDEF(int stamina)
    {
        return stamina;
    }

    public virtual int CalPHYSIC_POWER(int stamina)
    {
        return stamina * 20;
    }

    public virtual int CalMAX_HP(int life)
    {
        return life * 20;
    }

    public virtual float CalCRI(int explosion)
    {
        float value = (float)Math.Log(explosion + 1, 1000);
        return value > 1f ? 1f : value;
    }

    public virtual float CalCRI_DAMAGE(int explosion,int strength)
    {
        float value =  (float)Math.Log(explosion + 1, 3000) + strength * 0.005f;
        return value > 1f ? 1f : value;
    }

    public virtual int CalMANA(int intelligence)
    {
        return 0;
    }

    public virtual float CalABILITY_POWER(int intelligence)
    {
        return 0;
    }

}
