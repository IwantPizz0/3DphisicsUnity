using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private LayerMask _triggerLayer;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private GameObject switcheableObject;
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_triggerLayer, other.gameObject.layer))
        {
            other.transform.position = _endPoint.position;
            switcheableObject?.SetActive(true);
        }
    }
}
