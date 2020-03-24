using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
        if (!scoreText)
        {
            Debug.LogError("Missing TMPro text");
            return;
        }
        LevelManager.OnScoreUpdated += HandleScoreUpdated;


    }

    private void HandleScoreUpdated(int ammount)
    {
        scoreText.text = "Score: " + ammount;
    }
}
