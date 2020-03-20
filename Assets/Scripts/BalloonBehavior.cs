using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO Create an Item Class that a balloon can interact with. 
public class BalloonBehavior : MonoBehaviour
{
    public static Action<BalloonBehavior> OnBalloonPoped;
    AudioSource popSound;


    GameObject ballonIllustration;
    GameObject distanceIndicatorObject;
    float destructionTime;

    private void OnEnable()
    {
        ballonIllustration = this.transform.Find("Balloon").gameObject;
        distanceIndicatorObject = this.transform.Find("DistanceIndicator").gameObject;
        popSound = this.GetComponent<AudioSource>();
        destructionTime = popSound.clip.length;
    }

    //TODO Pop is too mainstream. 
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
