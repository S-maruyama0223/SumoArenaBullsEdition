using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    private Previews player1Previews;
    private Previews player2Previews;
    private GameObject player1Score;
    private GameObject player2Score;

    // Start is called before the first frame update
    void Start() {
        player1Previews = GameObject.FindWithTag(CommonConstant.PLAYER1_PREVIEWS_TAG).GetComponent<Previews>();
        player2Previews = GameObject.FindWithTag(CommonConstant.PLAYER2_PREVIEWS_TAG).GetComponent<Previews>();
        player1Score = GameObject.FindWithTag(CommonConstant.PLAYER1_SCORE_TAG);
        player2Score = GameObject.FindWithTag(CommonConstant.PLAYER2_SCORE_TAG);
    }

    public void updatePreviews(int bullSize, bool isPlayer1) {
        if (isPlayer1) player1Previews.updatePreview(bullSize);
        else player2Previews.updatePreview(bullSize);
    }

    public void updateScore(int score, bool isPlayer1) {
        if (isPlayer1) {
            player1Score.GetComponent<TextMeshProUGUI>().text = $"{score}";
        } else {
            player2Score.GetComponent<TextMeshProUGUI>().text = $"{score}";
        }
    }
}
