using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
