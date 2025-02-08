using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using UnityEngine;

namespace Mediator
{
    public abstract class AbstractMediator
    {
        private readonly List<AbstractController> _controllers = new();
        private readonly List<AbstractSystem> _systems = new();


        public void RegisterController(AbstractController controller)
        {
            if (_controllers.FirstOrDefault(x => x.GetType() == controller.GetType()) == null)
                _controllers.Add(controller);
            else
                Debug.LogError($"AbstractMediator|RegisterController|Already registered:{controller.GetType()}");
        }

        public void RegisterSystem(AbstractSystem system)
        {
            if (_systems.FirstOrDefault(x => x.GetType() == system.GetType()) == null)
                _systems.Add(system);
            else
                Debug.LogError($"AbstractMediator|RegisterSystem|Already registered:{system.GetType()}");
        }

        public T GetController<T>() where T : AbstractController
        {
            return _controllers.Where(ac => ac.GetType() == typeof(T)).Cast<T>().FirstOrDefault();
        }
        
        public T GetSystem<T>() where T : AbstractSystem
        {
            return _systems.Where(ac => ac.GetType() == typeof(T)).Cast<T>().FirstOrDefault();
        }
    }
}