using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    public static GameState Current;
    public static ObservableValue<bool> Won = new ObservableValue<bool>(false);

    private void OnEnable() {
        if(Current != null)
            Debug.LogWarning("There is more than one active GameState in a Scene, this shouldn't happen");
        Current = this;
    }

    private void OnDisable() {
        if (Current == this)
            Current = null;
    }

    private void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) 
            Reset();
    }

    public void Win() {
        Won.Value = true;
        Time.timeScale = 0;
    }

    public void Reset() {
        Time.timeScale = 1;
        Won.Value = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
