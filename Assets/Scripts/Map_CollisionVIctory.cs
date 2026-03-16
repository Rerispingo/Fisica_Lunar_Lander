using UnityEngine;
using System.Collections;
using System;

public class Map_CollisionVIctory : MonoBehaviour
{
    private float velocity_max;

    void Start()
    {
        velocity_max = Manager_Game.Instance.maxVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        float player_velocity = collision.gameObject.GetComponent<Player_Movement>().GetVelocity();


        // Defeat conditions  
        if (player_velocity >= velocity_max)
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
