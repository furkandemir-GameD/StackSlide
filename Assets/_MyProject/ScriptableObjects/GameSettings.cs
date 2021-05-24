using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Camera Properties")]
    [SerializeField] private float ShakeDuration;
    public float shakeDuration { get { return ShakeDuration; } set { ShakeDuration = value; } }

    [SerializeField] private float ShakeAmplitude;
    public float shakeAmplitude { get { return ShakeAmplitude; } set { ShakeAmplitude = value; } }

    [SerializeField] private float ShakeFrequency;
    public float shakeFrequency { get { return ShakeFrequency; } set { ShakeFrequency = value; } }

    [Header("Character Properties")]
    [SerializeField] private float MaxAngle;
    public float maxAngle { get { return MaxAngle; } set { MaxAngle = value; } }

    [SerializeField] private float Speed;
    public float speed { get { return Speed; } set { Speed = value; } }

    [SerializeField] private float MoveSpeed;
    public float moveSpeed { get { return MoveSpeed; } set { MoveSpeed = value; } }

    [Header("Obstacle Properties")]
    [SerializeField] private float OtherImpulseForward;
    public float otherImpulseForward { get { return OtherImpulseForward; } set { OtherImpulseForward = value; } }

    [SerializeField] private float OtherImpulseUp;
    public float otherImpulseUp { get { return OtherImpulseUp; } set { OtherImpulseUp = value; } }

    [SerializeField] private float ObstacleImpulseForward;
    public float obstacleImpulseForward { get { return ObstacleImpulseForward; } set { ObstacleImpulseForward = value; } }

    [SerializeField] private float ObstacleImpulseUp;
    public float obstacleImpulseUp { get { return ObstacleImpulseUp; } set { ObstacleImpulseUp = value; } }
}
