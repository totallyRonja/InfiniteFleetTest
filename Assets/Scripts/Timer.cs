using System;
using System.Collections;
using System.Collections.Generic;
using Freya;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float startTime;
    private TMP_Text text;

    private void Awake() {
        text = GetComponent<TMP_Text>();
    }

    private void Start() {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        var elapsed = Time.time - startTime;
        text.text = $"{Mathfs.Floor(elapsed / 60)}:{Mathfs.Floor(elapsed % 60):00}:{Mathfs.Floor((elapsed % 1) * 1000):000}";
    }
}
