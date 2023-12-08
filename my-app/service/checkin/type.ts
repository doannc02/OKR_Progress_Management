import { BaseResponse } from "@/utils/baseResponse"

export type Quarter = {
    Id: number,
    Name: string,
    StartDate: string,
    EndDate: string,
    Status: number,
    IsActived:  boolean
}
export type CheckInMemberOKR = {
    Quarter?: Quarter,
    NextTimeCheckIn?: string,
    LastTimeCheckIn?: string,
    CountCheckInSchedule?: number,
    CheckInDate?: number
    Okrs?: any,
    ListCheckInOKr : ListCheckInOKr[]
}
export type Response = {
    GET: BaseResponse<CheckInMemberOKR>
}

export type RequestBody = {
    GET :{
        QuarterId?: number | null,
        CheckInHistoryId?: number | null,
        CheckInOkrId?: number | null,
        OkrId?: number | null,
        UserId?: number,
        isManager?: number | null,
      }
  }

  export type ListCheckInOKr =  {
                Id: number,
                CheckInHistoryId:  number,
                MemberId: number,
                MemberFullname: string,
                MemberEmail: string,
                MemberGender: number,
                MemberRole: number,
                ManagerId: number,
                ManagerFullName: string,
                ManagerEmail: string,
                Okrid: number,
                Okrname: string,
                Okrpercent: number,
                Okrstatus: number,
                CfrcommentOkr: null,
                CommentOkr: null,
                ConfidenceLevel: 0,
                CfrsuggestQuestionId: 0,
                Question: null,
                CfrsuggestAnswerId: 0,
                Answer: null,
                MarkPoint: 0,
                StartDate: Date,
                NextTime: Date,
                Status: number,
                IsActived: boolean
            }