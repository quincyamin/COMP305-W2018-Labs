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
    private float _startXPos;
    private float _midRegion;
    private float _offset;
    private float _fieldOfView;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        if(regionText) regionText.text = "Region 1";
        _midRegion = cameraWidth / 2;
        _startXPos = transform.position.x - _midRegion;
        _offset = player.position.x - transform.position.x;
        _fieldOfView = _camera.orthographicSize;
    }

    private void Update()
    {
        if (player.position.x > _startXPos + _midRegion)
        {
            if (player.position.x > _startXPos + cameraWidth)
            {
                if(regionText) regionText.text = "Region 3";
                _fieldOfView -= Input.GetAxis("Horizontal") * Time.deltaTime;
                _fieldOfView = Mathf.Clamp(_fieldOfView, 5f, 6.5f);
                _camera.orthographicSize = _fieldOfView;
            }
            else
            {
                if(regionText) regionText.text = "Region 2";
            }
            _offset = player.position.x - transform.position.x;
            var xPos = _offset + transform.position.x;
            xPos = Mathf.Clamp(xPos, 0f, 36.7f);
            transform.position = new Vector3(xPos, 0f, -10f);

        }
        else
        {
            if(regionText) regionText.text = "Region 1";
        }
    }
}