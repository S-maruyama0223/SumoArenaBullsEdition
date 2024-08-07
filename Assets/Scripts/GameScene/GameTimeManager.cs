using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeManager : MonoBehaviour {
    private float finishTime = 20f;
    private int countDownNum = 5;

    private bool isStartCountDown = false;

    [SerializeField] TextMeshProUGUI countDownText;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isStartCountDown) {
            finishTime -= Time.deltaTime;
        }
        if (isStartCountDown && finishTime <= 6f) {
            countDownText.gameObject.SetActive(true);
            isStartCountDown = false; // 2‰ñˆÈãŒÄ‚Î‚ê‚È‚¢‚æ‚¤‚É
            StartCoroutine("countDown");

        }
    }

    public void startCountDown() {
        isStartCountDown = true;
    }

    private IEnumerator countDown() {
        countDownText.text = $"{countDownNum}";
        countDownNum--;
        yield return new WaitForSeconds(1f);
        if (countDownNum == 0) {
            countDownText.text = "GameSet";
        } else {
            StartCoroutine("countDown");
        }
    }
}
