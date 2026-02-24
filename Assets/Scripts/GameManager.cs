using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int m_FoodAmount = 100;

    public static GameManager instance { get; private set;}

    public BoardManager boardManager;
    public PlayerController playerController;

    public UIDocument UIDoc;
    private Label m_FoodLabel;

    public TurnManager turnManager {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_FoodLabel = UIDoc.rootVisualElement.Q<Label>("FoodLabel");
        m_FoodLabel.text = "Food: " + m_FoodAmount;

        turnManager = new TurnManager();
        turnManager.OnTick += OnTurnHappen;

        boardManager.Init();
        playerController.Spawn(boardManager, new Vector2Int(3, 3));
    }

    void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        m_FoodLabel.text = "Food: " + m_FoodAmount;
    }
}
