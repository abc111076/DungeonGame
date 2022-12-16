using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSUtility : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        var labelstyle = new GUIStyle();
        labelstyle.fontSize = 32;
        labelstyle.normal.textColor = Color.white;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{1:0.} fps", msec, fps);
        GUIContent[] contents = new GUIContent[]
        {
            new GUIContent(text),
        };

        GUI.Label(new Rect(350, 0, 180, 80), contents[0], labelstyle);
        
    }
}
