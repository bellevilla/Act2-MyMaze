using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public TMP_Text countText;

    void Start()
    {
       rb = GetComponent<Rigidbody>();

        count = 0;
        CountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            CountText();
        }
        if (other.gameObject.tag =="hazard")
        {
            other.gameObject.SetActive(false);
            Vector3 jump = new Vector3(0.0f, 150, 0.0f);
            rb.AddForce(jump*speed*Time.deltaTime);
        }
    }

    void CountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f ,moveVertical);

        rb.AddForce(movement*speed*Time.deltaTime);
    }
}
