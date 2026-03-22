using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float force_rotation = 0.75f;
    [SerializeField] private float force_up = 7f;
    [SerializeField] private float fuel = 25f;
    [SerializeField] private float max_fuel = 25f;
    [SerializeField] private bool dificult_hard = false;
    
    private float force_offset = 1f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel > 0) // Check if there is fuel left before allowing movement
        {
            RotationPropulsion();
            MainPropulsion();
        }else Manager_Game.Instance.SceneTransition(3);
    }

    // Returns the current velocity magnitude of the player's Rigidbody
    public float GetVelocity()
    {
        return rb.linearVelocity.magnitude;
    }

    // Returns the current rotation of the player around the x-axis
    public float GetRotation()
    {  
        if (transform.rotation.eulerAngles.x > 180) return transform.rotation.eulerAngles.x - 360;
        else return transform.rotation.eulerAngles.x;
    }

    // Applies the main propulsion force when the space key is held down
    private void MainPropulsion()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 force_final = force_up * transform.up * Time.deltaTime * 100;
            rb.AddForce(force_final, ForceMode.Force);
            FuelConsumption();
            Manager_Game.Instance.Score = fuel * 10;
        }
    }

    // Applies rotational forces when the W or S keys are held down
    private void RotationPropulsion()
    {
        Vector3 force_final = force_rotation * transform.up * Time.deltaTime * 100;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 force_position = transform.position + new Vector3(0, 0, -force_offset);
            rb.AddForceAtPosition(force_final, force_position, ForceMode.Force);
            FuelConsumption();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 force_position = transform.position + new Vector3(0, 0, force_offset);
            rb.AddForceAtPosition(force_final, force_position, ForceMode.Force);
            FuelConsumption();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 force_position = transform.position + new Vector3(-force_offset, 0, 0);
            rb.AddForceAtPosition(force_final, force_position, ForceMode.Force);
            FuelConsumption();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 force_position = transform.position + new Vector3(force_offset, 0, 0);
            rb.AddForceAtPosition(force_final, force_position, ForceMode.Force);
            FuelConsumption();
        }
    }

    //Qauntity : the amount of fuel to consume, default is 1 unit per second
    private void FuelConsumption(float quantity=1f)
    {
        fuel -= quantity * Time.deltaTime;
        Manager_Game.Instance.controller_HUD.UpdateFuel(fuel, max_fuel);
    }
}
