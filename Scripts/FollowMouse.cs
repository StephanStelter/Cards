using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{


    void Update()
    {
         transform.position = Input.mousePosition;
    }
}
