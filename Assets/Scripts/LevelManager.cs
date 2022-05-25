// Roman Baranov 25.05.2022

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region VARIABLES
    public static LevelManager Instance = null;

    /// <summary>
    /// Current player coins amount
    /// </summary>
    public int CoinsAmount { get; private set; } = 0;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
        {
            Instance = null;
        }

        Instance = this;
    }

    private void Start()
    {
        GameplayEvents.OnCoinCollected.AddListener(PickupCoin);
    }
    #endregion

    #region CALLBACKS Handlers
    /// <summary>
    /// Increase players coins amount
    /// </summary>
    private void PickupCoin()
    {
        CoinsAmount++;
    }
    #endregion
}
