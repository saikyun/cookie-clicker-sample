using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("enabling menu");
        GameState.instance.hud = GetComponent<UIDocument>().rootVisualElement;
    }
}
