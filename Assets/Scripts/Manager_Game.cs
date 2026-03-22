using System.ComponentModel;
using UnityEngine;


public class Manager_Game : MonoBehaviour
{
    // Singleton
    public static Manager_Game Instance { get; private set; }
    private void Awake() 
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }


    // Configurable game settings
    [Header("Game Settings")]
    public float maxVelocity = 2.5f;
    public float maxRotation = 15f;


    // Statistics
    [Header("Statistics")]
    public float Score = 0f;

    // References to other scripts and components, automatically assigned for other scripts
    [Header("References") ]
    public Controller_HUD controller_HUD;


    // Transitions to a different scene (Usually used for level changer)
    public void SceneTransition(int index)
    {
        // 0 - Main Menu
        // 1 - Game (Level 01)
        // 2 - Victory Screen
        // 3 - Defeat Screen
        // 4 - Game (Level 02)
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }


    // Quits the application
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}