using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArea : MonoBehaviour {

    [SerializeField] bool isPlayer1;

    private GameManager gameManager;
    void Start() {
        gameManager = GameObject.FindWithTag(CommonConstant.GAME_MANAGER_TAG).GetComponent<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.gameObject.name.Contains("Animal")) {
            return;
        }
        Bull bull = collision.gameObject.GetComponent<Bull>();
        if (bull.IsPlayer1 == isPlayer1) {
            return;
        }
        updateScore((int)bull.Power);
        Destroy(collision.gameObject);
    }

    private void updateScore(int score) {
        gameManager.updatePlayerScore(score, name.Contains("Player1"));
    }
}
