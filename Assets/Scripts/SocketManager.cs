using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private GameObject socket;
    [SerializeField] private Button granadeBtn;
    [SerializeField] private TMP_Text btnTexxt;
    [SerializeField] private GameObject granadeImg;
    public int cooldown = 5;

    public void SetSocketActive(bool active)
    {
        socket.SetActive(active);
    }
    public void OnClickButton()
    {
        SetSocketActive(true);
        socket.GetComponent<CreateGranade>().CreatingGranade();
        granadeBtn.interactable = false;

        granadeImg.SetActive(false);
        StartCoroutine(CountSeconds(cooldown));

    }    
    IEnumerator CountSeconds(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Debug.Log($"초: {i}");
            btnTexxt.text = (cooldown-i+1).ToString();
            yield return new WaitForSeconds(1f);
        }
        granadeBtn.interactable = true;
        btnTexxt.text = "";
        granadeImg.SetActive(true);
        Debug.Log("카운트 완료!");
    }
}
