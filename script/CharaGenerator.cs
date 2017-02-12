using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaGenerator : MonoBehaviour {

	[SerializeField]
	private int m_iTeamId;

	[SerializeField]
	private GameObject m_goRoot;

	[SerializeField]
	private GameObject m_goHome;

	[SerializeField]
	private GameObject m_goTarget;

	void Awake()
	{
		m_iIndex = 101;
		dummyGenerate();
		Invoke("dummyGenerate", 5.0f);
	}


	private int m_iIndex;
	private void dummyGenerate()
	{

		string name = string.Format("ch{0:D3}", m_iIndex);
		createChara(name, 10);
		m_iIndex += 1;
		if( 115 < m_iIndex)
		{
			m_iIndex = 101;
		}
		Invoke("dummyGenerate", 5.0f);
	}

	private void createChara(string _strName, int _iCost)
	{
		//Debug.LogError(string.Format("name:{0} const:{1}", _strName, _iCost));
		string prefabName = string.Format("prefab/chara/{0}", _strName);
		//Debug.Log(string.Format("prefabname:{0}", prefabName));

		CharaControl charaControl = PrefabManager.Instance.MakeScript<CharaControl>(prefabName, m_goHome);
		//Debug.Log(charaControl);
		charaControl.gameObject.transform.localPosition = Vector3.zero;
		charaControl.gameObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

		charaControl.gameObject.transform.parent = m_goRoot.transform;
		charaControl.Init(_strName, m_goTarget);

	}


	public string hash = "";
	void Update()
	{
		//Debug.Log(Animator.StringToHash(hash));
		//284181959
		return;

	}


}
