using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActionController : MonoBehaviour
{
    public GameObject ammo;

    private AudioSource enemyDestructionAudio;
    private ScoreManager scoreManager;
    private GameObject scoreUI;

    private void Start()
    {
        scoreUI = GameObject.FindGameObjectWithTag("ScoreUI");
        scoreManager = scoreUI.GetComponent<ScoreManager>();

        enemyDestructionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy 1")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy 2")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy 3")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(10);
            Destroy(collision.gameObject);
        }
    }
}
