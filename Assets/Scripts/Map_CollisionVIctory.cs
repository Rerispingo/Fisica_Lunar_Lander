using UnityEngine;
using System.Collections;
using System;

public class Map_CollisionVIctory : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Player_Movement player_movement = collision.gameObject.GetComponent<Player_Movement>();
        float player_velocity = player_movement.GetVelocity();
        float player_rotation = player_movement.GetRotation();


        // Defeat conditions  
        if (player_velocity >= Manager_Game.Instance.maxVelocity)
        {
            Defeat();
            return;
        }
        if (player_rotation >= Manager_Game.Instance.maxRotation)
        {
            Defeat();
            return;
        }

        StartCoroutine(_Victory());
    }



    // ================ Victory and Defeat ================

    private IEnumerator _Victory()
    {
        
        yield return new WaitForSeconds(1.5f);
        Manager_Game.Instance.SceneTransition(2);
    }

    private void Defeat()
    {
        Manager_Game.Instance.SceneTransition(3);
        
    }
}
