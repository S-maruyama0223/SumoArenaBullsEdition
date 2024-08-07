using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    public void openMenu() {
        MenuButtonManager.Instance.openMenu();
    }
}
