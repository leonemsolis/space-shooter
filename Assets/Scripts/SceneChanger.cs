using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToPlayScene() {
        SceneManager.LoadScene(Constants.PlaySceneBuildIndex);
    }

    public void ChangeToLevelSelectionScene() {
        SceneManager.LoadScene(Constants.LevelSelectionSceneBuildIndex);
    }
}
