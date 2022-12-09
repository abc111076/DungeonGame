using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayerUniversal
{
    [SerializeField]
    private Transform rightHand;
    [SerializeField]
    private GameObject weaponPrefab;
    [SerializeField]
    private Transform weaponSpawnPoint;
    [SerializeField]
    private GameObject swordAttackArea;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        CreatePlayer(ClassType.Knight, WeaponType.Sword, PlayerState.Idle, 1000, 10, 5);
        PlayerController pc = GetComponent<PlayerController>();
        pc.ChangePlayerStateHandler += ChangePlayerState;
        pc.FinishAttackHandler += FinishAttack;
        SetWeapon();
    }

    private void SetWeapon()
    {
        GameObject weaponGO = Instantiate(weaponPrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation, rightHand);
        weaponGO.transform.localScale = weaponSpawnPoint.localScale;
    }

    public override void DoDamage()
    {
        if (pb_WeaponType == WeaponType.Sword)
            swordAttackArea.SetActive(true);
    }

    public override void FinishAttack()
    {
        swordAttackArea.SetActive(false);
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
