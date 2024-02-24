using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistributeArea : MonoBehaviour {
    private int areaNum;
    private bool placeble = true;

    // Start is called before the first frame update
    void Start() {
        // char型なのでintに変換するためにchar'0'を引く
        areaNum = gameObject.name.LastOrDefault() - '0';
    }

    private void OnTriggerStay2D(Collider2D collision) {
        placeble = false;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        placeble = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        placeble = false;
    }

    public bool getPlaceble() {
        return placeble;
    }

}
