using UnityEngine;
using System.Collections;

public class CharaParam
{
	public string name { get; set; }
	public float range { get; set; }
}

//[RequireComponent(typeof(Animator))]
public class CharaControl : MonoBehaviour {

	public float m_fDistance;
	public int m_iTeamId;

	public CharaParam param = new CharaParam();

	public Vector3 m_vec3Dir;
	public GameObject m_goTarget;

	private GameObject m_goChara;
	private Animator animator;

	public float m_fSpeed;

	public float m_fTimer;

	public EnergyBar m_enegyBar;
	public GameObject m_goLifeGauge;

	public void Init( int _iTeamId , string _strName, GameObject _goTarget , GameObject _goRootLifeGauge )
	{
		string prefabName = string.Format("prefab/chara/{0}", _strName);

		m_goChara = PrefabManager.Instance.MakeObject(prefabName, gameObject);
		m_goChara.transform.localPosition = Vector3.zero;
		m_goChara.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

		m_goLifeGauge = PrefabManager.Instance.MakeObject("prefab/LifeGauge",_goRootLifeGauge);

		m_goLifeGauge.GetComponent<EnergyBarToolkit.EnergyBarFollowObject>().followObject = gameObject;
		m_enegyBar = m_goLifeGauge.GetComponent<EnergyBar>();
		m_enegyBar.SetValueF(100.0f);

		m_iTeamId = _iTeamId;
		Init(_strName, _goTarget, m_goChara.GetComponent<Animator>());

		param.name = _strName;
		param.range = 2.0f;
		CharaManager.Instance.Add(_iTeamId, this);
	}

	public void Init(string _strName, GameObject _goTarget, Animator _animator )
	{
		//animator = gameObject.GetComponent<Animator>();
		animator = _animator;
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

		m_eStep = STEP.WALK;
		m_eStepPre = STEP.MAX;

		/*
		// Zはマイナスじゃないと画面から見えないらしい
		transform.localScale = new Vector3(
			2.0f * 1.0f,
			2.0f,
			-1.0f
			);
			*/
	}


	public enum STEP
	{
		NONE			= 0,
		IDLE			,
		WALK			,
		ATTACK_START	,
		ATTACK			,
		DEAD			,
		END				,
		MAX				,
	};
	public STEP m_eStep;
	public STEP m_eStepPre;
	public float m_fTime;

	// Update is called once per frame
	void Update () {

		bool bInit = false;
		if( m_eStepPre != m_eStep)
		{
			m_eStepPre = m_eStep;
			bInit = true;
		}

		switch( m_eStep)
		{
			case STEP.IDLE:
				break;

			case STEP.WALK:
				if( bInit)
				{
					animator.SetBool("Idle", false);
					animator.SetBool("Walk", true);

					m_fSpeed = 0.01f;
					m_vec3Dir = m_goTarget.transform.position - gameObject.transform.position;
					m_vec3Dir = new Vector3(m_vec3Dir.x, m_vec3Dir.y, 0.0f);
					m_vec3Dir = m_vec3Dir.normalized;

					float fDir = 1.0f;
					if (0.0f < m_vec3Dir.x)
					{
						fDir = -1.0f;
					}

					// Zはマイナスじゃないと画面から見えないらしい
					m_goChara.transform.localScale = new Vector3(
						2.0f * fDir,
						2.0f,
						-1.0f
						);

				}
				gameObject.transform.localPosition = gameObject.transform.localPosition + (m_vec3Dir * m_fSpeed);

				float fDistTarget = Vector3.Distance(m_goTarget.transform.position, gameObject.transform.position);
				m_fDistance = fDistTarget;
				if ( fDistTarget < param.range)
				{
					m_eStep = STEP.ATTACK_START;
				}
				break;
			case STEP.ATTACK_START:
				if (bInit)
				{
					animator.SetBool("Walk", false);
					animator.SetBool("Attack", true);
				}
				AnimatorClipInfo clipInfoAttackStart = animator.GetCurrentAnimatorClipInfo(0)[0];
				if (clipInfoAttackStart.clip.name.Equals("Attack"))
				{
					m_eStep = STEP.ATTACK;
				}
				break;
			case STEP.ATTACK:
				if( bInit)
				{
					m_fTime = 0.0f;
				}
				m_fTime += Time.deltaTime;
				if(2.0f < m_fTime)
				{
					animator.SetBool("Attack", false);
					animator.SetBool("Idle", true);
					m_eStep = STEP.IDLE;
				}
				break;

			case STEP.DEAD:
				break;

			case STEP.MAX:
			default:
				break;
		}




		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
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
