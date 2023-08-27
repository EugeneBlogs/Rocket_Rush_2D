using UnityEngine;

public class FinishTrigger : BaseTrigger 
{
	[SerializeField] private FinishSlider m_FinishSlider = null;
	private int countLegRocked = 2;
	private int counterLeg = 0;


	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag != "Leg")
			return;

		if (++counterLeg == countLegRocked)
			m_FinishSlider.StartTimer();
	}


	private void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag != "Leg")
			return;

		if (counterLeg-- == countLegRocked)
			m_FinishSlider.StopTimer();
	}
}
