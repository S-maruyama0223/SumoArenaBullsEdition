using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CommonHelper {

    private static Dictionary<int, List<Bull>> bullGroupMap = new Dictionary<int, List<Bull>>();
    private static int groupSequenceId = 0;


    public static void calcSpeed(int groupId) {
        if (groupId == -1) {
            return;
        }
        List<Bull> bullGroup = bullGroupMap[groupId];
        float player1TotalPower = bullGroup.Where(b => b.IsPlayer1).Select(b => b.Power).Sum();
        float player2TotalPower = bullGroup.Where(b => !b.IsPlayer1).Select(b => b.Power).Sum();
        int superior;
        // 0なら拮抗、1ならプレイヤー１優勢、2ならプレイヤー２優勢
        if (player1TotalPower == player2TotalPower) superior = 0;
        else if (player1TotalPower > player2TotalPower) superior = 1;
        else superior = 2;

        if (superior == 0) {
            foreach (Bull bull in bullGroup) {
                bull.AdjustedSpeed = 0;
            }
        } else if (superior == 1) {
            float powerRate = player2TotalPower / player1TotalPower;
            float endBullSpeed = bullGroup.FindLast(b => b.IsPlayer1).BaseSpeed;
            // superiorが1ということはpowerRateが1より大きいので、比率を出すために1で割った数をかけて全体のスピードを出す
            // この時のスピードは相手のpowerに押し返されたpowerなので1 - powerRateをする
            // たとえば70:40の場合、押し返す力は30になる。
            float speed = endBullSpeed * (1 - powerRate);
            Debug.Log($"Player1優勢、スピードは{speed}");
            foreach (Bull bull in bullGroup) {
                bull.Direction = 1;
                bull.AdjustedSpeed = speed;
            }
        } else {
            float powerRate = player1TotalPower / player2TotalPower;
            float endBullSpeed = bullGroup.FindLast(b => !b.IsPlayer1).BaseSpeed;
            float speed = endBullSpeed * (1 - powerRate);
            Debug.Log($"Player2優勢、スピードは{speed}");
            foreach (Bull bull in bullGroup) {
                bull.Direction = -1;
                bull.AdjustedSpeed = speed;
            }
        }
    }

    /**
     * 敵と衝突した場合にグルーピングを行う
     */
    public static void grouping(Bull me) {
        validation();
        if (me.GroupId != -1) {
            // 敵側のグルーピングにより自身が既にグループ化されている場合
            // 自身の後方をグループ化する処理のみ行い処理終了。この時groupSequenceIDは自身と同じものを渡す
            if (me.BackwardFellowBull != null) {
                AddBackWardFellowGroup(me.BackwardFellowBull, bullGroupMap[me.EnemyBull.GroupId], me.GroupId);
            }
            // 速度計算して終了
            calcSpeed(me.GroupId);
            return;
        }

        // 敵にグループIDを設定
        me.EnemyBull.GroupId = groupSequenceId;

        List<Bull> trialBullList;
        if (bullGroupMap.TryGetValue(groupSequenceId, out trialBullList)) {
            // 既に現在のシーケンスIDがグルーピング済みの場合
            trialBullList.Add(me.EnemyBull);
            AddBackWardFellowGroup(me, trialBullList, groupSequenceId);
        } else {
            // 現在のIDが新規のグルーピングIDだった場合は現在のIDをキーにしたグループを作成する
            trialBullList = new List<Bull> { me.EnemyBull };
            bullGroupMap.Add(groupSequenceId, trialBullList);
            AddBackWardFellowGroup(me, trialBullList, groupSequenceId);
        }

        groupSequenceId++;

        /******* ↓↓↓↓↓ローカル関数↓↓↓↓↓ ********/
        void validation() {
            if (me.EnemyBull == null) {
                Debug.Log("敵と衝突していません");
                throw new SystemException();
            }
        }
        /******* ↑↑↑↑↑ローカル関数↑↑↑↑↑ ********/
    }

    private static void AddBackWardFellowGroup(Bull bull, List<Bull> bullList, int groupId) {
        Bull me = bull;
        do {

            bullList.Add(me);
            me.GroupId = groupId;
            // 後方の仲間を更新。いなければループ処理が止まる
            me = me.BackwardFellowBull;
        } while (me != null);
    }

    public static void addFellowGroup(Bull me, Bull forwardFellowBull) {
        if (forwardFellowBull == null) {
            Debug.Log("仲間が存在しません。");
            throw new SystemException();
        }
        if (forwardFellowBull.GroupId != -1) {
            // 前方の仲間が既にグループ化されていれば、仲間のグループに自身を追加する
            bullGroupMap[forwardFellowBull.GroupId].Add(me);
            me.GroupId = forwardFellowBull.GroupId;
        }
        // 前方の仲間がグループ化されていない場合は敵と衝突していないので、何もしない。

        // TODO: スピードとパワーの再計算を行う
    }

}
