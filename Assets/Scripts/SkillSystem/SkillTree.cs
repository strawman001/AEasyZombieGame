using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    private GameObject gameImage;
    private GameObject unlocked;
    private PlayerSkillHolder playerSkillHolder;
    private PlayerController playerController;
    private bool active;

    void Awake()
    {
        playerSkillHolder = new PlayerSkillHolder();
    }

    void Start()
    {
        gameImage = GetComponent<UIComponentManager>().GetUIComponent("SkillUI");
        unlocked = GetComponent<UIComponentManager>().GetUIComponent("UnlockedText");
    }

    public void SkillOnOff()
    {
        if (active == false)
        {
            Time.timeScale = 0;
            gameImage.SetActive(true);
            active = true;
            unlocked.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            gameImage.SetActive(false);
            active = false;
            unlocked.SetActive(false);
        }
    }

    public void UnlockLifeSteal()
    {
        playerSkillHolder.UnlockSkill(PlayerSkillHolder.Skill.LifeSteal);
        unlocked.SetActive(true);
    }

    public void UnlockDash()
    {
        playerSkillHolder.UnlockSkill(PlayerSkillHolder.Skill.Dash);
    }

    public void UnlockFatalBite()
    {
        playerSkillHolder.UnlockSkill(PlayerSkillHolder.Skill.FatalBite);
    }



}