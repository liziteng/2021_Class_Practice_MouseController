using UnityEngine;

public class RayDector : MonoBehaviour
{
    public Vector3 hitPosition;
    private LayerMask mask;
    private Camera cam;

    private void Start()
    {
        mask = 1 << 9;
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        ControllerFunction();
    }

    private void ControllerFunction()
    {
        RayCastFunction();
    }

    private void RayCastFunction()
    {
        var startPoint = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(startPoint, out hit, Mathf.Infinity, mask))
        {
            var function = hit.transform.GetComponent<ISelectedFunction>();
            hitPosition = hit.point;

            if (Input.GetMouseButtonDown(0))
                if (function != null) function.SelectedFunction();
            if (Input.GetMouseButtonUp(0))
                if (function != null) function.UnSelectedFunction();
            if (Input.GetMouseButton(0))
                if (function != null) function.HoldingFunction();
        }
    }
}
