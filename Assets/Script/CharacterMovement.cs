using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool stayOnTheGround;
    private void Start()
    {
        Physics.gravity = new Vector3(0,-100,0);
    }
    public void MovementFunction(float speed)
    {
        transform.localPosition += new Vector3(0, 0, 10) * speed * Time.deltaTime;
    }
    public void JumpFunction()
    {
        if (stayOnTheGround) transform.localPosition += new Vector3(0, 0.1f, 0);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "ground")
        {
            stayOnTheGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "ground")
        {
            Invoke("SetBool", 0.2f);
        }
    }
    private void SetBool()
    {
        stayOnTheGround = false;
    }
}
