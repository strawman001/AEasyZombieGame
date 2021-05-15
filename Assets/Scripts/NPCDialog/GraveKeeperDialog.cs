using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveKeeperDialog : BaseDialog
{
    
    public override DialogTree InitDialogTree()
    {
        DialogGeneralNode firstMeeting = DialogTree.MakeDialogGeneralNode("Another Zombie, You are not belong here. Leave the grave.");
        DialogTree dialogTree = new DialogTree(firstMeeting);

        DialogNode firstMeetingEnd = firstMeeting.AddNextDialogNode(new DialogSelectNode("What happened?"))
            .AddNextDialogNode(DialogTree.MakeDialogGeneralNode("You can talk! Perhaps you are the one they want."))
            .AddNextDialogNode(new DialogSelectNode("They?"))
            .AddNextDialogNode(DialogTree.MakeDialogGeneralNode("Haha, they will come to you once you wake."));


        DialogGeneralNode askTaskStatus = DialogTree.MakeDialogGeneralNode("Did you finish my task?");
        DialogActionNode acceptTask = DialogTree.MakeNoParamActionNode(delegate
        {
            SideTaskGraveScene sideTaskGraveScene = new SideTaskGraveScene();
            sideTaskGraveScene.InitializeTask();
            dialogTree.ChangeRoot(askTaskStatus);
        });
        DialogGeneralNode refuseTask = DialogTree.MakeDialogGeneralNode("All right, if you change your mind, you can ask for it anytime.");
        
        DialogNode askForHelp = DialogTree.MakeDialogGeneralNode("Anyway, can you do me a favor, kill the two soul shadows. I will give you a good thing as reward.");
        askForHelp.AddNextDialogNode(
            DialogTree.MakeDialogSelectNode(new List<string>(){"OK, I will do that for you","Sorry, I have to go."},
                new List<DialogNode>()
                {
                    acceptTask,refuseTask
                })
        );

        acceptTask.AddNextDialogNode(DialogTree.MakeDialogGeneralNode("Good, just do it.")).AddNextDialogNode(DialogEndNode.Instance);
        refuseTask.AddNextDialogNode(DialogEndNode.Instance);

        firstMeetingEnd.AddNextDialogNode(DialogTree.MakeNoParamActionNode(delegate
        {
            dialogTree.ChangeRoot(askForHelp);
        })).AddNextDialogNode(askForHelp);
        
        
        DialogSelectNode finishTaskDialogNode = new DialogSelectNode();
        finishTaskDialogNode.AddNextDialogNodePair("No,I have not finished it, I need more time.",DialogEndNode.Instance);
        
        DialogGeneralNode goodByeDialogNode = new DialogGeneralNode("Good bye, little zombie.");
        goodByeDialogNode.AddNextDialogNode(DialogEndNode.Instance);

        DialogActionNode checkTaskFinish = DialogTree.MakeNoParamActionNode(delegate
        {
            
            string taskKey = "SideTaskGraveScene";
            if (TaskController.Instance.activeTaskDictionary[taskKey].isFinished)
            {
                finishTaskDialogNode
                    .AddNextDialogNodePair("Yes,I finished.", DialogTree.MakeNoParamActionNode(delegate
                    {
                        TaskController.Instance.activeTaskDictionary[taskKey].TaskCompleted();
                    }))
                    .AddNextDialogNode(DialogTree.MakeDialogGeneralNode("Good, hand the equipment."))
                    .AddNextDialogNode(DialogTree.MakeNoParamActionNode(delegate
                    {
                        dialogTree.ChangeRoot(goodByeDialogNode);
                    })).AddNextDialogNode(DialogEndNode.Instance);
            }
        });
        
        askTaskStatus.AddNextDialogNode(checkTaskFinish).AddNextDialogNode(finishTaskDialogNode);



        return dialogTree;
    }
}
