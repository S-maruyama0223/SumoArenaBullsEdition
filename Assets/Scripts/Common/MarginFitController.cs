using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarginFitController : MonoBehaviour {
    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform mainContaints;
    [SerializeField] private bool top;
    [SerializeField] private bool bottom;
    [SerializeField] private bool right;
    [SerializeField] private bool left;

    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(true);
        if (top) {
            topMarginFit();
        } else if (bottom) {
            bottomMarginFit();
        } else if (right) {
            rightMarginFit();
        } else if (left) {
            leftMarginFit();

        }
    }

    private void bottomMarginFit() {
        RectTransform rc = GetComponent<RectTransform>();
        float marginSize = -canvas.rect.size.y - ((mainContaints.sizeDelta.y - canvas.rect.size.y) / 2);
        rc.sizeDelta = new Vector2(0, marginSize);
        rc.anchoredPosition = new Vector2(0, marginSize / 2);
    }

    private void topMarginFit() {
        RectTransform rc = GetComponent<RectTransform>();
        float marginSize = -canvas.rect.size.y - ((mainContaints.sizeDelta.y - canvas.rect.size.y) / 2);
        rc.sizeDelta = new Vector2(0, marginSize);
        rc.anchoredPosition = new Vector2(0, -marginSize / 2);
    }

    private void leftMarginFit() {
        RectTransform rc = GetComponent<RectTransform>();
        float marginSize = -canvas.rect.size.x - ((mainContaints.sizeDelta.x - canvas.rect.size.x) / 2);
        rc.sizeDelta = new Vector2(marginSize, 0);
        rc.anchoredPosition = new Vector2(-marginSize / 2, 0);
    }

    private void rightMarginFit() {
        RectTransform rc = GetComponent<RectTransform>();
        float marginSize = -canvas.rect.size.x - ((mainContaints.sizeDelta.x - canvas.rect.size.x) / 2);
        rc.sizeDelta = new Vector2(marginSize, 0);
        rc.anchoredPosition = new Vector2(marginSize / 2, 0);
    }

}

//ストレッチの場合
//sizeDelta = 要素サイズ - アンカーサイズ（親要素のサイズ）
//アンカーは左下が0,0
//anchoredPositionはアンカー（親要素）のpivotから子のpivot距離（ただし子のPivot位置が親pivotの位置として扱われる）
//sizeDeltaがマイナス = 親サイズより小さいという意味でしかない

//sizeDeltaを大きくする = 下方向（右方向）に伸びる
//sizeDeltaを小さくする = 上方向（左方向）に縮む