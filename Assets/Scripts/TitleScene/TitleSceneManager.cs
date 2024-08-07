using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {

    [SerializeField] Fade fade;
    [SerializeField] GameObject info;

    // Start is called before the first frame update
    void Start() {

    }

    public void onClickButton(string buttonName) {
        if (buttonName.Contains("StartButton"))
            onClickStartButton();
        if (buttonName.Equals("TutrialButton"))
            onClickTutrialButton();
        if (buttonName.Equals("InfoButton"))
            onClickInfoButton();
        if (buttonName.Equals("InfoArea"))
            onClickInfoArea();
    }

    private void onClickStartButton() {
        GameManager.fadeTime = 1f;
        fade.FadeIn(GameManager.fadeTime, () => SceneManager.LoadScene("GameScene"));
    }

    private void onClickTutrialButton() {
        Debug.Log("Tutrial");
    }

    private void onClickInfoButton() {
        info.SetActive(true);
    }
    private void onClickInfoArea() {
        Debug.Log("onClickInfoArea");
        info.SetActive(false);
    }

}
