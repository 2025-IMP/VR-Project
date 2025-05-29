using UnityEngine;
using UnityEngine.UIElements;

public class RailGun : MonoBehaviour
{
    [SerializeField] private Transform shootTansform;
    [SerializeField] private GameObject boolet;
    public void Shoot()
    {
        Instantiate(boolet, shootTansform.position, shootTansform.rotation);
    }

    void Start()
    {
         Shoot();
    }
}
