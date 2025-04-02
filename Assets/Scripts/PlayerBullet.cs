using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float moveSpeed;

    public float killLimit = 40f;

    public PlayerShooting player;

    private Rigidbody2D rb; 



    // Initialize RigidBody2D
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.y >= killLimit)
        {

            Destroy(this.gameObject);
        }
    }

    public void PlayerSet(PlayerShooting playerShoot)
    {
        player = playerShoot;
    }
}
