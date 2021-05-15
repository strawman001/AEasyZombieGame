using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInterface : MonoBehaviour
{
    public float detectDistance = 5.0f;
    public Vector3 centerVector3;

    private SphereCollider sphereCollider;
    private bool isInDialog = false;
    private BaseDialog baseDialog;
    private void Start()
    {
        sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = detectDistance;
        sphereCollider.center = centerVector3;
        sphereCollider.isTrigger = true;
        baseDialog = GetComponent<BaseDialog>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInDialog)
        {
            TalkButton.Instance.SetTalkButton(delegate
            {
                DialogUI.Instance.BeginDialog(baseDialog.GetDialogTree());
                isInDialog = true;
            });
            TalkButton.Instance.ShowTalkButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isInDialog)
        {
            TalkButton.Instance.HideTalkButton();
        }
        else
        {
            DialogUI.Instance.StopDialog();
        }

        isInDialog = false;
    }
}
