using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<Skill> deck;
    [SerializeField] private List<Skill> skills;
    [SerializeField] private SkillButton _skillButton;
    [SerializeField] private List<Transform> _buttonPosition;
    [SerializeField] private Player _player;
    [SerializeField] private SlashManager _slashManager;
    [SerializeField] private SkullManager _skullManager;
    [SerializeField] private MagicManager _magicManager;
    [SerializeField] private HPbar _hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RandomSkillButton()
    {
        deck = new List<Skill>(skills);
        for (int i = 0; i < 2; i++)
        {
            Instantiate(_skillButton.gameObject, _buttonPosition[i]);
            _skillButton._skill = deck[Random.Range(0, skills.Count)];
            deck.Remove(_skillButton._skill);
        }
    }

    public void SkillUp(skillgrop grop)
    {
        RemoveSkillButton();
        switch (grop)
        {
            case skillgrop.attack:
                break;
            case skillgrop.slash:
                _slashManager.SkillLevelBounas();
                break;
            case skillgrop.skull:
                _skullManager.SkillLevelBounas();
                break;
            case skillgrop.heal:
                _hp.PlusHP();
                break;
            case skillgrop.magic:
                _magicManager.SkillLevelBounas();
                break;
        }
    }

    public void RemoveSkillButton()
    {
        foreach (var position in _buttonPosition)
        {
            foreach (Transform button in position)
            {
                Destroy(button.gameObject);
                Time.timeScale = 1.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
