using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType
{
    Knight = 0,
}

public enum PlayerState
{
    Idle = 0,
    SlowRun,
    Attack,
}

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    public GameObject PlayerGameObject { get { return playerGameObject; } }

    [SerializeField]
    private Transform playerSpawnPoint;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private PlayerState currentPlayerState;

    private GameObject playerGameObject;

    private void Awake()
    {
        DontDestroyOnLoad(this);    
    }

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    public void SetPlayerStateToManager(PlayerState state)
    {
        if(currentPlayerState != state)
            currentPlayerState = state;
    }
}
