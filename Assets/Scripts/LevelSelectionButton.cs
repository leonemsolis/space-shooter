using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] int level;
    private bool locked = false;

    private void Start() {
        if(PlayerPrefs.GetInt(Constants.LevelSelectionPrefix+"1", 0) == 0) {
            PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+"1", 1);
            PlayerPrefs.Save();
        }
        switch(PlayerPrefs.GetInt(Constants.LevelSelectionPrefix+level.ToString(), 0)) {
            case 0: // Locked
                locked = true;
                GetComponent<Image>().color = Color.gray;
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Constants.LevelSelectionPrefix+" "+level.ToString() + "\n"+"locked");
                break;
            case 1: // Opened
                break;
            case 2: // Completed
                GetComponent<Image>().color = Color.green;
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Constants.LevelSelectionPrefix+" "+level.ToString() + "\n"+"done");
                break;
        }
    }

    public void OnClick() {
        if(!locked) {
            PlayerPrefs.SetInt(Constants.CurrentlySelectedLevel, level);
            PlayerPrefs.Save();
            GetComponent<SceneChanger>().ChangeToPlayScene();
        }
    }
}
