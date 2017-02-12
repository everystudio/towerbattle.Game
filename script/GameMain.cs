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

		m_btnSummonList[0].Initialize("alice",5);
		m_btnSummonList[1].Initialize("mister",10);
		m_btnSummonList[2].Initialize("", 0);
		m_btnSummonList[3].Initialize("", 0);
		m_btnSummonList[4].Initialize("", 0);
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
		string prefabName = string.Format("prefab/chara");

		if (_strName.Equals("alice"))
		{
			GameObject prefab = Resources.Load<GameObject>(prefabName);

			Vector3 pos = Vector3.zero;
			Quaternion rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

			//if (m_goHomeMine != null)
			{
				pos = m_goHomeMine.transform.localPosition;
				rot = m_goHomeMine.transform.rotation;
			}
			GameObject obj = Instantiate(prefab, pos, rot) as GameObject;
			obj.transform.parent = m_goHomeMine.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
			obj.transform.parent = Root.transform;

			CharaControl charaControl = obj.GetComponent<CharaControl>();
			/*
			*/
			//CharaControl charaControl = PrefabManager.Instance.MakeScript<CharaControl>(prefabName, m_goHomeMine);
			charaControl.Init(_strName, m_goHomeEnemy);
		}
		else
		{
			CharaControl charaControl = PrefabManager.Instance.MakeScript<CharaControl>(prefabName, m_goHomeMine);
			charaControl.gameObject.transform.localPosition = Vector3.zero;
			charaControl.gameObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

			charaControl.gameObject.transform.parent = Root.transform;
			charaControl.Init(_strName, m_goHomeEnemy);

		}

	}
}
