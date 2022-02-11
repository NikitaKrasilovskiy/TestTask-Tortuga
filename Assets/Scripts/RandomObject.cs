using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject spawnees;
    public float minDelay, maxDelay;
    float nextLaunchTime;
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            Instantiate(spawnees, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}