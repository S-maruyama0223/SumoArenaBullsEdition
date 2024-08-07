using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : SingletonMonoBehaviour<MenuButtonManager> {
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject menuButtonArea;
    [SerializeField] private Fade fade;
    private bool isStopped = false;
    public bool IsStopped {
        get {
            return this.isStopped;
        }
    }

    // Use this for initialization
    void Start() {
    }

    public void openMenu() {
        if (isStopped) {
            return;
        }
        this.isStopped = !this.isStopped;
        this.pauseMenu.SetActive(true);
        this.menuButtonArea.SetActive(false);
        Time.timeScale = 0f;
    }

    public void restart() {
        if (!isStopped) {
            return;
        }
        this.isStopped = !this.isStopped;
        this.pauseMenu.SetActive(false);
        this.menuButtonArea.SetActive(true);
        Time.timeScale = 1f;
    }

    public void reset() {
        // TODO:確認ダイアログを入れる
        Time.timeScale = 1f;
        GameManager.fadeTime = 0.3f;
        fade.FadeIn(GameManager.fadeTime, () => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
}
