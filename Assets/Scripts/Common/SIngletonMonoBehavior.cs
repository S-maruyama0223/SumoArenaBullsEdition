using System.Collections;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;
    public static T Instance {
        get {
            if (instance == null) {
                var t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if (instance == null) {
                }
            }

            return instance;
        }
    }

    virtual protected void Awake() {
        CheckInstance();
    }

    protected bool CheckInstance() {
        if (instance == null) {
            instance = this as T;
            return true;
        } else if (Instance == this) {
            return true;
        }
        Destroy(this);
        return false;
    }
}
