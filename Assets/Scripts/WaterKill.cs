using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKill : MonoBehaviour {
    public float WaterHeight = 0;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.up * WaterHeight, Vector3.right * 100);
    }

    void Update() {
        if (transform.position.y < WaterHeight)
            GameState.Current.Reset();
    }
}
