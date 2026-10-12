using UnityEngine;

public class itemTrigger : MonoBehaviour
{
    public player Player;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger detected with: " + other.gameObject.name);
            Destroy(gameObject);
            Player= other.GetComponent<player>();
            Player.itemCollected++;
        }
    }
}
