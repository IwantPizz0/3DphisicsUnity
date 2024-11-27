using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallButton : MonoBehaviour
{
    [SerializeField] private LayerMask _triggerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_triggerLayer, other.gameObject.layer))
        {
            other.isTrigger = true;
        }
    }
}
