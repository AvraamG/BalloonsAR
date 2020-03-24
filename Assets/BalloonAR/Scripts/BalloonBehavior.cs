using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
//TODO Create an Item Class that a balloon can interact with. 
public class BalloonBehavior : MonoBehaviour
{
    public static Action<BalloonBehavior> OnBalloonPoped;

    AudioSource popSound;

    GameObject ballonIllustration;

    MeshRenderer balloonPlasticMeshRenderer;

    float destructionTime;

    #region Distance Indicator
    Color letterDistanceGreen = new Color(0.48f, 0.98f, 0.73f);
    Color letterDistanceYellow = new Color(1f, 0.90f, 0.26f);
    Color letterDistanceOrange = new Color(1f, 0.90f, 0f);

    GameObject distanceIndicatorObject;
    TextMesh distanceTextMesh;
    #endregion

    #region Particles
    ParticleSystem pop;
    ParticleSystem star;
    ParticleSystem halo;

    ParticleSystem.MainModule popParticleMain;
    ParticleSystem.MainModule startParticleMain;
    ParticleSystem.MainModule haloParticle;
    #endregion

    #region Behavior Specifics

    public enum BalloonType
    {
        Red,
        Green,
        Gold,
        Silver,
        Black
    }

    public BalloonType myBaloonType;


    //TODO instead of the level Manager bring a base points worth on the item, so it can scale on multiple items.
    private int pointsWorth = 0;
    public int itemAward
    {
        get
        {
            return pointsWorth;
        }
    }
    Color customRed = new Color(1, 0, 0);
    Color customGreen = new Color(0.231f, 0.96f, 0.26f);
    Color customGold = new Color(0.962f, 0.7f, 0.23f);
    Color customSilver = new Color(0.5f, 0.5f, 0.5f);
    Color customBlack = new Color(0, 0, 0);

    #endregion

    private void OnEnable()
    {
        ballonIllustration = this.transform.Find("Balloon").gameObject;
        distanceIndicatorObject = this.transform.Find("DistanceIndicator").gameObject;
        distanceTextMesh = this.transform.Find("DistanceIndicator").gameObject.transform.Find("DistanceText").GetComponent<TextMesh>();

        balloonPlasticMeshRenderer = ballonIllustration.transform.Find("Baloon").transform.Find("Plastic").GetComponent<MeshRenderer>();
        popSound = this.GetComponent<AudioSource>();

        pop = this.transform.Find("BalloonParticlePlasticPop").gameObject.GetComponent<ParticleSystem>();
        popParticleMain = pop.main;

        star = this.transform.Find("Stars").gameObject.GetComponent<ParticleSystem>();
        startParticleMain = star.main;

        halo = this.transform.Find("Halo").gameObject.GetComponent<ParticleSystem>();
        haloParticle = halo.main;

        //TODO Replace this with proper instantiation
        int randomIndex = UnityEngine.Random.Range(0, 4);

        InitializeBalloon((BalloonType)randomIndex);
        CalculateDestructionTime();

    }





    /// <summary>
    /// Initializes different balloon types with different rewards and visualizations.
    /// </summary>
    /// <param name="type">Type of Balloon</param>
    public void InitializeBalloon(BalloonType type)
    {
        myBaloonType = type;

        AssignPoints();

    }

    /// <summary>
    /// Assign the points this item is worth.
    /// </summary>
    void AssignPoints()
    {
        switch (myBaloonType)
        {
            case BalloonType.Red:
                pointsWorth = 10;
                balloonPlasticMeshRenderer.material.color = customRed;
                popParticleMain.startColor = customRed;
                break;
            case BalloonType.Green:
                pointsWorth = 20;
                balloonPlasticMeshRenderer.material.color = customGreen;
                popParticleMain.startColor = customGreen;
                break;
            case BalloonType.Gold:
                pointsWorth = 100;
                balloonPlasticMeshRenderer.material.color = customGold;
                popParticleMain.startColor = customGold;
                break;
            case BalloonType.Silver:

                pointsWorth = 50;
                balloonPlasticMeshRenderer.material.color = customSilver;
                popParticleMain.startColor = customSilver;

                break;
            case BalloonType.Black:

                pointsWorth = 1;
                balloonPlasticMeshRenderer.material.color = customBlack;
                popParticleMain.startColor = customBlack;

                break;
            default:
                break;
        }
    }
    /// <summary>
    /// This method takes into account all the time needed for the audiovisuals to happen in order for the item to be destroyed.
    /// In the past it should be used as a reference to the object pool.
    /// </summary>
    void CalculateDestructionTime()
    {

        List<float> alltimes = new List<float> { popSound.clip.length, popParticleMain.duration, startParticleMain.duration, haloParticle.duration };
        destructionTime = alltimes.Max();
    }



    private void Update()
    {
        UpdateDistanceFromPlayer();
    }

    /// <summary>
    /// Visually updates the distance from the camera, in this case the main camera.
    /// </summary>
    private void UpdateDistanceFromPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
        distanceTextMesh.text = Math.Abs(distance).ToString("F1");

        if (Math.Abs(distance) < 1)
        {
            distanceTextMesh.color = letterDistanceGreen;

        }
        else if (Math.Abs(distance) > 1 && Math.Abs(distance) < 4)
        {
            distanceTextMesh.color = letterDistanceYellow;

        }
        else
        {
            distanceTextMesh.color = letterDistanceOrange;
        }
    }



    //TODO Further Generalize this
    public void Interact()
    {
        if (OnBalloonPoped != null)
        {
            OnBalloonPoped(this);
        }

        PopBalloon();
    }

    /// <summary>
    /// Aside the general Item interaction, this is the specific reaction that happens when the balloon Interacts With something. 
    /// </summary>
    void PopBalloon()
    {
        ballonIllustration.SetActive(false);

        //TODO I need this to fall off.
        distanceIndicatorObject.SetActive(false);

        if (!popSound.isPlaying)
        {
            popSound.Play();
        }

        if (!pop.isPlaying)
        {
            pop.Play();
        }
        if (!halo.isPlaying)
        {
            halo.Play();
        }
        if (!star.isPlaying)
        {
            star.Play();
        }


        Destroy(this.gameObject, destructionTime);
    }
}
