using System.ComponentModel;
using UnityEngine;


public class Manager_Game : MonoBehaviour
{
    public static Manager_Game Instance { get; private set; }
    private void Awake() 
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    [Header("Game Settings")]
    public float maxVelocity = 2.5f;


    [Header("References") ]
    public Controller_HUD controller_HUD;


    public void SceneTransition(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}