using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraRotate cameraRotate;
    // Start is called before the first frame update
    void Start()
    {
        cameraRotate = GetComponent<UIComponentManager>().GetUIComponent("Camera").GetComponent<CameraRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RotateBeigin(int direction)
    {
        cameraRotate.RotateBeigin(direction);
    }

    public void RotateEnd()
    {
       cameraRotate.RotateEnd();
    }
}
