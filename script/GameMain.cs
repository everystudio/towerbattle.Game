using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	public GameObject Root;

	public GameObject m_goHomeMine;
	public GameObject m_goHomeEnemy;

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
		//Debug.LogError(string.Format("name:{0} const:{1}", _strName, _iCost));
		string prefabName = string.Format( "prefab/chara/{0}", _strName );
		//Debug.Log(string.Format("prefabname:{0}", prefabName));

		CharaControl charaControl = PrefabManager.Instance.MakeScript<CharaControl>(prefabName, m_goHomeMine);
		//Debug.Log(charaControl);
		charaControl.gameObject.transform.localPosition = Vector3.zero;
		charaControl.gameObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

		charaControl.gameObject.transform.parent = Root.transform;
		charaControl.Init(_strName, m_goHomeEnemy);

	}
}
