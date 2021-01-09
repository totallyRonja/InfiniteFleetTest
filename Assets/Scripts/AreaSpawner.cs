using System;
using System.Collections;
using System.Collections.Generic;
using Freya;
using UnityEngine;
using Random = Freya.Random;

public class AreaSpawner : MonoBehaviour {
    public Vector2 SpawnDelay = new Vector2(1, 2);
    
    private BoxCollider2D area;
    private float nextSpawn;
    private Pool pool;
    
    private void Awake() {
        area = GetComponent<BoxCollider2D>();
        pool = GetComponent<Pool>();
        nextSpawn = Time.time;
    }

    void Update() {
        while (nextSpawn <= Time.time) {
            nextSpawn += Random.Range(SpawnDelay.x, SpawnDelay.y);
            var instance = pool.Spawn();
            var unitRect = Rect.MinMaxRect(0, 0, 1, 1);
            var size = area.size;
            var areaRect = new Rect((Vector2)transform.position + area.offset - size/2, size);
            instance.transform.position = Mathfs.Remap(unitRect, areaRect, Random.InUnitSquare);
        }
    }
}
