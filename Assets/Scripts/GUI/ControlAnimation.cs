using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlAnimation : MonoBehaviour
{
    public VideoPlayer StartAnimation; 
    public GameObject RawImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void PlayEnd(VideoPlayer StartAnimation)  
    {
        RawImage.SetActive(false);
    }
    public void close()  
    {  
        StartAnimation.Stop();
        RawImage.SetActive(false);  
    }  
}
