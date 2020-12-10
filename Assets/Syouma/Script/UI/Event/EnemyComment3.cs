using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[4])
            FlagManager.Instance.Co_Enemy[5] = true;
    }
}
