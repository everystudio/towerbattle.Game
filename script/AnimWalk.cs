using UnityEngine;
using System.Collections;

public class AnimWalk : MonoBehaviour {

	public string chara_name;

	public float m_fTimer;
	public float m_fTimerInterval;

	public int m_iAnimationIndex;
	public int m_iAnimationIndexMax;

	[SerializeField]
	private SpriteRenderer m_sprRenderer;

	// Use this for initialization
	void Start () {
		m_fTimerInterval = 1.0f;
		m_iAnimationIndexMax = 2;
	}
	public void Init( string _strCharaName)
	{
		chara_name = _strCharaName;
		UpdateSprite(m_iAnimationIndex);
	}
	private void UpdateSprite(int _iAnimationIndex)
	{
		//string strSpriteName = string.Format("chara/{0}_{1:D2}", chara_name, _iAnimationIndex + 3);

		/*
		Sprite sprSprite = null;
		if (SpriteManager.spriteDict.TryGetValue(strSpriteName, out sprSprite))
		{
			m_sprRenderer.sprite = sprSprite;
		} 
		*/

	}

	// Update is called once per frame
	void Update () {

		m_fTimer += Time.deltaTime;
		if( m_fTimerInterval < m_fTimer)
		{
			m_iAnimationIndex = m_iAnimationIndexMax <= m_iAnimationIndex + 1 ? 0 : m_iAnimationIndex + 1;
			m_fTimer -= m_fTimerInterval;
			UpdateSprite(m_iAnimationIndex);
		}

	
	}
}
