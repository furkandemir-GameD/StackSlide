using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameSettings gameSettings;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StackableObje"))
        {
            _rb.AddForce(transform.forward * gameSettings.obstacleImpulseForward, ForceMode.Impulse);
            _rb.AddForce(transform.up * gameSettings.obstacleImpulseUp, ForceMode.Impulse);
            other.GetComponent<SplineFollower>().enabled = false;
            other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * gameSettings.otherImpulseForward, ForceMode.Impulse);
            other.transform.GetComponent<Rigidbody>().AddForce(transform.up * gameSettings.otherImpulseUp, ForceMode.Impulse);
            GetComponent<Collider>().enabled = false;
        }
    }
}
