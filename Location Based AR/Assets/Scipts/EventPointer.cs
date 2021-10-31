using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Examples;
using Mapbox.Utils;

using UnityEngine.EventSystems;
public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float amplitude = 2.0f;
    [SerializeField] float frequency = 0.5f;
  
    private LocationStatus playerLocation;
    [SerializeField] public Vector2d eventPos;

    private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {


        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(uIManager == null)
        {
            Debug.LogError("UIManager is null");
        }
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            /*Debug.LogWarning("You clicked on me");*/
            //Getting User Location
            playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
            if (playerLocation == null)
            {
                Debug.LogError("Player Location is null");
            }
            var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLon(), playerLocation.GetLocationLat());
            var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
            var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
            /*Debug.Log("Distance is: " + distance);*/
            if (distance < 50)
            {
                uIManager.DisplayStartChallengePanel(true);
            }
            else
            {
                uIManager.DisplayUserNotInRnagePanel(true);
            }
        }
    }
}
