using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackRotation : MonoBehaviour
{
    public bool hasRotation;

    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Transform rotationCenter;

    Vector3 slidePressedPos;
    Vector3 slideReleasedPos;
    float pressedRot;
    [HideInInspector]
    public SplineFollower parentFollower;
    

    private void Awake() => Init();

    void Update()
    {
        if (hasRotation) 
        ManageRotationControl();
        
    }

    void ManageRotationControl()
    {

        if (Input.GetMouseButtonDown(0))
        {
            slidePressedPos = GetCorrectedMousePosition();
            slideReleasedPos = GetCorrectedMousePosition();

            pressedRot = parentFollower.motion.rotationOffset.z;
        }
        else if (Input.GetMouseButton(0))
        {
            slideReleasedPos = GetCorrectedMousePosition();

            float moveMagnitude = slideReleasedPos.x - slidePressedPos.x;

            Vector3 rotAngles = parentFollower.motion.rotationOffset;

            float targetRot = pressedRot + (moveMagnitude * gameSettings.moveSpeed / (float)Screen.width);
            rotAngles.z = Mathf.Lerp(rotAngles.z, targetRot, 0.2f);
            rotAngles.z = Mathf.Clamp(rotAngles.z, -gameSettings.maxAngle, gameSettings.maxAngle);

            parentFollower.motion.rotationOffset = rotAngles;
        }
    }
    Vector3 GetCorrectedMousePosition()
    {
        Vector3 actualMousePos = new Vector3(Input.mousePosition.x - Screen.width / 2,
            Input.mousePosition.y - Screen.height / 2,
            Input.mousePosition.z);
        return actualMousePos;
    }

    
    private void Init()
    {
        parentFollower = rotationCenter.GetComponent<SplineFollower>();
       
    }
}
