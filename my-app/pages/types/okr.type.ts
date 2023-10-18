export interface IOkr{
    id: number,
    okrName: String,
    oKrPercent: number,
    okrType: number,
    okrStatus: number,
    userId: number,
    fullName: string,
    email: string,
    avatar: string,
    role: string,
    userRoleName: string,
    departmentName: string,
    allowCheckIn: boolean,
    isManager: boolean,
    departmentStructure: string,
    objectives: [objectives],
}


export interface objectives{
    id: number,
    okrId: number,
    userId: number,
    okrName: string,
    objectiveName: string,
    objectivePercent: number,
    objectiveType: number,
    status: number,
    keyResults: [keyResults]
}

export interface keyResults{
    id: number,
    objectiveId: number,
    userId: number,
    keyResultName:string,
    keyResultPercent: number,
    quarterId: number,
    quarterName: string,
    quarterData: string,
    keyResultActions: [keyResultActions]
}

export interface keyResultActions {
    id: number,
    keyResultId: number,
    userId: number,
    keyResultName: string,
    actionName:string,
    actionPercent: number,
    quarterId: number,
    quarterName: string,
    quarterData: string
}

