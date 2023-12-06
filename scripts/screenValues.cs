using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class screenValues : MonoBehaviour
{
    public TextMeshProUGUI screenText;
    public float smoothing = 0.1f;
    public GameObject rotator;
    float speed = 5f;

    void Start()
    {
        smoothing = 0.5f;
        Input.location.Start();
        Input.compass.enabled = true;
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Quaternion attitude = Input.gyro.attitude;
        // rotator.transform.rotation = attitude;
        // rotator.transform.Rotate(0f, 0f, 180f, Space.Self);
        // rotator.transform.Rotate(90f, 180f, 0f, Space.World);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotator.rotation, smoothing);
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);

        Vector3 direction = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);

        screenText.text = "Velocidad angular: " + Input.gyro.attitude.ToString() + "\n" + 
                        "Aceleración: " + Input.acceleration.ToString() + "\n" +
                        "Altitud: " + Input.location.lastData.altitude.ToString() + "\n" +
                        "Longitud: " + Input.location.lastData.longitude.ToString() + "\n" +
                        "Latitud: " + Input.location.lastData.latitude.ToString();
    }
}
