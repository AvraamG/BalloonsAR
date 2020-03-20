using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    [SerializeField]
    AudioSource popSoundEffect;
    /// <summary>
    /// The BalloonManager is the class that is going to be responsible for handling all the actions regarding the balloons.
    /// </summary>
    #region Singleton
    private static BalloonManager _instance;
    public static BalloonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject bm = new GameObject("BalloonManager");
                bm.AddComponent<BalloonManager>();
            }

            return _instance;
        }
    }
    #endregion


    //Keep track of the balloons that currently exist in the scene by assigning them to a static value and make use of it through a property.
    private static int _balloonsInPlay;
    public static int BalloonsInPlay
    {
        get
        {
            return _balloonsInPlay;
        }
        set
        {
            _balloonsInPlay = value;
        }
    }

    //Keep track of the total number of balloons poped during the game play. It is not currently used, but it can be utilized in a Text to indicate the score.
    //Again, we assign this value to a static int and make use of it through the property.
    private static int _popedBalloonCounter;
    public static int PopedCounter
    {
        get
        {
            return _popedBalloonCounter;
        }
        set
        {
            _popedBalloonCounter = value;
        }

    }

    private void Awake()
    {
        _instance = this;

    }

    //Logic of what happens when a balloon is poped.
    public void BalloonPopedAtPosition(Vector3 popedPosition)
    {

        popSoundEffect.Play();
        // Since the nail touches the balloon we instantiate a game object that has a particle system and the sound effect.
        GameObject pop = Instantiate(GameManager.Instance.PopIllustration, popedPosition, Quaternion.identity);


        //In order not to clean up the scene after the effect has finished, we call the Destroy method with a time value of when the Destruction should happen.
        //The timeToDestroy value could be set by the either the ParticleSystem.duration, the soundeffect duration or any other preferrence.
        float timeToDestroy = 1f;
        Destroy(pop, timeToDestroy);

        // Reduce the number of balloons are present in the scene.
        // If there are now balloons in the scene any more, you can decide what the logic should follow
        // in this case the game restarts by respawning the balloons

        BalloonsInPlay--;
        if (BalloonsInPlay == 0)
        {

            //There are currently no balloons left in the scene and the level is cleared
            //The Game manager is alerted in order to decide what is going to happen next
            GameManager.Instance.LevelCleared();

        }


        //Also keep track of the total ammount of balloons that have been poped in order to be used as a score value.
        PopedCounter++;



    }


    public void SpawnBalloonsAccordingToLevel(int numberOfBalloons)
    {
        // Create balloons in the scene by Instantiating the balloon prefab.
        // The number of the balloons is set by the MaxNumberOfBalloons and the position is fixed with a small degree of randomness in the Z Value;
        // If at any point the distance from the camera needs to be adjusted, it can be done by changing the values of min and max DistanceZ.

        float minDistanceZ = 4f;
        float maxDistanceZ = 5f;

        for (int i = 0; i < numberOfBalloons; i++)
        {
            Vector3 pseudoRandomPosition = new Vector3(i - 1.5f, 2, Random.Range(minDistanceZ, maxDistanceZ));
            SpawnBalloon(pseudoRandomPosition);
            BalloonsInPlay++;
        }
    }


    public void SpawnBalloon(Vector3 spawnPosition)
    {
        //The general method that is responsible to instantiate a given balloon to a given location.
        //By including different balloon or other type of prefabs you can further customize your game to spawn different things according to the level

        GameObject balloonPrefab = GameManager.Instance.UnitIllustration;
        Instantiate(balloonPrefab, spawnPosition, balloonPrefab.transform.rotation);
    }
}
