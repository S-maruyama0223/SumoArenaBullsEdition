using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> player1Bulls;
    private List<int> player2Bulls;
    private CanvasManager canvasManager;
    private int player1Score;
    public int Player1Score {
        get { return this.player1Score; }
    }
    private int player2Score;
    public int Player2Score {
        get { return this.player2Score; }
    }

    // Start is called before the first frame update
    void Start() {
        canvasManager = GameObject.FindWithTag(CommonConstant.CANVAS_MANAGER_TAG).GetComponent<CanvasManager>();
        player1Bulls = initBullsOrder();
        player2Bulls = initBullsOrder();
        canvasManager.updatePreviews(player1Bulls[0], true);
        canvasManager.updatePreviews(player2Bulls[0], false);
    }

    private List<int> initBullsOrder() {
        //牛のストック 大4, 中6, 小10
        int[] bulls = {
            3, 3, 2, 2, 1, 1, 1,
            3, 2, 2, 1, 1, 1, 1,
            3, 2, 2, 1, 1, 1
        };
        List<int> randomList = bulls
            .OrderBy(i => System.Guid.NewGuid())
            .ToList();
        Debug.Log(string.Join(",", randomList));
        return randomList;
    }

    public int getPlayer1FirstBull() {
        int first = player1Bulls[0];
        player1Bulls.RemoveAt(0);
        canvasManager.updatePreviews(player1Bulls[0], true); // この時渡すのはfirstではない
        return first;
    }

    public int getPlayer1FirstBullSize() {
        return player1Bulls[0];
    }

    public int getPlayer2FirstBullSize() {
        return player2Bulls[0];
    }

    public int getPlayer2FirstBull() {
        int first = player2Bulls[0];
        player2Bulls.RemoveAt(0);
        canvasManager.updatePreviews(player2Bulls[0], false);// この時渡すのはfirstではない
        return first;
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
