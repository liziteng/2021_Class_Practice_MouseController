using UnityEngine;
using UnityEngine.Events;

public class ButtonFunction : MonoBehaviour, ISelectedFunction
{
    public UnityEvent ButtonPressedFunction, ButtonUnPressedFunction, ButtonHoldFunction;

    private CharacterMovement character;
    private void Start()
    {
        character = FindObjectOfType<CharacterMovement>();
    }

    public void HoldingFunction()
    {
        ButtonHoldFunction.Invoke();
    }

    public void SelectedFunction()
    {
        transform.position = new Vector3(transform.localPosition.x, -0.1f, transform.localPosition.z);
        ButtonPressedFunction.Invoke();
    }

    public void UnSelectedFunction()
    {
        transform.position = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
        ButtonUnPressedFunction.Invoke();
    }
}
