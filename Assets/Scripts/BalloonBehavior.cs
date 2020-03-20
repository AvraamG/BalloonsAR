using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO Create an Item Class that a balloon can interact with. 
public class BalloonBehavior : MonoBehaviour
{
    [SerializeField]
    Color greenColor;
    [SerializeField]
    Color yellowColor;
    [SerializeField]
    Color orangeColor;

    public static Action<BalloonBehavior> OnBalloonPoped;
    AudioSource popSound;


    GameObject ballonIllustration;
    GameObject distanceIndicatorObject;
    TextMesh distanceTextMesh;

    float destructionTime;

    private void OnEnable()
    {
        ballonIllustration = this.transform.Find("Balloon").gameObject;
        distanceIndicatorObject = this.transform.Find("DistanceIndicator").gameObject;
        distanceTextMesh = this.transform.Find("DistanceIndicator").gameObject.transform.Find("DistanceText").GetComponent<TextMesh>();
        popSound = this.GetComponent<AudioSource>();
        destructionTime = popSound.clip.length;
    }


    private void Update()
    {
        UpdateDistanceFromPlayer();
    }

    private void UpdateDistanceFromPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
        distanceTextMesh.text = Math.Abs(distance).ToString("F1");

        //TODO probably change the Color based on distance, IF I am less than 1 M away I should make it Green.
        if (Math.Abs(distance) < 1)
        {
            distanceTextMesh.color = greenColor;

        }
        else if (Math.Abs(distance) > 1 && Math.Abs(distance) < 4)
        {
            distanceTextMesh.color = yellowColor;

        }
        else
        {
            distanceTextMesh.color = orangeColor;
        }
    }



    //TODO Further Generalize this
    public void Interact()
    {
        if (OnBalloonPoped != null)
        {
            OnBalloonPoped(this);
            ballonIllustration.SetActive(false);
            distanceIndicatorObject.SetActive(false);
            if (!popSound.isPlaying)
            {
                popSound.Play();
            }
            Destroy(this.gameObject, destructionTime);
        }
    }
}
