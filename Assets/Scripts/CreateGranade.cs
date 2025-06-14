using Unity.VisualScripting;
using UnityEngine;

public class CreateGranade : MonoBehaviour
{
    [SerializeField] private GameObject granade;

    void Start()
    {
        //CreatingGranade();
        Debug.Log("start");
    }
    public void CreatingGranade()
    {
        Instantiate(granade, transform.position, transform.rotation);
    }
    public void SocketSelectExit()
    {
        gameObject.SetActive(false);
    }
}
