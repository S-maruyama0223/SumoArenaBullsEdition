using UnityEngine;
using System.Collections;
/// <summary>
/// ボタンを押したときに実際に動くクラス
/// player1,2で二つ存在する
/// </summary>
public class DistributeButtonImple : DistributeButtonManager {

    [SerializeField] private GameObject distributeArea;
    private DistributeArea distributeAreaScript;
    private bool isPlayer1;
    private TimerManager timerManager;

    protected new void Start() {
        isPlayer1 = transform.parent.name.Contains("Player1");
        distributeAreaScript = distributeArea.GetComponent<DistributeArea>();
        if (isPlayer1) {
            this.timerManager = GameObject.FindWithTag(CommonConstant.GAME_MANAGER_TAG).GetComponent<Player1TimerManager>();
        } else {
            this.timerManager = GameObject.FindWithTag(CommonConstant.GAME_MANAGER_TAG).GetComponent<Player2TimerManager>();
        }
        base.Start();
    }

    public void onClick() {
        // distributeAreaが配置可能な場合生成する
        if (distributeAreaScript.getPlaceble() && this.timerManager.Generatable) {
            generateBull(isPlayer1, distributeArea.transform.position);
            this.timerManager.generated();
        }
    }
}
