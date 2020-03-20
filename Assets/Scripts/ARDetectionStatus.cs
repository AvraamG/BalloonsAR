using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.XR.ARFoundation;
using TMPro;


public class ARDetectionStatus : MonoBehaviour
{

    TextMeshProUGUI statusText;
    GameObject detectionSquare;
    GameObject textDisplay;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the components needed for The visualization of ARSession status. If everything is in place subscribe to the event.
    /// </summary>
    private void Initialize()
    {
        if (!statusText)
        {
            try
            {
                statusText = GameObject.Find("StatusText").GetComponent<TextMeshProUGUI>();

            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);
            }
        }

        if (!detectionSquare)
        {
            try
            {
                detectionSquare = GameObject.Find("DetectionSquare");

            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);

            }
        }
        if (!textDisplay)
        {
            try
            {
                textDisplay = statusText.transform.parent.gameObject;
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);

            }
        }


        if (statusText && detectionSquare && textDisplay)
        {
            ARSession.stateChanged += HandleStateChanged;
            Debug.Log("Subscribed to  ARSession.stateChanged event");
        }
        else
        {
            Debug.LogError("Error: Unable to procceed with ARsession visualization");
            this.gameObject.SetActive(statusText && detectionSquare && textDisplay);
        }

    }

    /// <summary>
    /// Responds to the ARsessions state changed by displaying the appropriate message and visuals.
    /// </summary>
    /// <param name="eventArg"></param>
    private void HandleStateChanged(ARSessionStateChangedEventArgs eventArg)
    {
        textDisplay.SetActive(eventArg.state != ARSessionState.SessionTracking);
        detectionSquare.SetActive(eventArg.state != ARSessionState.SessionTracking);

        switch (eventArg.state)
        {
            case ARSessionState.None:
                statusText.text = "Session status none";

                break;
            case ARSessionState.Unsupported:
                statusText.text = "ARFoundation not supported";

                break;
            case ARSessionState.CheckingAvailability:
                statusText.text = "Checking availability";

                break;
            case ARSessionState.NeedsInstall:
                statusText.text = "Needs Install";

                break;
            case ARSessionState.Installing:
                statusText.text = "Installing";

                break;
            case ARSessionState.Ready:
                statusText.text = "Ready";

                break;
            case ARSessionState.SessionInitializing:
                statusText.text = "Poor SLAM Quality";


                break;
            case ARSessionState.SessionTracking:
                statusText.text = "Tracking quality is Good";

                break;
            default:
                break;
        }



    }

}
