using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaManager : Singleton<CharaManager> {

	public Dictionary<int, List<CharaControl>> member = new Dictionary<int, List<CharaControl>>();

	private bool m_bShowLog;

	public override void Initialize()
	{
		base.Initialize();
		member.Clear();
	}

	public bool Add( int _iTeamId , CharaControl _chara)
	{
		bool bRet = true;

		List<CharaControl> chara_list = null;

		if( member.TryGetValue(_iTeamId , out chara_list ))
		{
			if( chara_list.Contains(_chara))
			{
				bRet = false;
			}
			else
			{
				chara_list.Add(_chara);
			}
		}
		else
		{
			member.Add(_iTeamId, new List<CharaControl> { _chara });
		}

		foreach( int teamId in member.Keys)
		{
			if (member.TryGetValue(teamId, out chara_list))
			{
				foreach(CharaControl chara in chara_list)
				{
					//Debug.Log(string.Format("teamId:{0} chara:{1}",teamId,chara.param.name));
				}
			}
		}

		return bRet;
	}

	public bool Remove( int _iTeamId , CharaControl _chara)
	{
		bool bRet = false;
		List<CharaControl> chara_list = null;

		if (member.TryGetValue(_iTeamId, out chara_list))
		{
			bRet = chara_list.Remove(_chara);
		}
		return bRet;
	}
}





