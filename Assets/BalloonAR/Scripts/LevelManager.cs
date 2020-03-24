using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;

//TODO This is not really a Manager but a singleLevel
/// <summary>
/// The Level manager holds the logic of what should happen in a given level.
/// In this example, the Level manager holds the number of balloons that should be spawned and the numeric value of the level.
/// Eventhough in this example we are keeping the balloon number the same throughout the levels it is highly customizable on how the progression through the levels should affect the number of balloons.
/// </summary>
public class LevelManager : MonoBehaviour
{

    public static Action OnLevelCleared;

    [SerializeField]
    GameObject floatingPointsPrefab;


    //TODO Introduce the concept of Levels.
    //List<Level> allLevels
    [SerializeField]
    List<Level> allLevels;

    int progress;
    Level currentLevel;

    #region Singleton
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private int _maxNumberOfBalloons;
    public int MaxNumberOfBalloons
    {
        get
        {
            return _maxNumberOfBalloons;
        }
        set
        {
            _maxNumberOfBalloons = value;
        }
    }

    private int _level;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    private void Awake()
    {


        if (_instance == null)
        {
            _instance = this;

            //TODO this is static for now
            PopulateLevels();
            SetCurrentLevel();

            Interactable.OnItemInteractedWith += HandleItemInteractedWith;
            ARSession.stateChanged += HandleStateChanged;


        }


    }

    /// <summary>
    /// This method gets the information regarding the levels. In the future this should be linked to a db.
    /// </summary>
    public void PopulateLevels()
    {


        Level firstLevel = new Level();
        firstLevel.InitializeLevel(10);


        Level secondLevel = new Level();
        secondLevel.InitializeLevel(15);

        allLevels = new List<Level>();
        allLevels.Add(secondLevel);

    }

    public void SetCurrentLevel()
    {
        //TODO in the future the user progress should be stored somewhere. PlayerPrefs or DBV
        progress = 0;
        currentLevel = allLevels[progress];

    }





    //Logic of what happens when a balloon is poped.
    public void HandleItemInteractedWith(Interactable interactable)
    {


        SpawnPointIndicator(interactable.transform.position, interactable.PointsWorth);


    }

    /// <summary>
    /// Spawns a 3D text on the place the balloon was poped. Notifying the user of the points awarded. 
    /// </summary>
    /// <param name="position">Balloon Position</param>
    /// <param name="addedScore">Score ammount</param>
    void SpawnPointIndicator(Vector3 position, int addedScore)
    {
        GameObject points = Instantiate(floatingPointsPrefab);
        points.transform.position = position;


        //TODO Improve that. 
        // points.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        points.GetComponent<TextMesh>().text = addedScore.ToString();

        //TODO Create a behavior on the object instead.
        //Create an object pool
        //Fade this instead

        Destroy(points, 2f);
    }



    /// <summary>
    /// Responds to the ARsessions state changed by displaying the appropriate message and visuals.
    /// </summary>
    /// <param name="eventArg"></param>
    private void HandleStateChanged(ARSessionStateChangedEventArgs eventArg)
    {
        //TODO I should not be spawning stuff when the detection is not great 

        if (ARSession.state != ARSessionState.SessionTracking)
        {

        }
    }

}
