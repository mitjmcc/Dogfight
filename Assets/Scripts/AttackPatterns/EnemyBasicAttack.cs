using UnityEngine;
using System.Collections;
using BaseLib;

/// <summary>
/// Enemy basic attack.
/// </summary>
public class EnemyBasicAttack : AttackPattern {

	/// <summary>
	/// The fire delay.
	/// </summary>
	public CountdownDelay fireDelay;

	/// <summary>
	/// The velocity.
	/// </summary>
	public float velocity;

	/// <summary>
	/// The ang v.
	/// </summary>
	public float angV;

	/// <summary>
	/// The current delay.
	/// </summary>
	private float currentDelay;

	/// <summary>
	/// The general range.
	/// </summary>
	[SerializeField]
	private float generalRange;

	/// <summary>
	/// The basic prefab.
	/// </summary>
	public ProjectilePrefab basicPrefab;

	/// <summary>
	/// Mains the loop.
	/// </summary>
	/// <param name="dt">Dt.</param>
	protected override void MainLoop (float dt) {
		if (fireDelay.Tick(dt)) {
			float angle = TargetField.AngleTowardPlayer(transform.position) + Random.Range(-generalRange, generalRange);
			Projectile proj = TargetField.SpawnProjectile(basicPrefab, Transform.position,
			                            angle, 
			                            PlayerFieldController.CoordinateSystem.AbsoluteWorld);
			proj.Velocity = velocity;
			proj.AngularVelocity = angV;
		}
	}
}
