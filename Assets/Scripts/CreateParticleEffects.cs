using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParticleEffects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleEffects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Instantiate(particleEffects, transform.position,transform.rotation);
        }
    }
}
