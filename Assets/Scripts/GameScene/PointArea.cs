using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArea : MonoBehaviour {
    private GameManager gameManager;
    void Start() {
        gameManager = GameObject.FindWithTag(CommonConstant.GAME_MANAGER_TAG).GetComponent<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.gameObject.name.Contains("Sheep")) {
            return;
        }
        Bull bull = collision.gameObject.GetComponent<Bull>();
        updateScore((int)bull.Power);
        Destroy(collision.gameObject);
    }

    private void updateScore(int score) {
        gameManager.updatePlayerScore(score, name.Contains("Player1"));
    }
}
