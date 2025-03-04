using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Animator gunAnim;
    public Transform gun;
    public Transform player; // Assign the player object
    public float gunDistance = 1.5f;
    private bool gunFacingRight = true; // Track gun facing direction
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float lifetime = 5f;
    public int currentBullet;
    public int maxBullet=115;
    private void Start()
    {
        ReloadGun();
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGun();
        }



        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Keep it on the 2D plane

        // Calculate direction from player to mouse
        Vector3 direction = (mousePos - player.position).normalized;

        // Calculate angle and apply rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0f, 0f, angle);

        // Keep gun at a fixed distance from the player
        gun.position = player.position + (Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0));

        // **Flip Gun Based on Mouse Position**
        if (mousePos.x < player.position.x && gunFacingRight)
        {
            gunFacingRight = false;
            gun.localScale = new Vector3(1, -1, 1); // Flip vertically
        }
        else if (mousePos.x > player.position.x && !gunFacingRight)
        {
            gunFacingRight = true;
            gun.localScale = new Vector3(1, 1, 1); // Normal orientation
        }

        // Handle shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(direction);
        }
    }

    private void Shoot(Vector3 direction)
    {
       
        if (currentBullet <= 0)
            return;
        gunAnim.SetTrigger("Shoot");
        currentBullet--;



        // Instantiate the bullet and store it in a variable
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);


        // Get the Rigidbody2D from the instantiated bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * bulletSpeed; // Move bullet in direction
        }
        Destroy(bullet, 1f);

    }
    private void ReloadGun()
    {
          currentBullet = maxBullet;
    }

    

}



