using System.Collections.Generic;

namespace bases
{
    public enum State_E
    {
        OPEN,
        CLOSE,
        REPAIR,
        DESTRUCTED,
    }
    public interface IBuilding
    {
        string Adress { get; set; }
        Dictionary<string, object> getParams();
        void Destruct();
    }

    public abstract class PublicBuilding : IBuilding
    {
        public PublicBuilding(int age, string adress)
        {
            Adress = adress;
            Age = age;
        }

        private State_E state = State_E.CLOSE;

        public int Age { get; set; }
        public string Adress { get; set; }
        public State_E State { get { return state; } }

        public void Destruct()
        {
            state = State_E.DESTRUCTED;
        }

        public virtual void Repair()
        {
            state = State_E.REPAIR;
        }

        public void Open_or_close(bool is_open)
        {
            if (is_open && state == State_E.CLOSE)
                state = State_E.OPEN;
            else if (!is_open && state == State_E.OPEN)
                state = State_E.CLOSE;
        }

        public virtual Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = new Dictionary<string, object>();
            parames.Add("adress", this.Adress);
            parames.Add("age", this.Age);
            parames.Add("state", this.State);
            return parames;
        }

    }
}
