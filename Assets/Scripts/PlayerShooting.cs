using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform bulletSpawn;

    public float shootCountdown;// This is the timer that counts up.
    private float shootTime;// This is the predetermined time when the enemy shoots a bullet.

    [SerializeField] private float shootTimeMin = 5f;
    [SerializeField] private float shootTimeMax = 15f;


    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(shootTimeMin, shootTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        ShootLoop();
    }

    void ShootLoop()
    {
        shootCountdown += Time.deltaTime;
        if (shootCountdown >= shootTime)
        {
            Instantiate(playerBullet, bulletSpawn.position, Quaternion.identity);
            shootCountdown = 0;
            shootTime = Random.Range(shootTimeMin, shootTimeMax);
        }
    }
}
