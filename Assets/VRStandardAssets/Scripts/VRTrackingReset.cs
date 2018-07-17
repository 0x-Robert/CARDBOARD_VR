using UnityEngine;
using UnityEngine.VR;

namespace VRStandardAssets.Utils
{
    // This class simply insures the head tracking behaves correctly when the application is paused.
    public class VRTrackingReset : MonoBehaviour
    {
        private void OnApplicationPause(bool pauseStatus)
        {
            InputTracking.Recenter();
        }

        //public void Update()
        //{
        //    transform.position = InputTracking.GetLocalPosition(VRNode.Head);
        //}
    }
}