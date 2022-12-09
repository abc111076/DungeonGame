using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    Idle,
    Wander,
    Attack,
    Dead
}

public sealed class MonsterManager : MonoBehaviour
{
    private const string TAG = "MonsterManager";

    [SerializeField]
    private GameObject monsterPrefab;
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private int maxMonsterCount;

    private List<MonsterUniversal> monsterList = new List<MonsterUniversal>();
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints.Add(transform.GetChild(i));
        }

        int spCount = spawnPoints.Count;
        List<int> randomInt = new List<int>();

        for(int i = 0; i < spCount; i++)
        {
            randomInt.Add(i);
        }

        for (int i = 0; i < maxMonsterCount; i++)
        {
            int r = Random.Range(0, randomInt.Count - 1);
            Transform point = spawnPoints[randomInt[r]];
            DebugUtility.DebugLogWithTag(TAG, "Point : " + spawnPoints[randomInt[r]].name, LogColor.aqua);
            MonsterUniversal mu = Instantiate(monsterPrefab, point.position, point.rotation).GetComponent<MonsterUniversal>();
            mu.CreateMonster(100, 10, 4);
            randomInt.RemoveAt(r);
        }
    }
}
