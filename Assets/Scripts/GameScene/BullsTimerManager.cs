using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class BullsTimerManager : MonoBehaviour {
    [SerializeField] protected GameObject timer;
    protected Image timerGauge;
    protected bool isPlayer1;
    protected float unGeneratableTime = 2.5f;
    protected float remainingTime;
    protected bool generatable = true;
    public bool Generatable {
        get {
            return this.generatable;
        }
    }
    // Start is called before the first frame update
    protected void Start() {
        timerGauge = timer.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!generatable) {
            remainingTime -= Time.deltaTime;
            timerGauge.fillAmount = remainingTime / unGeneratableTime;
        }
        if (remainingTime <= 0) {
            remainingTime = unGeneratableTime;
            generatable = true;
        }
    }

    /// <summary>
    /// ��莞�Ԑ����s��Ԃɂ���
    /// </summary>
    public void generated() {
        this.generatable = false;
    }


}
