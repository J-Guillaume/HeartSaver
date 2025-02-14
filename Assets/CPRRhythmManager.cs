using UnityEngine;
using UnityEngine.InputSystem;

public class CPRRhythmManager : MonoBehaviour
{
    [Header("BPM Settings")]
    public float targetBPM = 110f;
    public float acceptableDeviation = 10f;

    [Header("Dependencies")]
    public Animator nurseAnimator;
    public GameObject dummy;

    [Header("Feedback")]
    public TMPro.TextMeshPro feedbackText;

    private float lastPumpTime = 0f;
    private float currentBPM = 0f;

    private CPRInputActions inputActions; // Initialize CPR Input Actions

    void Awake()
    {
        inputActions = new CPRInputActions(); // Correctly initialize input actions
    }

    void OnEnable()
    {
        inputActions.CPRControls.Enable();
        inputActions.CPRControls.PumpAction.performed += ctx => RegisterPump();
    }

    void OnDisable()
    {
        inputActions.CPRControls.PumpAction.performed -= ctx => RegisterPump();
        inputActions.CPRControls.Disable();
    }

    void RegisterPump()
    {
        float currentTime = Time.time;
        if (lastPumpTime > 0)
        {
            float timeDifference = currentTime - lastPumpTime;
            currentBPM = 60f / timeDifference;

            CheckRhythm();
        }

        lastPumpTime = currentTime;

        // Trigger the nurse pumping animation
        if (nurseAnimator != null)
        {
            nurseAnimator.SetTrigger("Pump");
        }
    }

    void CheckRhythm()
    {
        if (feedbackText == null)
        {
            Debug.LogError("feedbackText is not assigned in the Inspector!");
            return;
        }

        if (currentBPM < targetBPM - acceptableDeviation)
        {
            feedbackText.text = "Too Slow";
            feedbackText.color = Color.red;
        }
        else if (currentBPM > targetBPM + acceptableDeviation)
        {
            feedbackText.text = "Too Fast";
            feedbackText.color = Color.red;
        }
        else
        {
            feedbackText.text = "Good";
            feedbackText.color = Color.green;
        }

        Debug.Log($"Current BPM: {currentBPM}, Feedback: {feedbackText.text}");
    }
}
