using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void onClick() {
        Debug.Log("呼び出します");
        MenuButtonManager.Instance.restart();
    }
}
