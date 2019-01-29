using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]public int score = 0;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayScoreText(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
}
