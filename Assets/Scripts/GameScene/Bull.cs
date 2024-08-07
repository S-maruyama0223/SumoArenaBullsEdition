using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bull : MonoBehaviour {

    /** 
     * 衝突している羊たちに割り当てられるID。スピードの同期に使う
     * */
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
    /**
     * 方向 Player2なら-1で下向きとなる
     */
    protected sbyte direction;
    public sbyte Direction {
        set {
            this.direction = value;
        }
    }
    protected Rigidbody2D rb;

    /**
     * 後方にいる仲間
     * */
    private Bull backwardFellowBull;
    public Bull BackwardFellowBull {
        get {
            return this.backwardFellowBull;
        }
    }
    /** 前方にいる敵
     * */
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

    /**
     * 基本スピード
     * サイズ決定時に割り当てられる
     */
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

    /**
     * 耐久時間（秒）
     * 超えるとpower調整が入る
     */
    private float lifeTime;
    /**
     * 耐久時間を超えたか
     */
    private bool isLifeTimeUp = false;

    void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + (adjustedSpeed * direction));
        if (groupId != -1 && !isLifeTimeUp && lifeTime > 0) {
            // グループ化してから耐久時間が減る
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0) {
                isLifeTimeUp = true;
            }
        }
        if (isLifeTimeUp && lifeTime <= 0) {
            Debug.Log("耐久時間が過ぎました");
            this.power /= 2;
            // 耐久時間が過ぎたら再計算を行う
            CommonHelper.calcSpeed(this.groupId);

            // falseに戻してこのブロックが再度呼び出されないようにする
            isLifeTimeUp = false;
        }
    }

    public void setProperty(float power, float targetSpeed, bool isPlayer1) {
        this.isPlayer1 = isPlayer1;
        this.power = power;
        this.lifeTime = power * CommonConstant.LIFE_TIME_PARAM + CommonConstant.BASE_LIFE_TIME; // 固定値 + power x 変数 
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

//// TODO
/**メモ
 * 
 * マネージャークラスのシングルトン化
 * 耐久時間が残り少なくなったらひつじの色を変えるとかしたい
 *
 *ゲーム終了条件 全羊がなくなってから30秒
 * パワーアップアイテム
 * 音楽の追加、BGM、効果音
 * ライセンス表示 fade, 魔王魂（多分）
 * 余白の絵
 * 生成エリア全体で薄い次の動物表示、生成エリア自体もゲージ化する
 * 
 * 音楽メモ
 * ゲームBGM
 * https://conte-de-fees.com/bgm/2878.html
 * https://maou.audio/bgm_8bit29/
 * 
 *  
 */