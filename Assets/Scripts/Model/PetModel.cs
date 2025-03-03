
using Factory;
using Property.ScriptableObject;
using Property.ShareProperty;

namespace Model
{
    public class PetModel : AbstractModel
    {
        private PetDataSo _attr;

        public override bool IsInited => _attr != null;
        
        public PetModel()
        {
            var task = ResourceFactory.Instance.GetDef<PetDataSo>(PetDataSo.FileName);
            task.GetAwaiter().OnCompleted(() =>
            {
                _attr = task.Result;
            });
        }

        public PetShareAttr GetPetAttr(PetType petType)
        {
            return _attr.GetAttr(petType);
        }
    }
}