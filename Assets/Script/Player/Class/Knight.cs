using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayerUniversal
{
    [SerializeField]
    private PlayerState ps;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(ClassType.Knight, PlayerState.Idle, 1000, 10, 5);
        GetComponent<PlayerController>().ChangePlayerStateHandler += ChangePlayerState;
        ps = PlayerState.Idle;
    }

    private void Update()
    {
        if(ps != pb_PlayerState)
            ps = pb_PlayerState;
    }

    private void OnGUI()
    {
        var labelstyle = new GUIStyle();
        labelstyle.fontSize = 32;
        labelstyle.normal.textColor = Color.white;
        int height = 40;
        GUIContent[] contents = new GUIContent[]
        {
               new GUIContent($"Class:{pb_Attack}"),
               new GUIContent($"State:{pb_PlayerState }"),
               new GUIContent($"Hp:{pb_HealthPoints}"),
               new GUIContent($"Atk:{pb_Attack}"),
               new GUIContent($"Speed:{pb_Speed}"),
         };

        for (int i = 0; i < contents.Length; i++)
        {
            GUI.Label(new Rect(0, height * i, 180, 80), contents[i], labelstyle);
        }
    }
}
