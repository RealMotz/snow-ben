using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rigidBody2d;
    SurfaceEffector2D effector2D;
    bool canMove;

    // Start is called before the first frame update
    void Start() {
        rigidBody2d = GetComponent<Rigidbody2D>();
        effector2D = FindObjectOfType<SurfaceEffector2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update() {
        if(canMove) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RespondToBoost() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            effector2D.speed = boostSpeed;
        } else {
            effector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidBody2d.AddTorque(torque);
        }

        else if (Input.GetKey(KeyCode.RightArrow)) {
            rigidBody2d.AddTorque(-torque);
        }
    }

    public void DisableControls() {
        canMove = false;
    }
}
