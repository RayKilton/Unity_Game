using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Direction direction;
    public enum Direction
    {
        p1,
        p2,
        p3,
        p4,
        p5,
        p6,
        None
    }

    public VariantHexes Hex;
    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;

    private void Start()
    {
        Hex = GameObject.FindGameObjectWithTag("points").GetComponent<VariantHexes>();////
        Destroy(gameObject, waitTime);
        Invoke("Spawned", 0.2f);
    }
    public void Spawned()
    {
        if (!spawned)
        {
            if(direction == Direction.p1 || direction == Direction.p2 || direction == Direction.p3 || direction == Direction.p4 || direction == Direction.p5 || direction == Direction.p6)
            {
                //rand = Random.Range(0, Hex);
                Instantiate(Hex, transform.position, Hex.transform.rotation);
            }
            spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("points") && other.GetComponent<Spawn>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
