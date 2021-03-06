﻿using UnityEngine;
using System;
using System.Collections.Generic;

namespace BaseLib {

	/// <summary>
	/// Pooled object.
	/// </summary>
	public abstract class PooledObject<T> : CachedObject where T : MonoBehaviour {
		private IPool parentPool;

		private T prefab;

		/// <summary>
		/// Gets or sets the prefab.
		/// </summary>
		/// <value>The prefab.</value>
		public T Prefab {
			get { 
				return prefab; 
			}
			set {
				prefab = value;
				MatchPrefab(prefab);
			}
		}

		private bool is_active = false;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="BaseLib.PooledObject`1"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool Active {
			get { 
				return is_active; 
			}
			set {
				//Debug.Log(value);
				is_active = value;
				if(value){
					Activate();
				} else {
					Deactivate();
					parentPool.Return(this);
				}
				GameObject.SetActive (value);
			}
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start() {
			GameObject.SetActive (false);
		}

		/// <summary>
		/// Initialize the specified pool.
		/// </summary>
		/// <param name="pool">Pool.</param>
		public void Initialize(IPool pool) {
			//Debug.Log ("initlaized");
			parentPool = pool;
		}

		/// <summary>
		/// Matchs the prefab.
		/// </summary>
		/// <param name="gameObj">Game object.</param>
		public abstract void MatchPrefab (T gameObj);

		/// <summary>
		/// Activate this instance.
		/// </summary>
		protected virtual void Activate() {
		}

		/// <summary>
		/// Deactivate this instance.
		/// </summary>
		protected virtual void Deactivate() {
		}
	}
}