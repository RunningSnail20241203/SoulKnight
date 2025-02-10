namespace Panels.MiddleRoom
{
    public class PanelRoot : AbstractPanel
    {
        public PanelRoot() : base(null)
        {
            Children.Add(new PanelRoom(this));
        }

        protected override void OnResume()
        {
            base.OnResume();
            EnterPanel<PanelRoom>();
        }
    }
}