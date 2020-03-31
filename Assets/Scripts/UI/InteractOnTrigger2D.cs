using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractOnTrigger2D : MonoBehaviour
    {
        public LayerMask layers;
        public UnityEvent OnEnter, OnExit;
        public InventoryController.InventoryChecker[] inventoryChecks;
        private bool hasOverlap;
        private Collider2D m_Collider;
        private ArrayList overlappingColliders = new ArrayList();
        void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
            m_Collider = GetComponent<Collider2D>();
            m_Collider.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(!enabled)
                return;
            if (layers.Contains(other.gameObject))
            {
                hasOverlap = true;
                overlappingColliders.Add(other);
                ExecuteOnEnter(other);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(!enabled)
                return;
            if (layers.Contains(other.gameObject))
            {
                RemoveCollider(other);
                if (!hasOverlap) ExecuteOnExit(other);
            }
        }

        void RemoveCollider(Collider2D rem) {
            overlappingColliders.Remove(rem);
            if (overlappingColliders.Count == 0) hasOverlap = false;
        }

        public bool HasOverlap() {
            return hasOverlap;
        }

        protected virtual void ExecuteOnEnter(Collider2D other)
        {
            OnEnter.Invoke();
            for (int i = 0; i < inventoryChecks.Length; i++)
            {
                inventoryChecks[i].CheckInventory(other.GetComponentInChildren<InventoryController>());
            }
        }

        protected virtual void ExecuteOnExit(Collider2D other)
        {
            OnExit.Invoke();
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
        }
    }
}