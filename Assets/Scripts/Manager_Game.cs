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


    // Fully customizable game settings, can be changed in the inspector or by other scripts
    [Header("Game Settings")]
    public float maxVelocity = 2.5f;



    // References to other scripts and components, automatically assigned for other scripts
    [Header("References") ]
    public Controller_HUD controller_HUD;


    public void SceneTransition(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}