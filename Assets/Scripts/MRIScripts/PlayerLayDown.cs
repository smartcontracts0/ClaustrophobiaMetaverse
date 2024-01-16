using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLayDown : MonoBehaviour
{
    private bool isLaidDown = false;
    private bool isInMRI = false;
    private float countdownTimer = 0f;
    public float maxTimerDuration = 60f;
    public TextMeshProUGUI timerText;
    public MRIAccess mriAccess; // Reference to the MRIAccess script
    public FirstPersonCamera firstPersonCamera;

    void Update()
    {
        // Check for other actions in Update if needed

        if (isLaidDown && isInMRI)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0f)
            {
                CompleteMRISession();
            }

            UpdateTimerText();
        }

        if (Input.GetKeyDown(KeyCode.F) && !isLaidDown && !isInMRI)
        {
            // Check if the player is within the MRI trigger zone
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("MRI"))
                {
                    EnterMRI();
                    break; // Exit the loop after finding the MRI trigger
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isInMRI)
        {
            LeaveMRI();
        }
    }

    void LeaveMRI()
    {
        transform.position = new Vector3(-1.13f, 0.35f, 0.46f);
        transform.rotation = Quaternion.Euler(0.472f, 75f, 1.7f);
        isLaidDown = false;
        isInMRI = false;
        countdownTimer = 0f;
        timerText.gameObject.SetActive(false);

        // Show the message in MRIAccess script and hide the new message
        mriAccess.SetPlayerInsideMRI(false);

        // Enable player movement
        firstPersonCamera.EnableMovement();
    }

    void CompleteMRISession()
    {
        Debug.Log("Congrats! You've completed the MRI session. Press C to claim your reward.");
        SceneManager.LoadScene("Reward");
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Ceil(countdownTimer).ToString("0");
        }
    }

    void EnterMRI()
    {
        transform.rotation = Quaternion.Euler(1.8f, -84.085f, 0f);
        transform.position = new Vector3(0.35f, 0.35f, 0f);
        isLaidDown = true;
        isInMRI = true;
        countdownTimer = maxTimerDuration;
        timerText.gameObject.SetActive(true);
        UpdateTimerText();

        // Hide the message in MRIAccess script and show the new message
        mriAccess.SetPlayerInsideMRI(true);

        // Disable player movement
        firstPersonCamera.DisableMovement();
    }
}