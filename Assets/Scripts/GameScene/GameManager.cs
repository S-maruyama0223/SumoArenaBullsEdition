using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float fadeTime = 1f;
    private List<int> player1Bulls;
    private List<int> player2Bulls;
    private CanvasManager canvasManager;
    private GameTimeManager gameTimeManager;
    [SerializeField] Fade fade;

    private int player1Score;
    public int Player1Score {
        get {
            return this.player1Score;
        }
    }
    private int player2Score;
    public int Player2Score {
        get {
            return this.player2Score;
        }
    }

    private bool isEmptyPlayer1Bulls;
    private bool isEmptyPlayer2Bulls;

    // Start is called before the first frame update
    void Start() {
        fadeOut();
        canvasManager = GameObject.FindWithTag(CommonConstant.CANVAS_MANAGER_TAG).GetComponent<CanvasManager>();
        gameTimeManager = gameObject.GetComponent<GameTimeManager>();
        player1Bulls = initBullsOrder();
        player2Bulls = initBullsOrder();
        canvasManager.updatePreviews(player1Bulls[0], true);
        canvasManager.updatePreviews(player2Bulls[0], false);
    }

    public void fadeOut() {
        fade.FadeOut(fadeTime);
    }

    private List<int> initBullsOrder() {
        //牛のストック 大4, 中6, 小10
        int[] bulls = {
            3, 3, 2, 2, 1, 1, 1,
            3, 2, 2, 1, 1, 1, 1,
            3, 2, 2, 1, 1, 1
        };
        //int[] bulls = {
        //    1, 2, 3
        //};
        List<int> randomList = bulls
            .OrderBy(i => System.Guid.NewGuid())
            .ToList();
        Debug.Log(string.Join(",", randomList));
        return randomList;
    }

    public int getPlayer1FirstBull() {
        int first = player1Bulls[0];
        removeFirstBull(player1Bulls);
        if (player1Bulls.Count != 0) {
            canvasManager.updatePreviews(player1Bulls[0], true); // この時渡すのはfirstではない
        } else {
            canvasManager.updatePreviews(-1, true); // この時渡すのはfirstではない
        }
        return first;
    }

    public int getPlayer1FirstBullSize() {
        if (player1Bulls.Count == 0) {
            return -1;
        }
        return player1Bulls[0];
    }

    public int getPlayer2FirstBullSize() {
        if (player2Bulls.Count == 0) {
            return -1;
        }
        return player2Bulls[0];
    }

    public int getPlayer2FirstBull() {
        int first = player2Bulls[0];
        removeFirstBull(player2Bulls);
        if (player2Bulls.Count != 0) {
            canvasManager.updatePreviews(player2Bulls[0], false);// この時渡すのはfirstではない
        } else {
            canvasManager.updatePreviews(-1, false); // この時渡すのはfirstではない
        }
        return first;
    }

    private void removeFirstBull(List<int> bulls) {
        bulls.RemoveAt(0);
        if (player1Bulls.Count == 0) isEmptyPlayer1Bulls = true;
        if (player2Bulls.Count == 0) isEmptyPlayer2Bulls = true;

        if (isEmptyPlayer1Bulls && isEmptyPlayer2Bulls) {
            gameTimeManager.startCountDown();
        }
    }

    public void updatePlayerScore(int score, bool isPlayer1) {
        if (isPlayer1) {
            player1Score += score;
            canvasManager.updateScore(Player1Score, true);
        } else {
            player2Score += score;
            canvasManager.updateScore(Player2Score, false);
        }
    }

}
