using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class PlayerPropertyManager : MonoBehaviour
{
    private static PlayerPropertyManager instance = null;
    private PlayerPropertyManager(){}
    public static PlayerPropertyManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private static int strengthValue = 0;
    private static int lifeValue = 0;
    private static int staminaValue = 0;
    private static int intelligenceValue = 0;
    private static int explosionValue = 0;
    private static int currentAvailablePoints = 0;
    private static int originalAvailablePoints = 0;
    
    private PlayerProperty playerProperty;
    private void Start()
    {
        playerProperty = PlayerInterface.Instance.GetPlayerProperty();
        InitInnerAttributes();
        UpdateAvailiablePoints();
    }

    private void InitInnerAttributes()
    {
        strengthValue = 0;
        lifeValue = 0;
        staminaValue = 0;
        intelligenceValue = 0;
        explosionValue = 0;
    }

    private void UpdateAvailiablePoints()
    {
        currentAvailablePoints = GlobalData.availiablePoints;
        originalAvailablePoints = GlobalData.availiablePoints;
    }

    public void AddInnerAttribute(string attrName)
    {
        if (currentAvailablePoints!=0)
        {
            FieldInfo fieldInfo = GetType().GetField(attrName,BindingFlags.NonPublic|BindingFlags.Static);
            int currentValue = (int)fieldInfo.GetValue(this);
            fieldInfo.SetValue(this,currentValue+1);
            currentAvailablePoints -= 1;
            AttributeUI.Instance.UpdatePanelStatus();
        }
        
    }
    
    public void ReduceInnerAttribute(string attrName)
    {
        FieldInfo fieldInfo = GetType().GetField(attrName,BindingFlags.NonPublic|BindingFlags.Static);
        int currentValue = (int)fieldInfo.GetValue(this);
        if (currentValue!=0)
        {
            fieldInfo.SetValue(this,currentValue-1);
            currentAvailablePoints += 1;
            AttributeUI.Instance.UpdatePanelStatus();
        }
    }

    public void ConfirmChange()
    {
        GlobalData.availiablePoints = currentAvailablePoints;

        playerProperty.STRENGTH += strengthValue;
        playerProperty.STAMINA += staminaValue;
        playerProperty.LIFE += lifeValue;
        playerProperty.EXPLOSION += explosionValue;
        playerProperty.INTELLIGENCE += intelligenceValue;

        playerProperty.MAX_HP = playerProperty.CalMAX_HP(playerProperty.LIFE);
        playerProperty.ATK = playerProperty.CalATK(playerProperty.STRENGTH);
        playerProperty.DEF = playerProperty.CalDEF(playerProperty.STAMINA);
        playerProperty.CRI = playerProperty.CalCRI(playerProperty.EXPLOSION);
        playerProperty.CRI_DAMAGE = playerProperty.CalCRI_DAMAGE(playerProperty.EXPLOSION,playerProperty.STRENGTH);
        playerProperty.PHYSIC_POWER = playerProperty.CalPHYSIC_POWER(playerProperty.STRENGTH);
        playerProperty.ABILITY_POWER = playerProperty.CalABILITY_POWER(playerProperty.INTELLIGENCE);
        playerProperty.MANA = playerProperty.CalMANA(playerProperty.INTELLIGENCE);
        
        InitInnerAttributes();
        UpdateAvailiablePoints();
        AttributeUI.Instance.ShowProperty();
    }

    public bool isConfirmable()
    {
        return originalAvailablePoints != currentAvailablePoints;
    }

    public Dictionary<string,string> GetProperty()
    {
        return new Dictionary<string, string>()
        {
            {"MaxHP",playerProperty.MAX_HP+""},
            {"ATK",playerProperty.ATK+""},
            {"DEF",playerProperty.DEF+""},
            {"CRI",(int)(playerProperty.CRI*100)+"%"},
            {"CRIDamage",(int)(playerProperty.CRI_DAMAGE*100)+"%"},
            {"PhysicPower",playerProperty.PHYSIC_POWER+""},
            {"Armor",playerProperty.ARMOR+""},
            {"Mana",playerProperty.MANA+""},
            {"AbilityPower",(int)(playerProperty.ABILITY_POWER*100)+"%"},
            
            {"Strength",playerProperty.STRENGTH+""},
            {"Life",playerProperty.LIFE+""},
            {"Stamina",playerProperty.STAMINA+""},
            {"Intelligence",playerProperty.INTELLIGENCE+""},
            {"Explosion",playerProperty.EXPLOSION+""},
            
            {"AvailablePoints",originalAvailablePoints+""}
        };
    }

    public Dictionary<string, string> GetUpdatedProperty()
    {
        return new Dictionary<string, string>()
        {
            {"MaxHP",playerProperty.CalMAX_HP(playerProperty.LIFE+lifeValue)+""},
            {"ATK",playerProperty.CalATK(playerProperty.STRENGTH+strengthValue)+""},
            {"DEF",playerProperty.CalDEF(playerProperty.STAMINA+staminaValue)+""},
            {"CRI",(int)(playerProperty.CalCRI(playerProperty.EXPLOSION+explosionValue)*100)+"%"},
            {"CRIDamage",(int)(playerProperty.CalCRI_DAMAGE(playerProperty.EXPLOSION+explosionValue,playerProperty.STRENGTH+strengthValue)*100)+"%"},
            {"PhysicPower",playerProperty.CalPHYSIC_POWER(playerProperty.STAMINA+staminaValue)+""},
            {"Armor",playerProperty.ARMOR+""},
            {"Mana",playerProperty.CalMANA(playerProperty.INTELLIGENCE+intelligenceValue)+""},
            {"AbilityPower",(int)(playerProperty.CalABILITY_POWER(playerProperty.INTELLIGENCE+intelligenceValue)*100)+"%"},
            
            {"Strength",(playerProperty.STRENGTH+strengthValue)+""},
            {"Life",(playerProperty.LIFE+lifeValue)+""},
            {"Stamina",(playerProperty.STAMINA+staminaValue)+""},
            {"Intelligence",(playerProperty.INTELLIGENCE+intelligenceValue)+""},
            {"Explosion",(playerProperty.EXPLOSION+explosionValue)+""},
            
            {"AvailablePoints",currentAvailablePoints+""}
        };
    }

    public Dictionary<string, bool> GetIsChangedProperty()
    {
        return new Dictionary<string, bool>()
        {
            {"StrengthRedButton",strengthValue != 0},
            {"StaminaRedButton",staminaValue != 0},
            {"LifeRedButton",lifeValue != 0},
            {"IntelligenceRedButton",intelligenceValue != 0},
            {"ExplosionRedButton",explosionValue != 0}
        };
    }

    public bool isAvailable()
    {
        return currentAvailablePoints != 0;
    }
}
