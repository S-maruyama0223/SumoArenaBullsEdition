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

//�X�g���b�`�̏ꍇ
//sizeDelta = �v�f�T�C�Y - �A���J�[�T�C�Y�i�e�v�f�̃T�C�Y�j
//�A���J�[�͍�����0,0
//anchoredPosition�̓A���J�[�i�e�v�f�j��pivot����q��pivot�����i�������q��Pivot�ʒu���epivot�̈ʒu�Ƃ��Ĉ�����j
//sizeDelta���}�C�i�X = �e�T�C�Y��菬�����Ƃ����Ӗ��ł����Ȃ�

//sizeDelta��傫������ = �������i�E�����j�ɐL�т�
//sizeDelta������������ = ������i�������j�ɏk��