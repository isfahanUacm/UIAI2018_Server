using UnityEngine;

public class FallowMouse : MonoBehaviour {

    private float zOffset = -0.5f; //fixed position on Z axis.

    void Start()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         zOffset);
        //transform.position.z = zOffset; //apply fixed offset
    }

    private Vector3 tmpPosition;
    void Update()
    {
        //get mouse position in game scene.
        tmpPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                    Input.mousePosition.y,
                                                                    10));
        //follow the mouse
        transform.position = new Vector3(tmpPosition.x,
                                            tmpPosition.y,
                                            zOffset);
    }
}
