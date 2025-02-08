namespace Panels.MiddleRoom
{
    public class PanelRoot : AbstractPanel
    {
        public PanelRoot() : base(null)
        {
            Children.Add(new PanelRoom(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            
            Resume();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelRoom>();
        }
    }
}