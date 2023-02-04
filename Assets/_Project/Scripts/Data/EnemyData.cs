using UnityEngine;

namespace GGJ.Data {
    [CreateAssetMenu(menuName = "Data/Enemies")]
    public class EnemyData : ScriptableObject {
        public float speed;
        public float viewDistance;
        public int health;
        public float maxChaseDistance = 5;
        public int damage = 10;
    }   
}