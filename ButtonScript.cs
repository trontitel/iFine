using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] float force;
    Rigidbody rb;
    [SerializeField] Transform ButtonUpPosition;
    [SerializeField] Transform ButtonDownPosition;

    public bool IsButtonDown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.transform.position.y >= ButtonUpPosition.position.y)
            this.transform.position = new Vector3(ButtonUpPosition.position.x, ButtonUpPosition.position.y, ButtonUpPosition.position.z);
        else
            ButtonUp();

        if (this.transform.position.y <= ButtonDownPosition.position.y)
        {
            this.transform.position = new Vector3(ButtonDownPosition.position.x, ButtonDownPosition.position.y, ButtonDownPosition.position.z);
        }

        if (this.transform.position.y <= ButtonDownPosition.position.y + 0.1)
        {
            IsButtonDown = true;
        }
        else
            IsButtonDown = false;

    }

    private void ButtonUp()
    {
        rb.AddForce(ButtonUpPosition.transform.up * force);
    }

}
