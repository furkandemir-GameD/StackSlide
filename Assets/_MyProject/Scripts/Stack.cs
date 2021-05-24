using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private StackRotation stackRotation;
    [SerializeField] private GameSettings gameSettings;
    private CharacterController characterController;
    private void Awake() => characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StackableObje")|| other.CompareTag("Player"))
        {
            stackRotation.hasRotation = true;
            GetComponent<SplineFollower>().followSpeed = gameSettings.speed;
            characterController.Stack(GetComponent<Collider>());
        }
    }
}
