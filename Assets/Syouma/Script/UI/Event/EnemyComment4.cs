using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[5])
            FlagManager.Instance.Co_Enemy[6] = true;
    }
}
