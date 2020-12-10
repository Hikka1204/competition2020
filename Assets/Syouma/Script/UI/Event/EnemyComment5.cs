using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[6])
            FlagManager.Instance.Co_Enemy[7] = true;
    }
}
