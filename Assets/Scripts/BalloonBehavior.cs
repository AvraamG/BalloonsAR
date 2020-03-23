using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO Create an Item Class that a balloon can interact with. 
public class BalloonBehavior : MonoBehaviour
{
    //TODO I dont need this serialized. 
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

    MeshRenderer balloonPlasticMeshRenderer;

    float destructionTime;

    //TODO this belongs to the Award class instead
    private int pointsWorth = 0;

    public enum BalloonType
    {
        Red,
        Green,
        Gold,
        Silver,
        Black
    }

    public BalloonType myBaloonType;

    private void OnEnable()
    {
        ballonIllustration = this.transform.Find("Balloon").gameObject;
        distanceIndicatorObject = this.transform.Find("DistanceIndicator").gameObject;
        distanceTextMesh = this.transform.Find("DistanceIndicator").gameObject.transform.Find("DistanceText").GetComponent<TextMesh>();

        balloonPlasticMeshRenderer = ballonIllustration.transform.Find("Baloon").transform.Find("Plastic").GetComponent<MeshRenderer>();
        popSound = this.GetComponent<AudioSource>();
        destructionTime = popSound.clip.length;


        //TODO Replace this with proper instantiation
        int randomIndex = UnityEngine.Random.Range(0, 4);
        InitializeBalloon((BalloonType)randomIndex);

    }

    Color customRed = new Color(1, 0, 0);
    Color customGreen = new Color(0.231f, 0.96f, 0.26f);
    Color customGold = new Color(0.962f, 0.7f, 0.23f);
    Color customSilver = new Color(0.66f, 0.66f, 0);
    Color customBlack = new Color(0, 0, 0);



    /// <summary>
    /// Initializes different balloon types with different rewards and visualizations.
    /// </summary>
    /// <param name="type">Type of Balloon</param>
    public void InitializeBalloon(BalloonType type)
    {



        myBaloonType = type;

        switch (myBaloonType)
        {
            case BalloonType.Red:
                pointsWorth = 10;
                balloonPlasticMeshRenderer.material.color = customRed;
                break;
            case BalloonType.Green:
                pointsWorth = 20;
                balloonPlasticMeshRenderer.material.color = customGreen;
                break;
            case BalloonType.Gold:
                pointsWorth = 100;
                balloonPlasticMeshRenderer.material.color = customGold;

                break;
            case BalloonType.Silver:

                pointsWorth = 50;
                balloonPlasticMeshRenderer.material.color = customSilver;

                break;
            case BalloonType.Black:
                //TODO answer why I did this
                pointsWorth = 1;

                balloonPlasticMeshRenderer.material.color = customBlack;

                break;
            default:
                break;
        }
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
