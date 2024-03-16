using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1TimerManager : TimerManager
{
    // Start is called before the first frame update
    new void Start() {
        isPlayer1 = true;
        base.Start();
    }
}
