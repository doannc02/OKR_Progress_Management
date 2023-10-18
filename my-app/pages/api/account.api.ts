import api from "@/utils/baseHttp"
import { DisplayControlRegister, ResAccount } from "../types/account.type"

export const ApiLogin = (LoginName: string, Password: string) => {
    return api.post<ResAccount>('User/login', {
        LoginName: LoginName,
        Password: Password
    })
}

export const GetDepartmentForRegister = () => {
    return api.get<DisplayControlRegister>('register');
}