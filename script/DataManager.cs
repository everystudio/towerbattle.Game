using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : DataManagerBase<DataManager>{

	public override void Initialize()
	{
		base.Initialize();
		setup_animator();
	}

	public bool GetAnimatorName( string _chara , out string _animator)
	{
		bool bRet = false;

		if( AnimatorDict.TryGetValue(_chara , out _animator))
		{
			bRet = true;
		}

		return bRet;
	}

	public Dictionary<string, string> AnimatorDict = new Dictionary<string, string>();

	private void setup_animator()
	{
		AnimatorDict.Clear();

		AnimatorDict.Add("ch001", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch002", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch003", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch004", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch005", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch006", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch007", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch008", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch009", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch010", "Animator/SampleAnimatorSword");
		AnimatorDict.Add("ch011", "Animator/SampleAnimatorArcher");
		AnimatorDict.Add("ch012", "Animator/SampleAnimatorArcher");
		AnimatorDict.Add("ch013", "Animator/SampleAnimatorArcher");
		AnimatorDict.Add("ch014", "Animator/SampleAnimatorArcher");
		AnimatorDict.Add("ch015", "Animator/SampleAnimatorGun");
		AnimatorDict.Add("ch016", "Animator/SampleAnimatorGun");
		AnimatorDict.Add("ch017", "Animator/SampleAnimatorBomb");
		AnimatorDict.Add("ch018", "Animator/SampleAnimatorBomb");
		AnimatorDict.Add("ch019", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch020", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch021", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch022", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch023", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch024", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch025", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch026", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch027", "Animator/SampleAnimatorWizard");
		AnimatorDict.Add("ch028", "Animator/SampleAnimatorPaladin");
		AnimatorDict.Add("ch029", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch030", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch031", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch032", "Animator/SampleAnimatorFighter2");
		AnimatorDict.Add("ch033", "Animator/SampleAnimatorFighter2");
		AnimatorDict.Add("ch034", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch035", "Animator/SampleAnimatorFighter2");
		AnimatorDict.Add("ch036", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch037", "Animator/SampleAnimatorFighter");
		AnimatorDict.Add("ch038", "Animator/SampleAnimatorFighter2");
		AnimatorDict.Add("ch039", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch040", "Animator/SampleAnimatorLancer2");
		AnimatorDict.Add("ch041", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch042", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch043", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch044", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch045", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch046", "Animator/SampleAnimator_1");
		AnimatorDict.Add("ch047", "Animator/SampleAnimatorLancer2");
		AnimatorDict.Add("ch048", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch049", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch050", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch051", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch052", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch053", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch054", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch055", "Animator/SampleAnimatorMonk");
		AnimatorDict.Add("ch056", "Animator/SampleAnimatorMonk2");
		AnimatorDict.Add("ch057", "Animator/SampleAnimatorThief4");
		AnimatorDict.Add("ch058", "Animator/SampleAnimatorThief");
		AnimatorDict.Add("ch059", "Animator/SampleAnimatorThief3");
		AnimatorDict.Add("ch060", "Animator/SampleAnimatorThief4");
		AnimatorDict.Add("ch061", "Animator/SampleAnimatorThief4");
		AnimatorDict.Add("ch062", "Animator/SampleAnimatorThief4");
		AnimatorDict.Add("ch063", "Animator/SampleAnimatorThief4");
		AnimatorDict.Add("ch064", "Animator/SampleAnimatorThief2");
		AnimatorDict.Add("ch065", "Animator/SampleAnimatorThief2");
		AnimatorDict.Add("ch101", "Animator/SampleAnimatorGoblin");
		AnimatorDict.Add("ch102", "Animator/SampleAnimatorGoblin");
		AnimatorDict.Add("ch103", "Animator/SampleAnimatorGoblin");
		AnimatorDict.Add("ch104", "Animator/SampleAnimatorGolem");
		AnimatorDict.Add("ch105", "Animator/SampleAnimatorGolem");
		AnimatorDict.Add("ch106", "Animator/SampleAnimatorGolem");
		AnimatorDict.Add("ch107", "Animator/SampleAnimatorGolem");
		AnimatorDict.Add("ch108", "Animator/SampleAnimatorKerberos");
		AnimatorDict.Add("ch109", "Animator/SampleAnimatorMinotauros");
		AnimatorDict.Add("ch110", "Animator/SampleAnimatorTroll");
		AnimatorDict.Add("ch111", "Animator/SampleAnimatorDragon");
		AnimatorDict.Add("ch112", "Animator/SampleAnimatorDragon");
		AnimatorDict.Add("ch113", "Animator/SampleAnimatorDragon");
		AnimatorDict.Add("ch114", "Animator/SampleAnimatorDragon");
		AnimatorDict.Add("ch115", "Animator/SampleAnimatorDragon");
		AnimatorDict.Add("ch120", "Animator/SampleAnimatorEfreet");
		AnimatorDict.Add("ch121", "Animator/SampleAnimatorGnome");
		AnimatorDict.Add("ch122", "Animator/SampleAnimatorJinn");
		AnimatorDict.Add("ch123", "Animator/SampleAnimatorUndine");

	}

}
