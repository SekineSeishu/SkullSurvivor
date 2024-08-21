using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<Skill> deck;//�c���Ă���X�L�����X�g(�������烉���_���ɑI��)
    [SerializeField] private List<Skill> skills;//�S�ẴX�L��
    [SerializeField] private SkillButton _skillButton;//���x���A�b�v�{�^��
    [SerializeField] private List<Transform> _buttonPosition;//�{�^�������ʒu
    [SerializeField] private Player _player;
    [SerializeField] private SlashManager _slashManager;//�a��
    [SerializeField] private SkullManager _skullManager;//�X�J��
    [SerializeField] private MagicManager _magicManager;//���@�w
    [SerializeField] private HPbar _hp;

    private int _selectNum = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RandomSkillButton()
    {
        //�S�ẴX�L������x�f�b�L�ɓ����
        deck = new List<Skill>(skills);
        foreach (Skill skill in deck)
        {
            //�ő僌�x���̎��̓f�b�L����O��
            if (skill._skillLevel == skill._maxSkillLevel)
            {
                deck.Remove(skill);
            }
        }
        //�f�b�L���烉���_���ȃX�L���̃��x���A�b�v�{�^���𐶐�����
        //���������X�L���̓f�b�L����O��
        for (int i = 0; i < _selectNum; i++)
        {
            Instantiate(_skillButton.gameObject, _buttonPosition[i]);
            _skillButton._skill = deck[Random.Range(0, skills.Count)];
            deck.Remove(_skillButton._skill);
        }
    }

    public void SkillUp(skillgrop grop)
    {
        //�X�L���{�^��������
        RemoveSkillButton();
        //�X�L���̎�ނɉ����ď������s��
        switch (grop)
        {
            case skillgrop.attack:
                _player._attack += 0.5f;
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
