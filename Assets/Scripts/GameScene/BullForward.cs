using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullForward : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.name.Contains("Animal")) {
            return;
        }

        Bull forwardBull = collision.gameObject.GetComponent<Bull>();
        Bull me = transform.parent.gameObject.GetComponent<Bull>();

        me.collided(forwardBull);
    }
}
