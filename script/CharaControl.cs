using UnityEngine;
using System.Collections;

public class CharaControl : MonoBehaviour {

	public Vector3 m_vec3Dir;
	public GameObject m_goTarget;

	public Animator animator;

	public float m_fSpeed;

	public float m_fTimer;

	public void Init(string _strName, GameObject _goTarget )
	{
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
	}
}
