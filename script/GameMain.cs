using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	public GameObject Root;

	public GameObject m_goHomeMine;
	public GameObject m_goHomeEnemy;
	[SerializeField]
	private GameObject m_goRootLifeGauge;

	public List<ButtonSummon> m_btnSummonList = new List<ButtonSummon>();

	// Use this for initialization
	void Start () {

		m_btnSummonList[0].Initialize("ch010",5);
		m_btnSummonList[1].Initialize("ch020",10);
		m_btnSummonList[2].Initialize("ch030", 5);
		m_btnSummonList[3].Initialize("ch040", 5);
		m_btnSummonList[4].Initialize("ch050", 5);
		foreach( ButtonSummon btnSummon in m_btnSummonList)
		{
			btnSummon.OnCreateRequest.AddListener(createChara);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createChara( string _strName , int _iCost)
	{
		CharaControl charaControl = PrefabManager.Instance.AddGameObject<CharaControl>(m_goHomeMine);

		charaControl.gameObject.transform.parent = Root.transform;

		charaControl.Init(0,_strName, m_goHomeEnemy, m_goRootLifeGauge);

	}
}
