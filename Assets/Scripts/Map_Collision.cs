using UnityEngine;

public class Map_Collision : MonoBehaviour
{
    [SerializeField] private bool is_defeat = true;


    void OnCollisionEnter(Collision collision)
    {
        if (is_defeat) Manager_Game.Instance.SceneTransition(3);
    }
}
