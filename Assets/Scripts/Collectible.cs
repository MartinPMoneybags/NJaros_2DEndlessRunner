using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int pointValue = 10;
    public void Collected()
    {
        Destroy(gameObject);
        GameManager.Instance.currentCollected++;
        GameManager.Instance.currentScore += pointValue;
        
    }
}
