// Roman Baranov 22.05.2022

using UnityEngine.Events;

public class GameplayEvents
{
    #region CALLBACKS
    /// <summary>
    /// Called on level start event
    /// </summary>
    public static readonly UnityEvent OnLevelStart = new UnityEvent();

    /// <summary>
    /// Called on level complete event
    /// </summary>
    public static readonly UnityEvent OnLevelComplete = new UnityEvent();

    /// <summary>
    /// Called on coin collected event
    /// </summary>
    public static readonly UnityEvent OnCoinCollected = new UnityEvent();
    #endregion

}
