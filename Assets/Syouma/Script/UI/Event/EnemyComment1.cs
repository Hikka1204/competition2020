using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment1 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.Co_Enemy[1])
            FlagManager.Instance.Co_Enemy[2] = true;
    }

}
