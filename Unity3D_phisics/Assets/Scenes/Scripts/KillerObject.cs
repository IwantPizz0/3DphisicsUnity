using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLayerChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _triggerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_triggerLayer, other.gameObject.layer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
