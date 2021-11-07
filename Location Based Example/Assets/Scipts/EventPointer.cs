using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mapbox Library
using Mapbox.Examples;
using Mapbox.Utils;
public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float amplitude = 2.0f;
    [SerializeField] float frequency = 0.50f;

    LocationStatus playerLocation;
    public Vector2d eventPos;
    public int eventID;
    MenuUIManager menuUIManager;
    EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        eventManager = GameObject.Find("-EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    void FloatAndRotatePointer()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 15, transform.position.z);
    }

    private void OnMouseDown()
    {

        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLon());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
        Debug.Log("Distance is: " + distance);
        if(distance < eventManager.maxDistance)
        {
            menuUIManager.DiplayStartEventPanel(eventID);
        } else
        {
            menuUIManager.DisplayUserNotInRangePanel();
        }
    }
}
