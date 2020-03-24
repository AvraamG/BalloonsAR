using UnityEngine;

/// <summary>
/// The nail class will use the Manomotion SDK in order to receive information about the gesture the user performs and move accordingly.
/// In this case the nail will move to the users index finger when the user is pointing.
/// Since the value of the Manomotion SDK for the pointer position is serialized for values [0-1] we need to adjust it to fit the screen width and height but also adjust the values for Z in order to reach in the distance
/// </summary>

public class NailBehavior : InteractionItem
{


    GameObject nailIllustration;

    private void Start()
    {

        nailIllustration = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        UseItem();

    }

    /// <summary>
    /// Make the Nail Face away 
    /// </summary>
    private void LookAwayFromPlayer()
    {
        this.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

    }

    public override void InitializeItem()
    {
        this.purchasePrice = 0;
        quantity = 1;

    }
    /// <summary>
    ///The Movement of the nail in this example is going to follow the index finger of the user when pointing
    //In order to understand that the user is in fact pointing, we make use of the HandtrackerManager instance that we declared before. 
    //From the htm we now get access to all of the information offered in the Manomotion SDK.
    //In this case we are interested in the class of the gesture, more specifically if it belongs to the POINTER_GESTURE_FAMILY.
    //If this condition is met, then we know for sure that the user is pointing.
    //As a visual que, we activate the nail illustration child object that holds the 3D Model and rest of the components.
    //Following to that, we make use of the Pointer_position as offered by the SDK in order to create the Vector3 position where we want the nail to move.
    //Finally, in order to have a smoother transition, we Learp the distance over time in order to achieve a better result.
    /// </summary>
    public override void UseItem()
    {
        if (ManomotionManager.Instance)
        {
            HandInfo info = ManomotionManager.Instance.Hand_infos[0].hand_info;
            //TODO Check if I need to wait for a couple of frames to make sure there is no noise affecting the detection
            nailIllustration.SetActive(info.gesture_info.mano_class == ManoClass.POINTER_GESTURE_FAMILY);

            if (info.gesture_info.mano_class == ManoClass.POINTER_GESTURE_FAMILY)
            {

                float depthadjustment = 2f;
                float adjustDepth = info.tracking_info.depth_estimation * depthadjustment;

                Vector3 pointerPosition = ManoUtils.Instance.CalculateNewPosition(info.tracking_info.bounding_box.top_left, adjustDepth);
                this.transform.position = Vector3.Lerp(this.transform.position, pointerPosition, Time.deltaTime * 10);

            }
            LookAwayFromPlayer();
        }
    }
}
