using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private List<GameObject> stackedObjects = new List<GameObject>();

    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private CameraHandler cameraHandler;
    [SerializeField] private Transform rotationCenter;
 
    Vector3 slidePressedPos;
    Vector3 slideReleasedPos;
    float pressedRot;
    [HideInInspector]
    public SplineFollower parentFollower;

    private void Awake() => Init();
      
    void Update()
    {
       ManageRotationControl();
        for (int i = 0; i < stackedObjects.Count; i++)
        {
            stackedObjects[i].transform.rotation = parentFollower.transform.rotation;
        }
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
  
    public void Stack(Collider other)
    {
        cameraHandler.CameraShake();
        stackedObjects.Add(other.gameObject);
    }
    private void Init()
    {
        parentFollower = rotationCenter.GetComponent<SplineFollower>();
        parentFollower.motion.rotationOffset = new Vector3(0, 0, 0);
        parentFollower.followSpeed = gameSettings.speed;
    }
}
