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
        // Update text after getting target
        UpdateText();
    }

    private void OnDestroyAsteroid() {
        // Update score and text
        score++;
        UpdateText();

        // If player destroyed required amount of asteroids, send complete level signal to game controller
        if(score == target) {
            FindObjectOfType<GameController>().LevelCompleted();
        }
    }

    // Update text if values changed
    private void UpdateText() {
        scoreText.SetText(score.ToString() + "/" + target.ToString());
    }

    // Subscribe OnDestroyAsteroid function to event on enable
    private void OnEnable() {
        DestroyByContact.OnDestroy += OnDestroyAsteroid;
    }    
    // Desubscribe OnDestroyAsteroid function to event on enable
    private void OnDisable() {
        DestroyByContact.OnDestroy -= OnDestroyAsteroid;
    }
}
