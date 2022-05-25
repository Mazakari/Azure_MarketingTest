// Roman Baranov 25.05.2022

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] Transform _player = null;

    private float zOffset = 0;
    private Camera _camera = null;
    #endregion

    private void Awake()
    {
        _camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!_player)
        {
            Debug.LogError($"{name}: Player reference is not set");
            return;
        }

        zOffset = Camera.main.transform.position.z - _player.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayerZAxis();
    }

    #region PRIVATE Methods
    /// <summary>
    /// Follow player's Z axis. Y axis is camera one. X always 0.
    /// </summary>
    private void FollowPlayerZAxis()
    {
        _camera.transform.position = new Vector3(
            0,
            _camera.transform.position.y,
            _player.position.z + zOffset);
    }
    #endregion
}
