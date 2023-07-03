using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    int coins = 0;
    
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] AudioSource coinCollectionSound;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            coinCollectionSound.Play();
        } 
    }
    
}
