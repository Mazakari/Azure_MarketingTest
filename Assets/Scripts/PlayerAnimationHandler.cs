// Roman Baranov 25.05.2022

using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimationHandler : MonoBehaviour
{
    #region VARIABLES
    private Animator _animator = null;
    private Rigidbody _rb = null;
    #endregion

    #region UNTIY Methods
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _rb.velocity.magnitude);
    }
    #endregion
}
