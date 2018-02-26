using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public Text regionText;
    public float cameraWidth;
    public Transform player;

    private Camera _camera;
    private float startXPos;
    private float midRegion;
    private float offset;
    private float fieldOfView;

    void Start()
    {
        _camera = GetComponent<Camera>();
        regionText.text = "Region 1";
        midRegion = cameraWidth / 2;
        startXPos = transform.position.x - midRegion;
        offset = player.position.x - transform.position.x;
        fieldOfView = _camera.orthographicSize;
    }

    void Update()
    {
        if (player.position.x > startXPos + midRegion)
        {
            if (player.position.x > startXPos + cameraWidth)
            {
                regionText.text = "Region 3";
                fieldOfView -= Input.GetAxis("Horizontal") * Time.deltaTime;
                fieldOfView = Mathf.Clamp(fieldOfView, 5f, 6.5f);
                _camera.orthographicSize = fieldOfView;
            }
            else
            {
                regionText.text = "Region 2";
            }
            offset = player.position.x - transform.position.x;
            float xPos = offset + transform.position.x;
            xPos = Mathf.Clamp(xPos, 0f, 36.7f);
            transform.position = new Vector3(xPos, 0f, -10f);

        }
        else
        {
            regionText.text = "Region 1";
        }
    }
}