using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0;
    [SerializeField] float yAngle = 1;
    [SerializeField] float zAngle = 0;

    void Start()
    {
        
    }

    void Update()
    {
        mySpinner();
        
    }

    void mySpinner()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
