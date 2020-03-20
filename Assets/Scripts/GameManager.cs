using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// The game manager will be responsible for handling the general logic of the game
    /// In this case it will initially ask from the BalloonManager Instance to set the game
    /// Finally, everytime all the spawned balloons are poped we consider the level to be cleared thus the Level Manager is being alerted.
    /// In this version of the game we keep track of the levels however the visuals and interaction remain the same through the levels
    /// </summary> 

    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GameManager");
                gm.AddComponent<GameManager>();
            }

            return _instance;
        }
    }
    #endregion


    [SerializeField]
    AudioSource levelSound;

    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        BalloonManager.Instance.SpawnBalloonsAccordingToLevel(LevelManager.Instance.MaxNumberOfBalloons);
    }


    public void LevelCleared()
    {
        //When all of the balloons are poped we consider the level to be cleared.
        //In turn, we advance to the next level and ask from the level manager to tell us how many balloons to spawn so the Balloon manager can spawn them.
        levelSound.Play();
        LevelManager.Instance.Level = LevelManager.Instance.Level + 1;
        BalloonManager.Instance.SpawnBalloonsAccordingToLevel(LevelManager.Instance.MaxNumberOfBalloons);

    }

    [SerializeField]
    GameObject _unitIllustration;
    public GameObject UnitIllustration
    {
        get
        {
            return _unitIllustration;
        }
    }

    //When the player pops a balloon we need a visual indicator that showcases this event
    //For this reason, we have a prefab, including a particles effect throwing stars
    [SerializeField]
    GameObject _popIllustration;
    public GameObject PopIllustration
    {
        get
        {
            return _popIllustration;
        }
        set
        {
            _popIllustration = value;
        }
    }
}
