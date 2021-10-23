using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoB : MonoBehaviour
{
    const float SPEED = 6f;

    [SerializeField]
    Transform SectionInfo;

    Vector3 desiredScale = Vector3.zero;

    internal List<InfoB> ToList()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
