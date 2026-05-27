using UnityEngine;

public class PassRP : MonoBehaviour
{
    public RelayPointStatus relayPointStatus;
    private Transform targetPlatelet;
    PlateletMove plateletMove;
    int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(relayPointStatus.GetIsPass())
        {
            if(count == 0)
            {
                plateletMove.ResetRelayPoint();
            }
            count++;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Platelet"))
         {
            Debug.Log("リレーポイントを通過した");
            if (!relayPointStatus.GetIsPass())
            {
                relayPointStatus.SetTrueIsPass();
                plateletMove = col.GetComponent<PlateletMove>();
            }
         }
    }
}
