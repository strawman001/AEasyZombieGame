using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int targetBrainNum; 
    public int currentBrainNum;

    public LevelData(int targetBrainNum,int currentBrainNum)
    {
        this.targetBrainNum = targetBrainNum;
        this.currentBrainNum = currentBrainNum;
    }
    
    public LevelData(LevelInfo levelInfo)
    {
        this.targetBrainNum = levelInfo.targetBrainNum;
        this.currentBrainNum = 0;
    }

    public void AddOneBrain()
    {
        currentBrainNum += 1;
    }
}
