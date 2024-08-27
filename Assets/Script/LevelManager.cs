using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image _levelber;//���x���o�[�摜
    [SerializeField] private TMP_Text _levelText;//���x���\���e�L�X�g
    [SerializeField] private int _levelUpExp;//���x���A�b�v�ɕK�v�Ȍo���l��
    public int _level;//���݂̃��x��
    public int _exp;//���݂̌o���l
    [SerializeField] private Player _player;
    private float _attackUp = 0.2f;//���x�����Ƃɏオ��v���C���[�̍U����
    [SerializeField] private HPbar _hpBar;//HP�o�[
    [SerializeField] private SkillManager _skillManager; //�X�L���}�l�[�W���[


    // Start is called before the first frame update
    void Start()
    {
        //������
        _exp = 0;
        _levelUpExp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //���x�����オ�����ۂɃ��x���{�[�i�X�̕\���ƕK�v�o���l�ƃv���C���[�ƓG�̍U���͂̑���
        _levelber.fillAmount = (float)_exp / _levelUpExp;

        _levelText.SetText("Lv" + _level);

        if (_exp == _levelUpExp)
        {
            Time.timeScale = 0;
            _skillManager.RandomSkillButton();
            _level++;
            _levelUpExp += 8;
            _player._attack += _attackUp;
            _hpBar._enemydamage += 1;
            _exp = 0;
        }
        
    }

}
