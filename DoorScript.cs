using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject button;
    private ButtonScript button_script;

    string doorState = "closed";
    private bool rotating = false;

    void Start()
    {
        button_script = button.GetComponent<ButtonScript>();
    }

    void Update()
    {

        if (button_script.IsButtonDown && doorState == "closed" && rotating == false)
            doorOpen();
        if (!button_script.IsButtonDown && doorState == "opened" && rotating == false)
            doorClose();
    }

    public void doorOpen()
    {
        StartCoroutine(Rotate(new Vector3(0, 120, 0), 1));
        doorState = "opened";
    }
    public void doorClose()
    {
        StartCoroutine(Rotate(new Vector3(0, -120, 0), 1));
        doorState = "closed";
    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = this.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            this.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        this.transform.rotation = endRotation;
        rotating = false;
    }
}
