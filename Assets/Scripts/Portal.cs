using UnityEngine;
using UnityEngine.SceneManagement;

namespace IMP.Core
{
    public class Portal : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Game");
        }
    }
}
