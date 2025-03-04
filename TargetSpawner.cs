using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public BoxCollider2D cd;
    public GameObject targetPrefab;
    public float coolDown;
    private float timer;
    public Sprite[] targetSprite;
    public float minCoolDown = 0.2f;
    public float coolDownDecreaseRate = 0.1f;
    public float initialCoolDown = 1f;
    /* public int sushicreated;
     public int sushiMileStone=10;*/
    void Start()
    {
        coolDown = initialCoolDown;  // Set initial cooldown
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 
        if(timer < 0)
    {
            timer = coolDown;
            /*sushicreated++;
            if (sushicreated > sushiMileStone && coolDown > .5f)
            {

            }*/
            GameObject newTarget = Instantiate(targetPrefab);
            float randomX = Random.Range(cd.bounds.min.x,cd.bounds.max.x);
            newTarget.transform.position = new Vector2(randomX,transform.position.y);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[Random.Range(0,targetSprite.Length)];

            coolDown = Mathf.Max(minCoolDown, coolDown - coolDownDecreaseRate * Time.deltaTime);
        }

    }

    
}
