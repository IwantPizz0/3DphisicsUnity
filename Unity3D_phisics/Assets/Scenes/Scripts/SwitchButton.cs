using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private bool _turtOn;
    [SerializeField] private GameObject _switcheableObject;
    [SerializeField] private LayerMask _triggerLayer;

    private void Awake()
    {
        _switcheableObject.SetActive(!_turtOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_triggerLayer, other.gameObject.layer))
        {
            _switcheableObject.SetActive(_turtOn);
        }
    }    private void OnTriggerExit(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_triggerLayer, other.gameObject.layer))
        {
            _switcheableObject.SetActive(!_turtOn);
        }
    }

}
