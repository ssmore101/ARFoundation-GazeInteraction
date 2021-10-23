using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    List<InfoB> infos = new List<InfoB>();
    void Start()
    {
        infos = FindObjectsOfType<InfoB>().ToList();
    }


    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenInfo(go.GetComponent<InfoB>());
            }
        }
    }

    void OpenInfo(InfoB desiredInfo)
    {
        foreach(InfoB info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach (InfoB info in infos)
        {
            info.CloseInfo();
        }
    }
}
