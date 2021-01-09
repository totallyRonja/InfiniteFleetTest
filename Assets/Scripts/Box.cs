using System;
using System.Collections;
using System.Collections.Generic;
using Freya;
using UnityEngine;

public class Box : MonoBehaviour {
    public Vector2 Movement;
    
    private new Rigidbody2D rigidbody;
    private List<RaycastHit2D> hits = new List<RaycastHit2D>();

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var move = Movement * Time.deltaTime;
        var distance = move.magnitude;
        var hitCount = rigidbody.Cast(move, hits, distance);
        //check collisions
        for (var i = 0; i < hitCount; i++) {
            var otherRb = hits[i].rigidbody;
            //if other is player
            if(otherRb?.bodyType == RigidbodyType2D.Kinematic && otherRb.CompareTag("Player"))
                //move collided object with own movement
                otherRb.position += Movement.WithMagnitude(distance - hits[i].distance + 0.001f); 
        }
        rigidbody.position += move;
    }
}
