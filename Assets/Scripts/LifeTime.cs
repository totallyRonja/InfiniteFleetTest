using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {
    public float LifeDuration = 1;
    
    private Poolable poolable;
    private float spawnTime;

    private void Awake() {
        poolable = GetComponent<Poolable>();
        spawnTime = Time.time;
        poolable.Spawn += () => spawnTime = Time.time;
    }

    private void Update() {
        if(spawnTime + LifeDuration < Time.time)
            poolable.ReturnToPool();
    }
}
