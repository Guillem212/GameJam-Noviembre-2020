using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatureTransformCopy : MonoBehaviour
{
    public Transform m_CopyOrigin;
    public Transform m_CopyDestiny;

    // Update is called once per frame
    void Update()
    {
        m_CopyOrigin.rotation = m_CopyDestiny.rotation;
    }
}
