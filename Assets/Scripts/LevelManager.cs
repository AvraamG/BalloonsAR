using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// The Level manager holds the logic of what should happen in a given level.
    /// In this example, the Level manager holds the number of balloons that should be spawned and the numeric value of the level.
    /// Eventhough in this example we are keeping the balloon number the same throughout the levels it is highly customizable on how the progression through the levels should affect the number of balloons.
    /// </summary>

    #region Singleton
    /// <summary>
    /// 
    /// </summary>
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject lm = new GameObject("LevelManager");
                lm.AddComponent<LevelManager>();
            }

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
        _instance = this;
        _level = 1;
        _maxNumberOfBalloons = 4;
    }
}
