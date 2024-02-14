using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : MonoBehaviour
{
  [SerializeField] public float moveSpeed = 1f; // Adjust speed as needed
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if player is found
        if (player != null)
        {
            // Calculate direction to move towards player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move enemy towards player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
