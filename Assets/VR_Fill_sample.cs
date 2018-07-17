using UnityEngine;
using System.Collections;

public class VR_Fill_sample : MonoBehaviour
{
    public VRLookAtObjectBase vrLookAtObjectBase;

    void Awake()
    {
        vrLookAtObjectBase = GetComponent<VRLookAtObjectBase>();
    }

    void OnEnable()
    {
        vrLookAtObjectBase.ButtonFillFinish += ButtonFillFinish;
    }

    void OnDisable()
    {
        vrLookAtObjectBase.ButtonFillFinish -= ButtonFillFinish;
    }

    int targetCanvas = 0;
    public UnityEngine.UI.CanvasScaler[] canvasScaler;

    Coroutine changeCanvasProcess;
    void ButtonFillFinish()
    {
        //Debug.LogWarning("================================???? ");

        if (changeCanvasProcess != null)
            StopCoroutine(changeCanvasProcess);

        changeCanvasProcess = StartCoroutine(ChangeCanvasProcess());
    }

    IEnumerator ChangeCanvasProcess()
    {
        float sec = 2.0f;
        float deltaTime = 0.0f;
        while (canvasScaler[targetCanvas].dynamicPixelsPerUnit > 0)
        {
            deltaTime += Time.deltaTime;

            canvasScaler[targetCanvas].dynamicPixelsPerUnit = Mathf.Lerp(4, 0, deltaTime / sec);
            yield return new WaitForEndOfFrame();
        }

        ++targetCanvas;
        targetCanvas %= 2;

        yield return new WaitForSeconds(0.5f);

        deltaTime = 0.0f;
        canvasScaler[targetCanvas].dynamicPixelsPerUnit = 0;

        while (canvasScaler[targetCanvas].dynamicPixelsPerUnit < 4)
        {
            deltaTime += Time.deltaTime;

            canvasScaler[targetCanvas].dynamicPixelsPerUnit = Mathf.Lerp(0, 4, deltaTime / sec);
            yield return new WaitForEndOfFrame();
        }
    }
}