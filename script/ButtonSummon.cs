using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class ButtonSummon : MonoBehaviour {

	[SerializeField]
	private Image m_imgIcon;

	public string m_strCharaName;
	public int m_iCost;

	void Start()
	{
		GetComponent<Button>().onClick.AddListener(() =>{
			if (0 < m_iCost)
			{
				OnCreateRequest.Invoke(m_strCharaName, m_iCost);
			}
		});
	}

	public void Initialize( string _strCharaName , int _iCost)
	{
		m_strCharaName = _strCharaName;
		m_iCost = _iCost;
		Sprite spr = SpriteManager.Instance.LoadSprite(string.Format("texture/icon/{0}_icon", m_strCharaName));
		m_imgIcon.sprite = spr;
	}

	// Update is called once per frame
	void Update () {
	}

	[System.Serializable]
	public class UnityEventCreateRequest : UnityEvent<string, int>
	{
	}
	public UnityEvent gomi = new UnityEvent();
	public UnityEventCreateRequest OnCreateRequest = new UnityEventCreateRequest();




}
