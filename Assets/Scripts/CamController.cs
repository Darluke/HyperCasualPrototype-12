using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    public List<CinemachineVirtualCamera> cams=new List<CinemachineVirtualCamera>();
    
    public CinemachineVirtualCamera desiredCam;


    private void Start()
    {
        for(int i=0;i<transform.childCount; i++)
        {
            cams.Insert(i,transform.GetChild(i).GetComponent<CinemachineVirtualCamera>());
        }
    }
    public void ChangeCam(CinemachineVirtualCamera desiredCam)
    {
        this.desiredCam = desiredCam;

        //foreach (CinemachineVirtualCamera cam in cams)
        //{
        //    if (cam == desiredCam) cam.m_Priority = 1;
        //    else cam.m_Priority = -1;

        //}
        StartCoroutine("ChangeCamPriority");

        
    }

    IEnumerator ChangeCamPriority()
    {
        yield return new WaitForSeconds(1);
        foreach (CinemachineVirtualCamera cam in cams)
        {
            if (cam == desiredCam) cam.m_Priority = 1;
            else cam.m_Priority = -1;

        }

    }
   
   
}
