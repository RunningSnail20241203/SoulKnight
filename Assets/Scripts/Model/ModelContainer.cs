using System;
using System.Collections.Generic;
using System.Linq;
using Singleton;

namespace Model
{
    public class ModelContainer : Singleton<ModelContainer>
    {
        private readonly Dictionary<Type, AbstractModel> _models = new();
        public bool IsInited => _models.Values.All(x => x.IsInited);

        public ModelContainer()
        {
            AddModel(new PlayerModel());
            AddModel(new SceneModel());
            AddModel(new PetModel());
        }
        
        public T GetModel<T>() where T : AbstractModel
        {
            if (_models.TryGetValue(typeof(T), out var model))
            {
                return model as T;
            }

            return default;
        }

        private void AddModel<T>(T model) where T : AbstractModel
        {
            _models.Add(typeof(T), model);
        }
    }
}