using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedForward;
    public float pickupForce = 3.0f;
    public float scale;
    public GameObject[] loops;
    private GameObject activeLoop;
    private int humanCount = 0;
    void Start()
    {
        setLoop(humanCount);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speedForward * Time.deltaTime, Space.World);

        float input = Input.GetAxis("Horizontal");
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 36, 0) * input, 1.0f);

        activeLoop.transform.Rotate(Vector3.right,  calculateRotationSpeed(activeLoop.GetComponent<SphereCollider>().radius) * 6 * Time.deltaTime);

        
        if(Input.GetKeyDown(KeyCode.L)){
            if(humanCount >= loops.Length)
                humanCount = 0;
            setLoop(humanCount++);
        }
    }

    public Vector3 getPlayerPosition()
    {
        return activeLoop.transform.position;
    }

    public int getHumandCount()
    {
        return humanCount;
    }

    public void addHuman(int count){
        humanCount += count;
        if(humanCount >= loops.Length)
            return;
        
        setLoop(humanCount);
    }

    public void addSpeedBoost(float boost)
    {
        if(boost == 0)
            return;

        StartCoroutine(timedSpeedBoost(boost));
    }

    IEnumerator timedSpeedBoost(float boost){
        speedForward *= boost;
        yield return new WaitForSeconds(5);
        speedForward /= boost;
    }

    private void setLoop(int index)
    {
        if(index < 0 || index >= loops.Length){
            Debug.Log("Index out of range");
            return;
        }

        Quaternion rotationBackup = Quaternion.identity;
        Vector3 positionBackup = transform.position;

        if(activeLoop  != null){
            rotationBackup = activeLoop.transform.rotation;
            positionBackup = activeLoop.transform.position;
            GameObject.Destroy(activeLoop);
        }

        // Vector3 spawnPos = new Vector3(positionBackup.x, loops[index].GetComponent<SphereCollider>().radius, positionBackup.z);
        activeLoop =  Instantiate(loops[index], positionBackup, rotationBackup);
        activeLoop.transform.SetParent(transform);
        activeLoop.GetComponent<Rigidbody>().AddForce(Vector3.up * pickupForce, ForceMode.Impulse);
        activeLoop.GetComponent<Rigidbody>().maxAngularVelocity = 0;
    }

    private float calculateRotationSpeed(float radius)
    {
        float rpm = 60 * speedForward / (radius * 2 * Mathf.PI);
        return rpm;
    }

}
