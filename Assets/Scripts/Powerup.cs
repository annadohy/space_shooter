using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField] // 0= TripleShot, 1=Speed, 2=Shield
    private int powerupID;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range (-8, 8), 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovements();
    }

    void CalculateMovements()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -5.5f)
        {
            Destroy (this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag== "Player")
        {
            Player player = other.transform.GetComponent<Player>();

           if (player != null)
           {
               switch (powerupID)
               {
                   case 0:
                        player.TripleShotActive();
                        break;
                   case 1:
                        player.SpeedIsActive();
                        break;
                   case 2:
                        player.ShieldIsActive();
                        break;
                   
                   default:
                        Debug.Log("Default value");
                        break;
               }
           }
           Destroy (this.gameObject);
        }

    }
}
