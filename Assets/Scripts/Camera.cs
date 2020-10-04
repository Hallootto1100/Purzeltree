using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.position - offset;
        newPosition.x = 0;
        transform.position = newPosition;
        transform.LookAt(new Vector3(0, player.position.y, player.position.z));
    }
}
