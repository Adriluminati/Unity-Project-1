using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Camera cameraFollow;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
