using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject ragdoll;
    public Canvas canvas;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        int n = other.gameObject.GetComponentInParent<Player>().getHumandCount();
        for(int i = 0; i < n; ++i){
            Instantiate(ragdoll, other.gameObject.transform.position, Quaternion.identity)
            .GetComponentInChildren<Rigidbody>().AddForce(500f * new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)), ForceMode.Impulse);
        }
        Destroy(other.gameObject);
        canvas.enabled = true;

    }
}
