using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Bull : Bull {
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = -1;
        isPlayer1 = false;
    }
}
