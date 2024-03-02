using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Previews : MonoBehaviour {

    // TODO:後々数値決め打ちではなく、Previewの数に合わせる
    private const int previewCount = 1;

    void Start() {

    }

    public void updatePreview(int bullSize) {
        if (bullSize == -1) {
            transform.GetChild(0).GetComponent<Image>().color = new Color();
            return;
        }
        transform.GetChild(0).GetComponent<Image>().color = CommonConstant.bullColors[bullSize - 1];
    }

}
