using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPause : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    public TransitionUI trans;

    RectTransform rect;
    CanvasGroup cGroup;
    float vitPauseMouv;

    public bool open = false;
    Vector2 posDepart, posFin;
    float delaiCour = 1;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        cGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (delaiCour >= 1)
            return;

        delaiCour += Time.deltaTime * vitPauseMouv;
        if (delaiCour > 1)
        {
            if (open)
                Time.timeScale = 0.000001f;
            delaiCour = 1;
        }
            

        rect.position = Vector2.Lerp(posDepart, posFin, delaiCour);
        if (open)
            cGroup.alpha = delaiCour;
        else
            cGroup.alpha = 1 - delaiCour;
    }

    public void ChangeScene(string sceneName)
    {
        Hide();
        StartCoroutine(ChangeCurrentScene(sceneName));
    }

    public void Show(bool inputKeyboard)
    {
        open = true;
        cGroup.interactable = true;
        Third_person_mvmnt.paused = true;

        vitPauseMouv = 20f;
        posDepart = new Vector2(-300, 0);
        posFin = new Vector2(0, 0);
        delaiCour = 0.99f;
        Time.timeScale = 0.001f;

        GetComponentInChildren<BasePause>().Open();
        GetComponentInChildren<OptionsMenu>().Close();
    }

    public void Hide()
    {
        cGroup.interactable = false;
        Third_person_mvmnt.paused = false;
        open = false;

        vitPauseMouv = 8f;
        posFin = new Vector2(-300, 0);
        posDepart = rect.position;
        delaiCour = 0;
        Time.timeScale = 1f;
    }

    public void DisconnectEveryone()
    {
        //foreach (var player in FindObjectsOfType<PlayerInput>())
        //{
        //    Destroy(player.gameObject);
        //}
        //PlayerManager.instance.players.Clear();
    }

    IEnumerator ChangeCurrentScene(string scene)
    {
       // if (scene == "MainMenu")
            //DisconnectEveryone();
        trans.Transition(new Vector2(0, 1200), new Vector2(0, 0), false);
        yield return new WaitForSeconds(0.6f);
        this.posDepart = new Vector2(0, 0);
        this.posFin = new Vector2(0, 0);
        rect.localPosition = new Vector2(0, 0);
        SceneManager.LoadScene(scene);
        this.posDepart = new Vector2(0, 0);
        this.posFin = new Vector2(0, 0);
        rect.localPosition = new Vector2(0, 0);
        for (int i = 0; i < 40; i++)
        {
            trans.Transition(new Vector2(0, 0), new Vector2(0, 0), false);
            yield return new WaitForSeconds(0.01f);
            rect.localPosition = new Vector2(0, 0);
        }
       // yield return new WaitForSeconds(0.6f);
        trans.Transition(new Vector2(0, 0), new Vector2(0, -1200), false);
    }
}
