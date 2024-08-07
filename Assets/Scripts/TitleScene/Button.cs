using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private TitleSceneManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag(CommonConstant.TITLE_SCENE_MANAGER_TAG).GetComponent<TitleSceneManager>();
    }

    public void onClickButton() {
        Debug.Log("ƒNƒŠƒbƒN‚µ‚Ü‚µ‚½:"+gameObject.name);
        manager.onClickButton(gameObject.name);
    }

}
