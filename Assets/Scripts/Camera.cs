using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Vector3 offset;

    public float humanLength = 1.5f;


    private Player player;
    void Start()
    {
        player = target.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.getPlayerPosition();
        Vector3 newPos = player.getPlayerPosition() - offset - offset.normalized * player.getHumandCount() * humanLength / Mathf.PI;
        newPos.x = 0;
        transform.position = Vector3.Lerp(transform.position, newPos, 0.8f * Time.deltaTime);
        transform.LookAt(playerPos);
    }
}
