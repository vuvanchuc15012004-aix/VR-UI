using UnityEngine;

public class InteractableLesson : MonoBehaviour
{
    public GameObject pressEText;

    public GameObject panel1;
    public GameObject panel2;

    private bool playerInRange = false;
    private bool isOpen = false;

    void Start()
    {
        pressEText.SetActive(false);
        panel1.SetActive(false);
        panel2.SetActive(false);
    }

    void Update()
    {
        if (isOpen) return;

        if (playerInRange)
        {
            pressEText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel1();
            }
        }
    }

    void OpenPanel1()
    {
        isOpen = true;

        panel1.SetActive(true);
        panel2.SetActive(false);
        pressEText.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DisablePlayer(true);
    }

    // 👉 GỌI KHI BẤM NEXT
    public void NextPanel()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    // 👉 GỌI KHI BẤM CLOSE
    public void CloseLesson()
    {
        isOpen = false;

        panel1.SetActive(false);
        panel2.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        DisablePlayer(false);

        if (playerInRange)
        {
            pressEText.SetActive(true);
        }
    }

    void DisablePlayer(bool disable)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            var movement = player.GetComponent<PlayerMovement>();
            if (movement != null)
                movement.enabled = !disable;

            var mouseLook = player.GetComponentInChildren<MouseLook>();
            if (mouseLook != null)
                mouseLook.enabled = !disable;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (!isOpen)
                pressEText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            pressEText.SetActive(false);
        }
    }
}