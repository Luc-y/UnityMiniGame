using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 1000f;
    private Rigidbody rb;


    private void OnEnable()
    {
        thrust.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (thrust.IsPressed()) // True 이면
        {
            rb.AddRelativeForce(Vector3.up * Time.fixedDeltaTime * thrustStrength);
        }
    }
}
