using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class RopeLineRenderer : MonoBehaviour
{
    //In order to visually illustrate the line that connects the balloon to its base we are making use of a dynamic line renderer.
    //This will keep track of the movement of the balloon and adjust the line to it.
    //The behavior of the balloon can easily be customized in order to possibly break the rope and set the ballloon free.'

    [SerializeField]
    Transform lineOrigin, lineTarget;
    [SerializeField]
    LineRenderer ropeLineRenderer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ropeLineRenderer.SetPosition(0, lineOrigin.position);
        ropeLineRenderer.SetPosition(1, lineTarget.position);

    }
}
