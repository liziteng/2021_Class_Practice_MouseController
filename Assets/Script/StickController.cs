using UnityEngine;

public class StickController : MonoBehaviour, ISelectedFunction
{
    private RayDector ray;
    private CharacterMovement character;
    private Camera cam;
    private bool unselected;
    public GameObject pedestal;
    private void Start()
    {
        ray = FindObjectOfType<RayDector>();
        character = FindObjectOfType<CharacterMovement>();
        cam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        AngleReset();
    }

    private void AngleReset()
    {
        unselected = true;
        if (unselected)
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, Time.deltaTime * 100);
    }

    public void SelectedFunction()
    {
    }

    public void UnSelectedFunction()
    {
    }

    public void HoldingFunction()
    {
        unselected = false;
        RotateFunction();
        CharatcerMovingFunction();
    }

    private void RotateFunction()
    {
        var pos = ray.hitPosition;
        var x = transform.position.x;
        var y = Input.mousePosition.y - pos.y;
        var z = Input.mousePosition.z - pos.z;
        var angle = Mathf.Atan2(y, z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle * 100, transform.right);
    }
    
    private void CharatcerMovingFunction()
    {
        var speed = Vector3.Cross(pedestal.transform.up,transform.up);
        character.MovementFunction(speed.x);
        print(speed);
    }
}
