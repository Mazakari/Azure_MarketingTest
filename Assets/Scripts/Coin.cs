// Roman Baranov 25.05.2022

using UnityEngine;

public class Coin : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _coinModel = null;
    [SerializeField] private ParticleSystem _pickupEffect = null;
    #endregion

    #region COLLISION Handlers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameplayEvents.OnCoinCollected.Invoke();

            _coinModel.SetActive(false);
            _pickupEffect.Play();
        }
    }
    #endregion
}
