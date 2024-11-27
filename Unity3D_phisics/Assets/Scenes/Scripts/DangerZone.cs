using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private bool isOneshot;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject killerPrefab;
    [SerializeField] private Transform killerSpawnPoint;
    [SerializeField] private int maxShotCount;
    private int _shotCound = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(LayerMaskUtil.ContainsLayer(playerMask, other.gameObject.layer))
        {
            if (isOneshot && _shotCound < maxShotCount || !isOneshot)
            {
            Instantiate(killerPrefab, killerSpawnPoint);
            _shotCound ++;
            }
        }
    }
}
