using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Level
{

    private int maxBalloonsInLevel;

    public int MaxBalloonsInLevel { get => maxBalloonsInLevel; }


    private int remainingBallonsInLevel;

    public int RemainingBallonsInLevel { get => remainingBallonsInLevel; }

    public void InitializeLevel(int balloons)
    {
        maxBalloonsInLevel = balloons;
        remainingBallonsInLevel = maxBalloonsInLevel;
    }

    //TODO I need an interactable ID to describe say a Red Balloon as Item1 and a Green Balloon as Item2.

    //TODO
    //Think What I need in the concept of a level.


    //NumberOfInteractables.
    //TypesOfInteractables.


    //CurrentNumber OF Interactables

    //A way to communicate a change in available interactables -> A Balloon Poped -> No Balloons remaining
}
