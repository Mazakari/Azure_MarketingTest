// Roman Baranov 25.05.2022

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody _rb = null;

    [SerializeField] private float _speed = 2f;

    [SerializeField] private LayerMask _movelayer;
    
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        HorMovement();

        // Forward movement
        Movement(_speed);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Move player forward with given speed
    /// </summary>
    /// <param name="speed">Move speed</param>
    private void Movement(float speed)
    {
        if (Input.GetMouseButton(0))
        {
            GameplayEvents.OnLevelStart.Invoke();
            _rb.velocity = transform.forward * speed;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rb.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Move player horizontaly
    /// </summary>
    private void HorMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float h = 0f;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, _movelayer.value))
            {
                h = raycastHit.point.x;
                Vector3 pos = new Vector3(h, transform.position.y, transform.position.z);
                transform.position = pos;
            }
        }
    }
    #endregion

}