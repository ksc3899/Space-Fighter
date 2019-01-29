using UnityEngine;
using System.Collections;

public class EscapeMenuController : MonoBehaviour
{
    private Animator escapeMenuAnimation;
    private bool isPaused = false;

    private void Start()
    {
        escapeMenuAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                StartCoroutine(PauseGame());
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        escapeMenuAnimation.SetBool("IsPaused", isPaused);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator PauseGame()
    {
        isPaused = true;
        escapeMenuAnimation.SetBool("IsPaused", isPaused);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
}
