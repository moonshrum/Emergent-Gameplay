using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIExclusion : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = gameObject.GetComponent<Camera>();

        if (PlayerInput.GetPlayerByIndex(1).transform == gameObject.GetComponentInParent<Transform>())
        {
            _camera.cullingMask ^= 1 << LayerMask.NameToLayer("P1 UI");
            _camera.cullingMask ^= 1 << LayerMask.NameToLayer("P2 UI");
        }
    }
}
