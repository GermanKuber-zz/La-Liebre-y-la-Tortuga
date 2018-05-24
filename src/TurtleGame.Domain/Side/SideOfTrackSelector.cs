namespace TurtleGame.Domain
{
    public class SideOfTrackSelector
    {
        public bool VerticalDownEnable { get; }
        public bool VerticalUpEnable { get; }
        public bool VerticalLeftEnable { get; }
        public bool VerticalRigthEnable { get; }

        protected SideOfTrackSelector()
        {

        }
        public SideOfTrackSelector(bool verticalDownEnable,
            bool verticalUpEnable,
            bool verticalLeftEnable,
            bool verticalRigthEnable)
        {
            VerticalDownEnable = verticalDownEnable;
            VerticalUpEnable = verticalUpEnable;
            VerticalLeftEnable = verticalLeftEnable;
            VerticalRigthEnable = verticalRigthEnable;
        }
    }
}