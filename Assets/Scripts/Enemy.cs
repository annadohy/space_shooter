using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range (-8, 8), 7, 0);
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is NULL");
        }
        _animator = GetComponent<Animator>();

        if(_animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
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
            transform.position = new Vector3(Random.Range (-8, 8), 7, 0);

        }
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
           // damage player

           Player player = other.transform.GetComponent<Player>();

           if (player != null)
           {
               player.Damage();
           }
           
           _animator.SetTrigger("OnEnemyDeath");
           _speed = 1f;
           Destroy (this.gameObject, 2.8f);
       }

       if(other.tag == "Laser")
       {
           Destroy (other.gameObject);
           if (_player != null)
           {
               _player.AddScore(10);
           }
           _animator.SetTrigger("OnEnemyDeath");
           _speed = 1f;
           Destroy (this.gameObject, 2.8f);
       }
   }
}
