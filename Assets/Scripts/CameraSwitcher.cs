using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;
    private Queue<CinemachineVirtualCamera> _camerasQueue;

    private CinemachineVirtualCamera _currentCamera;

    private readonly KeyCode SwitchCameraInput = KeyCode.F;

    private void Awake()
    {
        _camerasQueue = new Queue<CinemachineVirtualCamera>(_cameras);
        SwitchNext();
    }

    private void Update()
    {
        if(Input.GetKeyDown(SwitchCameraInput))
        {
            SwitchNext();
        }
    }

    private void SwitchNext()
    {
        CinemachineVirtualCamera nextCamera = _camerasQueue.Dequeue();
        
        foreach(CinemachineVirtualCamera camera in _camerasQueue)
        {
            camera.gameObject.SetActive(false);
        }

        nextCamera.gameObject.SetActive(true);

        _camerasQueue.Enqueue(nextCamera);
    }
}
