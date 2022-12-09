using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType
{
    Knight = 0,
}

public enum WeaponType
{
    Sword = 0,
}

public enum PlayerState
{
    Idle = 0,
    Walk,
    Attack,
    Dead
}

public sealed class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    public GameObject PlayerGameObject { get { return playerGameObject; } }
    public PlayerState CurrentPlayerState { get { return currentPlayerState; } }

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
