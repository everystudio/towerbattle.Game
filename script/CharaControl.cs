using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class CharaControl : MonoBehaviour {

	public int m_iTeamId;

	public Vector3 m_vec3Dir;
	public GameObject m_goTarget;

	private Animator animator;

	public float m_fSpeed;

	public float m_fTimer;

	public void Init( int _iTreamId , string _strName, GameObject _goTarget)
	{
		m_iTeamId = _iTreamId;
		Init(_strName, _goTarget);
	}

	public void Init(string _strName, GameObject _goTarget )
	{
		animator = gameObject.GetComponent<Animator>();
		string strAnimator = "";
		if( DataManager.Instance.GetAnimatorName(_strName, out strAnimator))
		{
			animator.runtimeAnimatorController = (RuntimeAnimatorController)Instantiate(Resources.Load(strAnimator));
		}

		//animWalk.Init(_strName);
		transform.localPosition = new Vector3(
			transform.localPosition.x,
			transform.localPosition.y,
			transform.localPosition.z - 1.0f
			);
		m_goTarget = _goTarget;

		animator.SetBool("Idle", false);
		animator.SetBool("Walk", true);

		m_fSpeed = 0.01f;
		m_vec3Dir = m_goTarget.transform.localPosition - gameObject.transform.localPosition;
		m_vec3Dir = new Vector3(m_vec3Dir.x, m_vec3Dir.y, 0.0f);
		m_vec3Dir = m_vec3Dir.normalized;

		float fDir = 1.0f;
		if( 0.0f < m_vec3Dir.x)
		{
			fDir = -1.0f;
		}

		// Zはマイナスじゃないと画面から見えないらしい
		transform.localScale = new Vector3(
			2.0f * fDir,
			2.0f,
			-1.0f
			);


	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition = gameObject.transform.localPosition + (m_vec3Dir * m_fSpeed);


		AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
		if (state.fullPathHash == Animator.StringToHash("Base Layer.Walk"))
		{
			//Debug.LogError("itti");
		}
		else {
			//Debug.Log(string.Format("not:{0}", state.fullPathHash));
		}

		//AnimatorClipInfo clipInfo = animator.GetCurrentAnimatorClipInfo(0)[0];
		//Debug.Log("アニメーションクリップ名 : " + clipInfo.clip.name);

	}
}
