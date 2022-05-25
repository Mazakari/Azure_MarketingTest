// Roman Baranov 25.05.2022

using UnityEngine;

public class Finish : MonoBehaviour
{
    #region TRIGGER Handlers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameplayEvents.OnLevelComplete.Invoke();
        }
    }
    #endregion
}
