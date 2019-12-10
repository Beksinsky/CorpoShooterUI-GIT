using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;
    //public Rigidbody myRigidbody;
    public GameObject projectile;
    public Gun weapon;
    public Vector3 moveInput;
    public Vector3 moveVelocity;
    public Camera myCamera;
    void Start()
    {
        //myRigidbody = GetComponent<Rigidbody>();
        myCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per fram
    
    void Update()
    {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = myCamera.ScreenPointToRay(Input.mousePosition);
        //tutaj ustalam 'kolizję' z ziemią żeby nie odpierdalał i nie latał po osi Y
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

    if (Input.GetMouseButton(0) && ground.Raycast(cameraRay, out rayLength)) //przypisz miejsce w które kamera strzela raycastem do rayLength
        {
            Vector3 target = cameraRay.GetPoint(rayLength);
            //Ustalenie jednego levelu patrzenia, tak zeby nie odpierdalał inby na osi Y
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            weapon.isShooting = true;
        }                     

        /* to jest poprzedni skrpyt, mozna go wywalić.
        //tworzenie raycasta w pozycji kursora
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //zmienna przechowująca pozycję wystrzelonego raya
        RaycastHit hit;
        //To co dzieje się po naciśnięciu przycisku
        Vector3 lookPoint = cameraRay
        if (Physics.Raycast(mouseRay, out hit)) 
        {
            //lookAt zeby obiekt obracał się w stronę pozycji hita
            this.transform.LookAt(hit.point);
            //tam gdzie obecnie naciskasz LPM zmienia się pozycja obiektu do którego skrypt jest przypisany
            if (Input.GetMouseButton(0) && Vector3.Distance(this.transform.position, hit.point) > 0.0f) {
                this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
            }
        }*/
        else if(Input.GetMouseButtonUp(0))
        {
            weapon.isShooting = false;
        }

    }

}
