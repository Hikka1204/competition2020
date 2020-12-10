using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComment2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(FlagManager.Instance.Co_Enemy[3])
        FlagManager.Instance.Co_Enemy[4] = true;
    }
}
