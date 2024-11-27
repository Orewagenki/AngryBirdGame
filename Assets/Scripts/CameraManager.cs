using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _idleCam;
    [SerializeField] private CinemachineVirtualCamera _followCam;


    private void Awake()
    {
        SwitchToIdleCam();
    }

    public void SwitchToIdleCam()
    {
        _idleCam.enabled = true;
        _followCam.enabled = false;

    }

    public void SwitchToFollowCam(Transform followTransfrom)
    {
        _followCam.Follow = followTransfrom;

        _idleCam.enabled = false;
        _followCam.enabled = true;

    }
}

