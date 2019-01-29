using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private Animator gameOverAnimation;

    private void Start()
    {
        gameOverAnimation = GetComponent<Animator>();
    }

    public void GameOver()
    {
        gameOverAnimation.SetBool("GameOver", true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Enemies"));
        Destroy(GameObject.FindGameObjectWithTag("Ammo Parent"));
        Destroy(GameObject.FindGameObjectWithTag("PowerUps"));
        Destroy(GameObject.FindGameObjectWithTag("Bullets"));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
