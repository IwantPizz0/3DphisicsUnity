using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //[SerializeField] public int price{get; private set;}
    [SerializeField] private int price;
   [SerializeField] private LayerMask playerLayerMask;



    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, other.gameObject.layer))
        {
            if (other.TryGetComponent(out Score playerScore))
            {
                playerScore.AddScore(price);
                gameObject.SetActive(false);
            }
        }
    }
}
