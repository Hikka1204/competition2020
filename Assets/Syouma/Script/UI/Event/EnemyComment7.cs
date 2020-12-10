using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment7 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[8])
            FlagManager.Instance.Co_Enemy[9] = true;
    }
}
