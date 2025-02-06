using System;
using System.Collections.Generic;
using Singleton;

namespace Model
{
    public class ModelContainer : Singleton<ModelContainer>
    {
        private Dictionary<Type, AbstractModel> _models = new();

        public ModelContainer()
        {
            
        }
        
        public T GetModel<T>() where T : AbstractModel
        {
            if (_models.TryGetValue(typeof(T), out AbstractModel model))
            {
                return model as T;
            }

            return default;
        }
    }
}