using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            GameManager.Instance.isPlaying = false;
            GameManager.Instance.PauseObstacles();
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }

        if(collision.GetComponent<Collectible>() == true)
        {
            collision.GetComponent<Collectible>().Collected();
        }
    }
}
