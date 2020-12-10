using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment6 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[7])
            FlagManager.Instance.Co_Enemy[8] = true;
    }
}
