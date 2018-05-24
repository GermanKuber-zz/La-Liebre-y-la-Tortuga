namespace TurtleGame.Domain.Tests
{
    public class TrackShoud
    {
        private readonly TrackBase _sut;
        private readonly SideOfTrackSelector _lineWayUpSide;
        private readonly SideOfTrackSelector _lineToLeftWaySide;

        public TrackShoud()
        {
            _lineWayUpSide = new SideOfTrackSelector(true, true, false, false);
            _lineToLeftWaySide = new SideOfTrackSelector(true, false, true, false);
            _sut = new CommonTrack(_lineWayUpSide, _lineToLeftWaySide);
        }

        //[Fact]
        //public void Set_Next_Way_Allow_Two_Lines()
        //{
        //    var lineWay = new SideOfTrack(true, true, false, false);
        //    var lineToLeftWay = new SideOfTrack(true, false, true, false);
        //    var nextCommon = new CommonTrack(lineWay, lineToLeftWay);
        //    _sut.SetNext(nextCommon, TrackBase.SideOfTrackEnum.UpSide);
        //    _sut.Next.Should().Be(nextCommon);
        //}
        //[Fact]
        //public void Selected_Up_Side()
        //{
        //    _sut.SelectUpSide();
        //    _sut.Current.Should().Be(_lineWayUpSide);
        //}
        //[Fact]
        //public void Selected_Down_Side()
        //{
        //    _sut.SelectDownSide();
        //    _sut.Current.Should().Be(_lineToLeftWaySide);
        //}
        //[Fact]
        //public void Selected_Up_Side_When_Set_Next_Side()
        //{
        //    var lineWay = new SideOfTrack(true, true, false, false);
        //    var lineToLeftWay = new SideOfTrack(true, false, true, false);
        //    var nextCommon = new CommonTrack(lineWay, lineToLeftWay);
        //    _sut.SetNext(nextCommon, TrackBase.SideOfTrackEnum.UpSide);
        //    _sut.Current.Should().Be(_lineWayUpSide);
        //}
        //[Fact]
        //public void Selected_Down_Side_When_Set_Next_Side()
        //{
        //    var lineWay = new SideOfTrack(true, true, false, false);
        //    var lineToLeftWay = new SideOfTrack(true, false, true, false);
        //    var nextCommon = new CommonTrack(lineWay, lineToLeftWay);
        //    _sut.SetNext(nextCommon, TrackBase.SideOfTrackEnum.DownSide);
        //    _sut.Current.Should().Be(_lineToLeftWaySide);
        //}

    }
}