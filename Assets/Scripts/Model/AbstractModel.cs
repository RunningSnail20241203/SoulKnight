using Property.ScriptableObject;

namespace Model
{
    public abstract class AbstractModel
    {
        public virtual bool IsInited => false;
        protected AbstractModel()
        {

        }
    }
}