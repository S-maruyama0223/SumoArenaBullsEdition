using UnityEngine;
using System.Collections;
public class DistributeButtonImple : DistributeButtonManager {

    [SerializeField] private GameObject distributeArea;
    private DistributeArea distributeAreaScript;
    private bool isPlayer1;

    protected new void Start() {
        isPlayer1 = transform.parent.name.Contains("Player1");
        distributeAreaScript = distributeArea.GetComponent<DistributeArea>();
        base.Start();
    }

    public void onClick() {
        // distributeAreaが配置可能な場合生成する
        if (distributeAreaScript.getPlaceble()) {
            generateBull(isPlayer1, distributeArea.transform.position);
        }
    }
}
