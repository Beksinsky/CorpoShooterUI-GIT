using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shots;
    public float cooldown; //cooldown między strzałami
    public float projectileSpeed;
    public Projectile projectile;
    public bool isShooting = false; // broń może być w dwóch stanach: strzelająca albo nie
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting == true)
        {
            shots -= Time.deltaTime; //liczba strzałów jest cały czas obniżana żeby ustalić cooldown = czasowi
            if(shots <= 0)
            {
                shots = cooldown; // jak bedzie 0 to znaczy ze cooldown minął i można wystrzelić kolejną kulę.
                //projectile bedzie mial wszystkie cechy prefabu (czyli aż kolor i kształt XD)
                Projectile newProjectile = Instantiate(projectile, target.position, target.rotation) as Projectile;
                newProjectile.bulletSpeed = projectileSpeed;
                
            }
        }
        else
        {
            shots = 0;
        }
    }
    
}
