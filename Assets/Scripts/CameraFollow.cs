using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;

    [SerializeField] public float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private Vector3 offsetAtStart;

    [SerializeField] public bool startOffsetPosActive = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!startOffsetPosActive)
        {
            InGameOffset();
        }
        if (startOffsetPosActive)
        {
            StartPositionOffset();
        }
        
    }
    //The start position offset, where the camera need to be at main menu
    void StartPositionOffset() 
    {
        Vector3 desiredPosition = Player.position + offsetAtStart;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
    //The InGame Offset, where the camera need to be at ingame 
    void InGameOffset() 
    {
        Vector3 desiredPosition = Player.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
