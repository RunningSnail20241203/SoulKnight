using System;
using System.Collections.Generic;
using Singleton;

namespace Model
{
    public class ModelContainer : Singleton<ModelContainer>
    {
        private readonly Dictionary<Type, AbstractModel> _models = new();

        public ModelContainer()
        {
            _models.Add(typeof(SceneModel), new SceneModel());
        }
        
        public T GetModel<T>() where T : AbstractModel
        {
            if (_models.TryGetValue(typeof(T), out var model))
            {
                return model as T;
            }

            return default;
        }
    }
}