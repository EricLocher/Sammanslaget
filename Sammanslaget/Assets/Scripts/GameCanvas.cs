using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    private static GameCanvas _instance;
    public static GameCanvas Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    public static Canvas GetCanvas()
    {
        return Instance.GetComponent<Canvas>();
    }



}
