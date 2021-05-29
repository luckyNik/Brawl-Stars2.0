using UnityEngine;
using GlobalPlayerManager = global::PlayerManager;

public class CameraWork : MonoBehaviour
{
    [Tooltip("The distance in the local x-z plane to the target")]
    [SerializeField]
    private float distance = 7.0f;

    [Tooltip("The height we want the camera to be above the target")]
    [SerializeField]
    private float height = 3.0f;

    [Tooltip("Allow the camera to be offseted vertically from the target, for example giving more view of the sceneray and less ground.")]
    [SerializeField]
    private Vector3 centerOffset = Vector3.zero;


    [Tooltip("The Smoothing for the camera to follow the target")]
    [SerializeField]
    private float smoothSpeed = 0.125f;

    // cached transform of the target
    Transform cameraTransform;
    Transform target;

    // maintain a flag internally to reconnect if target is lost or camera is switched
    bool isFollowing;

    // Cache for camera offset
    private Vector3 cameraOffset = Vector3.zero;

    private bool initialized = false;
    private void Awake()
    {
        GlobalPlayerManager.LocalPlayerInstanceCreated += (playerGO) =>
        {
            target = playerGO.transform;
            OnStartFollowing();
            initialized = true;
        };
    }

    void LateUpdate()
    {
        if (!initialized)
        {
            return;
        }

        // only follow is explicitly declared
        if (isFollowing)
        {
            Follow();
        }
    }

    public void OnStartFollowing()
    {
        cameraTransform = transform;
        isFollowing = true;

        // we don't smooth anything, we go straight to the right camera shot
        Cut();
    }

    void Follow()
    {
        cameraOffset.z = -distance;
        cameraOffset.y = height;

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, target.position + target.TransformVector(cameraOffset), smoothSpeed * Time.deltaTime);
        cameraTransform.LookAt(target.position + centerOffset);
    }


    void Cut()
    {
        cameraOffset.z = -distance;
        cameraOffset.y = height;

        cameraTransform.position = target.position + target.TransformVector(cameraOffset);
        cameraTransform.LookAt(target.position + centerOffset);
    }
}