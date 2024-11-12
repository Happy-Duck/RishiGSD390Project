using UnityEngine;

public class playerController : MonoBehaviour
{

    //Attribute: Using serialize field attribute to expose the speed modifier, player game object, bullet game object, and the gun game object in the unity editor
    [SerializeField] private float speedModifier = 1.0f;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;

    void Update()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal") , 0, Input.GetAxis("Vertical"));
        transform.position += movementVector * speedModifier * Time.deltaTime;

        if (Input.GetAxis("Horizontal") > 0) playerObject.transform.eulerAngles = new Vector3(0, 90, 0);
        if (Input.GetAxis("Horizontal") < 0) playerObject.transform.eulerAngles = new Vector3(0, -90, 0);
        if (Input.GetAxis("Vertical") > 0) playerObject.transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetAxis("Vertical") < 0) playerObject.transform.eulerAngles = new Vector3(0, 180, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bullet fired!");
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
    }
}
