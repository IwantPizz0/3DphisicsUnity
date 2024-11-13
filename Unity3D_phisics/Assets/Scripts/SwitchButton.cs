using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private bool turnOn;
    [SerializeField] private GameObject switchableObject;
    [SerializeField] private LayerMask triggerLayerMask;

    private void Awake()
    {
        switchableObject.SetActive(!turnOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(triggerLayerMask, other.gameObject.layer))
        {
            switchableObject.SetActive(turnOn);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(triggerLayerMask, other.gameObject.layer))
        {
            switchableObject.SetActive(!turnOn);
        }
    }
}
