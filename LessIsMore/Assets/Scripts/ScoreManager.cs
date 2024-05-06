using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public GameObject player;
    private float timer = 0f;
    private float interval = 1f; // Interval in seconds

    void Update()
    {
        // Accumulate time
        timer += Time.deltaTime;

        // Check if one second has passed
        if (timer >= interval)
        {
            // Call your function here
            if (player.transform.localScale.x <= 1 && player.transform.localScale.y <= 1)
            {
                UpdateScore(1);
            }

            // Reset the timer
            timer = 0f;
        }
    }


    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
}
