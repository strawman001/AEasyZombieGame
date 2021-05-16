using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder
{
    //List of all the skills, this can be added upon
    public enum Skill
    {
        LifeSteal,
        Dash,
        FatalBite,
    }

    private List<Skill> UnlockedList;

    //Making the 'unlockedskillslist'
    public PlayerSkillHolder()
    {
        UnlockedList = new List<Skill>();
    }

    //To apply and unlock a skill to the 'unlockedskillslist'
    public void UnlockSkill(Skill skill)
    {
        UnlockedList.Add(skill);
        Debug.Log("unlocked " + skill);
        Debug.Log(UnlockedList.Contains(skill));
    }

    //To to give a check for finding out which skills have been unlocked
    public bool CheckForUnlock(Skill skill)
    {
        return UnlockedList.Contains(skill);
    }
}
