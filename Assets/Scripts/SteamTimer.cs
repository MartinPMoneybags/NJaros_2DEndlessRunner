using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTimer : MonoBehaviour
{
    public ParticleSystem steamEmitter; // Reference to the Particle Systrem (steam emitter)
    public BoxCollider2D steamCollider; // Reference to the Boxcollider2D
    public float minInterval = 1f; // Minimum time between steam bursts
    public float maxInterval = 3f; // Maximum time between steam bursts
    private float interval;
    private float timer;


    void Start()
    {
        // Optionally, ensure the steam and collider are Inintally inactive
        steamEmitter.Stop();
        steamCollider.enabled = false;

        // Start the first random burst
        //StartCoroutine(SteamBurst());
    }

    void ChooseInterval()
    {
        interval = Random.Range(minInterval, maxInterval);
    }

    void Update()
    {
        // You can control anything you wan to happen between steam bursts here
        timer += Time.deltaTime;

       if(timer >= interval)
        {
            ChooseInterval();
            timer = 0;
            if (steamEmitter.isPlaying)
            {
                steamEmitter.Stop();
            }
            else
            {
                steamEmitter.Play();
            }
        }

    }

    private System.Collections.IEnumerator SteamBurst()
    {
        while (true)
        {
            // Wait for a random time between minInterval and maxInterval
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // Enable the particle system (steam emitter)
            steamEmitter.Play();

            // Enable the collider to trigger collisions
            steamCollider.enabled = true;

            gameObject.tag = "Obstacle";

            // Optional: Disable the collider after a short duration (if you want it to be active only briefly)
            // This will depend on how long you want the collider to stay active
            //yield return new WaitForSeconds(if);

            // Disable the collider
            steamCollider.enabled = false;

            // Optionally stop the particle emitter after the burst ends
            steamEmitter.Stop();
        }
    }
}
