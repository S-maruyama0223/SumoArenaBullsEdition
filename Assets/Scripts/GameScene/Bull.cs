using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bull : MonoBehaviour {

    /** 衝突している羊たちに割り当てられるID。スピードの同期に使う */
    private int groupId = -1;
    public int GroupId {
        get {
            return this.groupId;
        }
        set {
            if (this.groupId == -1) {
                // groupIdの再設定を禁止
                this.groupId = value;
            }
        }
    }
    protected bool isPlayer1;
    public bool IsPlayer1 {
        get {
            return this.isPlayer1;
        }
    }
    /* 方向 Player2なら-1で下向きとなる*/
    protected sbyte direction;
    public sbyte Direction {
        set {
            this.direction = value;
        }
    }
    protected Rigidbody2D rb;

    /* 後方にいる仲間 */
    private Bull backwardFellowBull;
    public Bull BackwardFellowBull {
        get {
            return this.backwardFellowBull;
        }
    }
    /* 前方にいる敵 */
    private Bull enemyBull;
    public Bull EnemyBull {
        get {
            return this.enemyBull;
        }
    }

    /**
     * 敵や味方と接している時に調整されるスピード
     * 敵と衝突した場合に使用する
     */
    private float adjustedSpeed;
    public float AdjustedSpeed {
        set {
            this.adjustedSpeed = value;
        }
        get {
            return this.adjustedSpeed;
        }
    }

    private float baseSpeed = -1;
    public float BaseSpeed {
        get {
            return this.baseSpeed;
        }
    }

    /**
     * 仲間に追突した場合に考慮される力 
     */
    private float power;
    public float Power {
        set {
            this.power = value;
        }
        get {
            return this.power;
        }
    }

    void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + (adjustedSpeed * direction));
    }

    public void setProperty(float power, float targetSpeed, bool isPlayer1) {
        this.isPlayer1 = isPlayer1;
        this.power = power;
        this.adjustedSpeed = targetSpeed;
        this.baseSpeed = targetSpeed;
    }

    /// <summary>
    /// 衝突した時の処理を行う
    /// </summary>
    /// <param name="forwardBull"></param>
    public void collided(Bull forwardBull) {
        if (forwardBull.IsPlayer1 == isPlayer1) {
            // 衝突したのが仲間だったら、仲間の「後方の仲間」に自身を設定する
            forwardBull.backwardFellowBull = this;
            // 自身のスピードは前方の仲間のスピードに合わせる
            this.adjustedSpeed = forwardBull.BaseSpeed;
            CommonHelper.addFellowGroup(this, forwardBull);
            CommonHelper.calcSpeed(this.groupId);
        } else {
            this.enemyBull = forwardBull;
            // グループ化処理
            CommonHelper.grouping(this);
        }
    }

}

/**メモ
 * 
 * TODO:
 * 制限時間
 * オブジェクトサイズの適正化
 * 生成間隔
 * 拮抗した場合どうする？→エリアで制御ではなく秒数で制御にすれば解決？１レーンにおける最大の数も決めるか
 * 
 */