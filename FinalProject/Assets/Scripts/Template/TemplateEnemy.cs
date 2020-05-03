/*
    * Jacob Cohen
    * TemplatEnemy.cs
    * Final Project
    * main class for the template pattern
*/

using UnityEngine;

public abstract class TemplatEnemy: MonoBehaviour
{
    //variables
    private Transform playerLocation;
    protected float speed;
    protected int health;
    protected int damage;
    private const float DETECTION_DISTANCE = 2f;
    

    private void Start() 
    {
        //get player
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform; 

        //set stats
        SetDamage();
        SetHealth();
        SetSpeed();    
    }
    
    private void Update() 
    {
        //check to see if player is in range
        if(Vector2.Distance(this.gameObject.transform.position, playerLocation.position) <= DETECTION_DISTANCE)
        {
            //move towards player
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, playerLocation.position, speed * Time.deltaTime);

            //look towards player
            this.gameObject.transform.up = playerLocation.position - transform.position;
        }
    }

    public void Attacked()
    {
        //check to see if dead
        if(health <= 0)
        {
            //remove enemy
            this.gameObject.SetActive(false);

        }
        else
        {
            //dec
            health--;
        }

        //done
        return;
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //call
            other.gameObject.GetComponent<PlayerController>().Attacked(damage);

            //hide
            this.gameObject.SetActive(false);
        }    
    }

    public abstract void SetSpeed();
    public abstract void SetDamage();
    public abstract void SetHealth();
}