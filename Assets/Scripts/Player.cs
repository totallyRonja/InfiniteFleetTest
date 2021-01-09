using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Freya;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    public float Gravity = -2;
    public float Speed = 1;
    public float JumpSpeed = 5;

    private float fallSpeed = 0;
    private new Rigidbody2D rigidbody;
    private List<RaycastHit2D> hits = new List<RaycastHit2D>();
    private bool grounded = false;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        fallSpeed += Gravity * Time.deltaTime;
        var speed = new Vector2(0, fallSpeed);
        if (Keyboard.current.dKey.isPressed)
            speed.x += Speed;
        if (Keyboard.current.aKey.isPressed)
            speed.x -= Speed;
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame)
            if (grounded)
                fallSpeed = JumpSpeed;
        var move = speed * Time.deltaTime;
        move.y -= 0.001f; //make sure we always touch the ground when standing on it

        Move(move);
    }

    private void Move(Vector2 movement) {
        grounded = false;
        for (int iter = 0; iter < 5; iter++) {
            //cast a bit
            var distance = movement.magnitude;
            var hitCount = rigidbody.Cast(movement, hits, distance);
            //if we hit nothing we can fly
            if (hitCount == 0) {
                rigidbody.position += movement;
                return;
            }
            //if we do, think about how to continue
            var hit = hits.First();
            if(hit.normal == -movement) {
                rigidbody.position += movement;
                return;
            }
            if (hit.normal.y > (1 / Mathfs.SQRT2)) { //reset fall speed when hitting ground (flatter than 45°)
                fallSpeed = Mathfs.Max(fallSpeed, 0); //stop fall when we're on the ground
                grounded = true;
            }
            rigidbody.position += movement.WithMagnitude(hit.distance) + hit.normal * 0.001f;
            var tangent = hit.normal.Rotate90CW();
            movement = movement.WithMagnitude(distance - hit.distance); //take away walked distance
            movement = tangent * Vector2.Dot(tangent, movement); //align with hit tangent
        }
        //didnt find a result in limited iterations
        rigidbody.position += movement;
    }
}
