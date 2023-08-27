using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour, IExpItem
{
	[SerializeField] private float m_DistanceExp = 1f;
	[SerializeField] private float m_ForceExp = 100f;
	[SerializeField] private GameObject m_ParticleExp = null;
    [SerializeField] private float _destroyTime = 0.1f;
    [SerializeField] private float _detonateVelocity = 1f;
    [SerializeField] private float _destroyProbality = 0.2f;
    [SerializeField] private Sprite _crashSprite = null;
    [SerializeField] private AudioSource _explosionSound;
	private int m_Layer = 1 << 8;
	private bool _isDetonated = false;


	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.relativeVelocity.magnitude > _detonateVelocity)
			Boom();
	}


	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, m_DistanceExp);
	}


	private IEnumerator Detonate()
	{
        yield return new WaitForSeconds(_destroyTime);
        
		RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, m_DistanceExp, transform.up, m_DistanceExp, m_Layer);

		for(int i = 0; i < hits.Length; i++)
        {
			Rigidbody2D rb = hits[i].collider.GetComponent<Rigidbody2D>();
			
			float dis = Vector3.Distance(hits[i].collider.transform.position, transform.position);
            

            if (rb)
			{
                AddExplosionForce(rb, m_ForceExp, transform.position, m_DistanceExp);
                IExpItem barrel = rb.GetComponent<IExpItem>();
				Player player = rb.GetComponent<Player>();

				if (barrel != null)
					barrel.Boom();
				if (player)
				{
					player.AddDemageForse(dis*m_ForceExp);
				}

               
			}
        }

        bool destroed = Random.value < _destroyProbality;
        
        if (m_ParticleExp&&!destroed)
            Instantiate(m_ParticleExp, transform.position, Quaternion.identity,transform);
        else if (m_ParticleExp)
        {
            var exp = Instantiate(m_ParticleExp, transform.position, Quaternion.identity);
            exp.transform.localScale /= 1 / transform.localScale.x;
        }

        


        GetComponent<SpriteRenderer>().sprite = _crashSprite;
	}


	public void Boom()
	{
		if(_isDetonated)
			return;

		_isDetonated = true;
		StartCoroutine(Detonate());

        if (_explosionSound != null) _explosionSound.Play();
    }

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }
}

/// <summary>
/// Реализует методы взрываопасных предметов
/// </summary>
public interface IExpItem
{
	void Boom();
}
