using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Assertions.Must;

public class CameraScript : MonoBehaviour
{
    public List<Transform> players;

    public Vector2 offSet;

    private Vector2 velocity;

    private Camera cam;

    public float smoothTime = 0.1f;

    public float minZoom = 40f;

    public float maxZoom = 20f;

    public float zoomLimiter = 50f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (players.Count == 0)
            return;
        Move();
        Zoom();

    }

    private void Move()
    {
        Vector2 centerPoint = GetCenterPoint();

        Vector2 newPosition = centerPoint + offSet;

        transform.position = Vector2.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {

        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/ zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime / 5);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(players[0].position, Vector2.zero);
        for (int i = 0; i < players.Count; i++)
        {
            bounds.Encapsulate(players[i].position);
        }

        return bounds.size.x;

    }

    Vector2 GetCenterPoint()
    {
        if (players.Count == 1)
        {
            return players[0].position;
        }
        else
        {
            var bounds = new Bounds(players[0].position, Vector2.zero);
            for (int i = 0; i < players.Count; i++)
            {
                bounds.Encapsulate(players[i].position);
            }
            return bounds.center;
        }

    }
}
