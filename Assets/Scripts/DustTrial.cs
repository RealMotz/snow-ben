using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrial : MonoBehaviour
{
    [SerializeField] ParticleSystem trail;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Terrain") {
            trail.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Terrain") {
            trail.Stop();
        }
    }
}
