using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] AudioSource lifeCollectionSound;
    
    public static int livesLost;
    public static int lives;
    bool dead = false;

    private void Start()
    {
        loadLives();
        livesText.text = "Lives: " + lives.ToString();
    }

    private void Update()
    {
        if (transform.position.y < -.5f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Life"))
        {
            Destroy(collision.gameObject);
            gainLife();
            lifeCollectionSound.Play();
        }
    }

    void Die()
    { 
        dead = true;
        deathSound.Play();
        loseLife();
        Invoke(nameof(ReloadLevel), .5f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loseLife()
    {
        livesLost++;
        loadLives();
    }

    public void gainLife()
    {
        livesLost--;
        loadLives();
    }

    public void loadLives()
    {
        lives = 3 - livesLost;
    }
}