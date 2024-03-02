using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeButtonManager : MonoBehaviour {

    private GameManager gameManager;
    private List<Bull> ownFormationBulls;

    protected void Start() {
        gameManager = GameObject.FindWithTag(CommonConstant.GAME_MANAGER_TAG).GetComponent<GameManager>();
    }

    protected void generateBull(bool isPlayer1, Vector2 buttonPosition) {
        GameObject bull = getBullObject(isPlayer1);
        if (bull == null) {
            return;
        }

        GameObject instance = Instantiate(bull, buttonPosition, Quaternion.identity);
        if (isPlayer1) {
            instance.AddComponent<Player1Bull>();
            (float power, float targetSpeed) properties = getBullProperties(gameManager.getPlayer1FirstBull());
            instance.GetComponent<Player1Bull>().setProperty(properties.power, properties.targetSpeed, isPlayer1);
        } else {
            instance.AddComponent<Player2Bull>();
            instance.transform.Rotate(new Vector3(0, 0, 180));
            (float power, float targetSpeed) properties = getBullProperties(gameManager.getPlayer2FirstBull());
            instance.GetComponent<Player2Bull>().setProperty(properties.power, properties.targetSpeed, isPlayer1);
        }
    }

    protected GameObject getBullObject(bool isPlayer1) {
        float size;
        if (isPlayer1) {
            size = gameManager.getPlayer1FirstBullSize();
        } else {
            size = gameManager.getPlayer2FirstBullSize();
        }
        if (size == -1) {
            return null;
        }
        GameObject bull;
        if (size == 3f) {
            bull = (GameObject)Resources.Load(CommonConstant.LARGE_SHEEP_PREFAB);
        } else if (size == 2f) {
            bull = (GameObject)Resources.Load(CommonConstant.MIDIUM_SHEEP_PREFAB);
        } else {
            bull = (GameObject)Resources.Load(CommonConstant.SMALL_SHEEP_PREFAB);
        }
        if (bull == null) {
            Debug.Log("生成されませんでした");
            return null;
        }
        return bull;
    }

    private (float power, float targetSpeed) getBullProperties(float size) {
        float targetSpeed
            = (size == 3f) ? CommonConstant.LARGE_SHEEP_SPEED
            : (size == 1f) ? CommonConstant.SMALL_SHEEP_SPEED
            : CommonConstant.MIDIUM_SHEEP_SPEED;
        return (size, targetSpeed);
    }
}