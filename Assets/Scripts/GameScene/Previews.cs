using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Previews : MonoBehaviour {

    void Start() {

    }

    public void updatePreview(int bullSize) {
        if (bullSize == -1) {
            return;
        }

        Sprite preImage;
        if (bullSize == 1) preImage = Resources.Load<Sprite>(CommonConstant.SMALL_IMAGE);
        else if (bullSize == 2) preImage = Resources.Load<Sprite>(CommonConstant.MEDIUM_IMAGE);
        else preImage = Resources.Load<Sprite>(CommonConstant.LARGE_IMAGE);


        foreach (Image preview in gameObject.GetComponentsInChildren<Image>()) {
            preview.sprite = preImage;
        }
    }

}
