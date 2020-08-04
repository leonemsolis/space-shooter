using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private GameController gameController;

    private int score = 0;
    private int target;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        scoreText = GetComponent<TextMeshProUGUI>();
        target = gameController.GetTarget();
        UpdateText();
    }

    private void OnDestroyAsteroid() {
        score++;
        UpdateText();

        if(score == target) {
            FindObjectOfType<GameController>().LevelCompleted();
        }
    }

    private void UpdateText() {
        scoreText.SetText(score.ToString() + "/" + target.ToString());
    }

    private void OnEnable() {
        DestroyByContact.OnDestroy += OnDestroyAsteroid;
    }    

    private void OnDisable() {
        DestroyByContact.OnDestroy -= OnDestroyAsteroid;
    }
}
