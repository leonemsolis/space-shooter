using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void ChangeToPlayScene() {
        // Play required sound
        AudioManager.PlaySelect();
        StartCoroutine(LoadScene(Constants.PlaySceneBuildIndex));
    }

    public void ChangeToLevelSelectionScene() {
        AudioManager.PlaySelect();
        StartCoroutine(LoadScene(Constants.LevelSelectionSceneBuildIndex));
    }

    public void ChangeToWinScene() {
        AudioManager.PlayWin();
        StartCoroutine(LoadScene(Constants.WinSceneBuildIndex));
    }

    public void ChangeToLoseScene() {
        AudioManager.PlayLose();
        StartCoroutine(LoadScene(Constants.LoseSceneBuildIndex));
    }

    public void ChangeToMainScene() {
        AudioManager.PlaySelect();
        StartCoroutine(LoadScene(Constants.MainSceneBuildIndex));
    }

    private IEnumerator LoadScene(int sceneIndex) {
        // Start transition, then change scene
        transition.SetTrigger(Constants.TransitionFadeOut);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(sceneIndex);
    }
}
