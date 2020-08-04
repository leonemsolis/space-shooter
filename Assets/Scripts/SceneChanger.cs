using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Animator transition;
    public void ChangeToPlayScene() {
        StartCoroutine(LoadScene(Constants.PlaySceneBuildIndex));
    }

    public void ChangeToLevelSelectionScene() {
        StartCoroutine(LoadScene(Constants.LevelSelectionSceneBuildIndex));
    }

    public void ChangeToWinScene() {
        StartCoroutine(LoadScene(Constants.WinSceneBuildIndex));
    }

    public void ChangeToLoseScene() {
        StartCoroutine(LoadScene(Constants.LoseSceneBuildIndex));
    }

    public void ChangeToMainScene() {
        StartCoroutine(LoadScene(Constants.MainSceneBuildIndex));
    }

    private IEnumerator LoadScene(int sceneIndex) {
        transition.SetTrigger(Constants.TransitionFadeOut);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(sceneIndex);
    }
}
