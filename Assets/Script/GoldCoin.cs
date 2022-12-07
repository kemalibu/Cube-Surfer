using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] private int pointsForCoinPickup = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
