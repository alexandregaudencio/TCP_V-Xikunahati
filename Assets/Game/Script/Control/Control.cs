using UnityEngine;

namespace Game.Character
{
    public abstract class Control : MonoBehaviour
    {
        protected abstract float xAxis();
        protected abstract float yAxis();
        public abstract Vector3 direction();

        public abstract bool jump();
        public abstract bool head();
        public abstract bool dive();
        public abstract void playerSelect();
        public abstract bool ButtonStart();
        public abstract bool ButtonReturn();

        public abstract bool R();
        public abstract bool L();

        public bool IsInputAction()
        {
            return head() && dive() && jump();
        }
    }
}

