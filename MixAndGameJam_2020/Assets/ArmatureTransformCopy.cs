using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatureTransformCopy : MonoBehaviour
{
    Transform bodyObject;
    //public Transform m_CopyOrigin;
    //public Transform m_CopyDestiny;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] t_childs = transform.parent.GetComponentsInChildren<Transform>();
        foreach (Transform t in t_childs)
        {
           if (t.name.Contains("Parent")) bodyObject = t;        
        }        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = bodyObject.rotation;
        //m_CopyOrigin.rotation = m_CopyDestiny.rotation;
    }
}
