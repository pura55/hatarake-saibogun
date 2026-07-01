using UnityEngine;

public class PlayerHitWall : MonoBehaviour
{

    #region State
    [SerializeField] private bool isCollidingWithWall = false;
    #endregion

    #region Public Methods
    public bool GetIsCollidingWithWall() { return isCollidingWithWall; }
    #endregion
    void Start()
    {
        
    }

    private void Update()
    {
        isCollidingWithWall = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Ç‘Ç¬Ç©Ç¡ÇΩëäéË: " + col.gameObject.name);
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("ï«Ç…Ç‘Ç¬Ç©Ç¡ÇΩÅI");
            isCollidingWithWall = true;
        }
    }
}
