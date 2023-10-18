namespace OKEA.Library.Models.ViewModels
{
    public class DashBoardCountViewModel
    {
        public long UserCount { get; set; }
        public long OkrCount { get; set; }
        public long ObjectiveCount { get; set; }
        public long KeyResultCount { get; set; }
    }
    public class CheckInManagerWithMember
    {
        public int CheckinCount { get; set; }
        public int GivenStar { get; set; }
        public int Members { get; set; }
    }
    public class DashBoardManagerCountViewModel
    {
        public long UserCount { get; set; }
        public long OkrCount { get; set; }
        public long ObjectiveCount { get; set; }
        public long KeyResultCount { get; set; }
        // số lần check-in
        public int CheckInCountWeek { get; set; }
        public int CheckInCountMonth { get; set; }
        public int CheckInCountQuarter { get; set; }
        public int CheckInCountYear { get; set; }
        // thống kê quản lý checkin với member
        public CheckInManagerWithMember CheckInManagerWithMemberCountWeek { get; set; }
        public CheckInManagerWithMember CheckInManagerWithMemberCountMonth { get; set; }
        public CheckInManagerWithMember CheckInManagerWithMemberCountQuarter { get; set; }
        public CheckInManagerWithMember CheckInManagerWithMemberCountYear { get; set; }

        // OKR, Objective, Key result hoàn thành
        public int OkrCountCompleteWeek { get; set; }
        public int ObjectiveCountCompleteWeek { get; set; }
        public int KeyResultCountCompleteWeek { get; set; }

        public int OkrCountCompleteMonth { get; set; }
        public int ObjectiveCountCompleteMonth { get; set; }
        public int KeyResultCountCompleteMonth { get; set; }

        public int OkrCountCompleteQuarter { get; set; }
        public int ObjectiveCountCompleteQuarter { get; set; }
        public int KeyResultCountCompleteQuarter { get; set; }

        public int OkrCountCompleteYear { get; set; }
        public int ObjectiveCountCompleteYear { get; set; }
        public int KeyResultCountCompleteYear { get; set; }
        // sao tặng
        public int GivenStarWeek { get; set; }
        public int GivenStarMonth { get; set; }
        public int GivenStarQuarter { get; set; }
        public int GivenStarYear { get; set; }

    }
}
