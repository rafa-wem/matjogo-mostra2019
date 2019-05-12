using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Agent owner;
    public Vector3 direction;
    public float speed;
    public float damage;

    private bool _myIsInitialized = false;
    private CharacterController _myCharacterController;
    private CF_GameController _myGameController;

    // Start is called before the first frame update
    void Start()
    {
        _myGameController = GameObject.FindObjectOfType<CF_GameController>();
        _myCharacterController = GetComponent<CharacterController>();
    }
    public void Initialize(Agent owner, Vector3 direction, float spd, float dmg, float duration)
    {
        this.owner = owner;
        this.direction = direction.normalized;
        this.speed = spd;
        this.damage = dmg;

        _myIsInitialized = true;

        Invoke("DestroySelf", duration);
    }

    void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(_myIsInitialized)
        {
            _myCharacterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
