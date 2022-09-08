using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    CircleCollider2D head;
    bool crashed;

    void Start() {
        head = GetComponent<CircleCollider2D>();
        crashed = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(head.IsTouching(other) && !crashed) {
            Crashed();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

    void Crashed() {
        crashed = true;
        FindObjectOfType<PlayerController>().DisableControls();
    }
}