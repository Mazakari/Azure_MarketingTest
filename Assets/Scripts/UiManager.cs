// Roman Baranov 25.05.2022

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    #region VARIABLES
    [Header("Level messages")]
    [SerializeField] private GameObject _levelStartMessage = null;
    [SerializeField] private GameObject _levelCompleteMessage = null;

    [Header("Game progress controls")]
    [SerializeField] private Button _nextLevelButton = null;

    [Header("Coins counter")]
    [SerializeField] private Text _coinsCounterText = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Awake()
    {
        GameplayEvents.OnLevelStart.AddListener(HideStartMessage);
        GameplayEvents.OnLevelComplete.AddListener(ShowLevelCompleteMessage);
        GameplayEvents.OnCoinCollected.AddListener(UpdateCoinCounter);
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if (!_levelStartMessage)
        {
            Debug.LogError($"{name} Level Start Message referrence is missing!");
        }

        if (!_levelCompleteMessage)
        {
            Debug.LogError($"{name} Level Start Complete referrence is missing!");
        }

        if (!_nextLevelButton)
        {
            Debug.LogError($"{name} Level Next Level Button referrence is missing!");
        }

        if (!_coinsCounterText)
        {
            Debug.LogError($"{name} Level Coins Counter Text referrence is missing!");
        }

        _levelStartMessage.SetActive(true);
        _levelCompleteMessage.SetActive(false);

        _nextLevelButton.onClick.AddListener(Restartlevel);
        _coinsCounterText.text = "0";
    }
    #endregion

    #region CALLBACK Handlers
    /// <summary>
    /// Show level start message to the player
    /// </summary>
    private void HideStartMessage()
    {
        _levelStartMessage.SetActive(false);
        GameplayEvents.OnLevelStart.RemoveListener(HideStartMessage);
        GameplayEvents.OnCoinCollected.AddListener(UpdateCoinCounter);
    }

    /// <summary>
    /// Show level complete message on finish
    /// </summary>
    private void ShowLevelCompleteMessage()
    {
        Time.timeScale = 0f;
        _levelCompleteMessage.SetActive(true);
    }

    /// <summary>
    /// Restart current level
    /// </summary>
    private void Restartlevel()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex);
    }

    /// <summary>
    /// Update coins counter text
    /// </summary>
    private void UpdateCoinCounter()
    {
        _coinsCounterText.text = LevelManager.Instance.CoinsAmount.ToString();
    }
    #endregion
}
