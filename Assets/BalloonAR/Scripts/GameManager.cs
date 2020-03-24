using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The game manager will be responsible for handling the general logic of the game
/// In this case it will initially ask from the BalloonManager Instance to set the game
/// Finally, everytime all the spawned balloons are poped we consider the level to be cleared thus the Level Manager is being alerted.
/// In this version of the game we keep track of the levels however the visuals and interaction remain the same through the levels
/// </summary> 
public class GameManager : MonoBehaviour
{

    //TODO most probably I need to revist this
    public enum GameStatus
    {
        Paused,
        Playing,
        LevelOver
    }
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    private void Start()
    {

    }


    /// <summary>
    /// Responds on what happens when All Ballons are poped. In the future this needs a Level 
    /// </summary>
    void HandleAllBalloonsPoped()
    {

    }


    public void LevelCleared()
    {

        LevelManager.Instance.Level = LevelManager.Instance.Level + 1;
        //   BalloonManager.Instance.SpawnBalloonsAccordingToLevel(LevelManager.Instance.MaxNumberOfBalloons);

    }


}
