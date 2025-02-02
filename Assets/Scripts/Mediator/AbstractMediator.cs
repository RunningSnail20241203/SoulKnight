using System.Collections.Generic;
using System.Linq;
using Controller;
using UnityEngine;

namespace Mediator
{
    public abstract class AbstractMediator
    {
        private readonly List<AbstractController> _controllers = new();


        public void RegisterController(AbstractController controller)
        {
            if (_controllers.FirstOrDefault(x => x.GetType() == controller.GetType()) == null)
                _controllers.Add(controller);
            else
                Debug.LogError($"AbstractMediator|RegisterController|Already registered:{controller.GetType()}");
        }

        public T GetController<T>() where T : AbstractController
        {
            return _controllers.Where(ac => ac.GetType() == typeof(T)).Cast<T>().FirstOrDefault();
        }
    }
}