using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update

    public int additionalHuman = 0;
    public float speedBoost = 0.0f;
    public bool destroy = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision with " + other.tag + "detected");
        if(other.tag != "Player")    
            return;

        other.gameObject.GetComponentInParent<Player>().addHuman(additionalHuman);
        other.gameObject.GetComponentInParent<Player>().addSpeedBoost(speedBoost);

        if(destroy)
            GameObject.Destroy(gameObject);
    }
}
