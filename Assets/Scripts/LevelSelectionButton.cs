using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    // Predefined level index for this button
    [SerializeField] int level;
    private bool locked = false;

    private void Start() {
        // Unlock first level if it locked
        if(PlayerPrefs.GetInt(Constants.LevelSelectionPrefix+"1", 0) == 0) {
            PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+"1", 1);
            PlayerPrefs.Save();
        }

        // Get current level state
        switch(PlayerPrefs.GetInt(Constants.LevelSelectionPrefix+level.ToString(), 0)) {
            case 0: // Locked
                locked = true;
                // Dim color
                GetComponent<Image>().color = Color.gray;
                // Add "locked" string to the title
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Constants.LevelSelectionPrefix+" "+level.ToString() + "\n"+"locked");
                break;
            case 1: // Opened
                break;
            case 2: // Completed
                // Make color green
                GetComponent<Image>().color = Color.green;
                // Add "done" string to the title
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Constants.LevelSelectionPrefix+" "+level.ToString() + "\n"+"done");
                break;
        }
    }

    public void OnClick() {
        if(!locked) {
            // Pass selected level index to GameScene using PlayerPrefs
            PlayerPrefs.SetInt(Constants.CurrentlySelectedLevel, level);
            PlayerPrefs.Save();
            // Goto GameScene
            FindObjectOfType<SceneChanger>().ChangeToPlayScene();
        }
    }
}
