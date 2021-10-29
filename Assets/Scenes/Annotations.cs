using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annotations : MonoBehaviour
{

    public enum PivotAxis
    {
        Free,
        X,
        Y
    }

    public PivotAxis PivotAxiss = PivotAxis.Free;
    public Quaternion DefaultRotation { get; private set; }

    public GameObject StartPoint;
    public GameObject EndPoint;
    LineRenderer Line;
    public Transform startMarker;
    public Transform endMarker;    // Movement speed in units per second.
    public float speed = 0.002F;    // Time when the movement started.
    private float startTime;    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        Line = gameObject.AddComponent<LineRenderer>();
        startTime = Time.time;        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

    }
    private void Awake()
    {
        DefaultRotation = gameObject.transform.rotation;
    }


    [System.Obsolete]
    void Update()
    {
        List<Vector3> pos = new List<Vector3>();
        pos.Add(StartPoint.transform.position);
        pos.Add(EndPoint.transform.position);
        Line.startWidth = 0.01f;
        Line.endWidth = 0.01f;
        Line.SetPositions(pos.ToArray());
        Line.useWorldSpace = true;
        Line.SetColors(Color.white, Color.white);

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;        
        float fractionOfJourney = distCovered / journeyLength;        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

        Vector3 forward;
        Vector3 up;

        switch (PivotAxiss)
        {

            case PivotAxis.X:
                Vector3 right = transform.right; // Fixed right
                forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, right).normalized;
                up = Vector3.Cross(forward, right); 
                break;

            case PivotAxis.Y:
                up = transform.up; 
                forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, up).normalized;
                break;

            case PivotAxis.Free:
            default:
                forward = Camera.main.transform.forward;
                up = Camera.main.transform.up;
                break;
        }

        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
