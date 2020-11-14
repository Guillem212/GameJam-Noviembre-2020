using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private List<Transform> m_PlayersTransforms;
    private Camera cam;

    //--------------------------------------------------------------------
    //Variables used to calculate the position and zoom of the cam
    //--------------------------------------------------------------------
    [Header("Camera Attributes")]
    [Range(0, 1)] public float m_DampTime = 0.5f;
    [Range(1, 20)] public float m_SizeMargin = 5f;
    [Range(1, 20)] public float m_MinSize = 5f;
    [Range(1, 20)] public float m_DistanceToMap = 10f;

    private float m_ZoomVelocity;
    private Vector3 m_MoveVelocity;
    private Vector3 m_TargetPosition;
    private float m_TargetSize;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        m_PlayersTransforms = new List<Transform>();
    }

    private void LateUpdate()
    {
        if(m_PlayersTransforms.Count != InputManagerSystem.m_InputManagerSystem.m_players.Count)
        {
            m_PlayersTransforms.Clear();
            foreach (UnityEngine.InputSystem.PlayerInput players in InputManagerSystem.m_InputManagerSystem.m_players)
            {
                m_PlayersTransforms.Add(players.gameObject.transform);
            }
        }
    }

    private void Update()
    {
        f_Move();
        f_Zoom();
    }

    private void f_Move()
    {
        f_CalculatecamCenter();
        transform.position = Vector3.SmoothDamp(transform.position, m_TargetPosition - transform.forward * m_DistanceToMap, ref m_MoveVelocity, m_DampTime);
    }

    private void f_Zoom()
    {
        f_CalculateTargetSize();
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, m_TargetSize, ref m_ZoomVelocity, m_DampTime);
    }

        
    private void f_CalculatecamCenter()
    {
        Vector3 averagePosition = new Vector3();

        foreach (Transform player in m_PlayersTransforms)
        {
            averagePosition += player.position;
        }

        if (m_PlayersTransforms.Count > 0)
        {
            averagePosition /= m_PlayersTransforms.Count;
        }

        m_TargetPosition = averagePosition;
    }

    private void f_CalculateTargetSize()
    {
        Vector3 screenCenterLocalSpace = cam.transform.InverseTransformPoint(m_TargetPosition);
        m_TargetSize = 0f;

        foreach (Transform player in m_PlayersTransforms)
        {
            Vector3 m_TargetPositionLocalSpace = cam.transform.InverseTransformPoint(player.position);
            Vector3 localPosition = m_TargetPositionLocalSpace - screenCenterLocalSpace;

            m_TargetSize = Mathf.Max(m_TargetSize, Mathf.Abs(localPosition.y));
            m_TargetSize = Mathf.Max(m_TargetSize, Mathf.Abs(localPosition.x) / cam.aspect);
        }

        m_TargetSize += m_SizeMargin;
        m_TargetSize = Mathf.Max(m_TargetSize, m_MinSize);

    }
}
