using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField]
    private PlayerUniversal playerUniversal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            string s_index = other.name.Substring(8);

            if(int.TryParse(s_index, out int number))
            {
                MonsterManager.Instance.DamageCalculate(number, playerUniversal.ROAttack);
            }
            else
            {
                DebugUtility.DebugLogWithTag("DamageArea", "not a int");
            }
        }
    }
}
