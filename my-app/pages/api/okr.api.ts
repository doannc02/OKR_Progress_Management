import api from "@/utils/baseHttp";
import { IOkr } from "../types/okr.type";

export const getOkrByIdOkr = (
  request : {okrId: number | string,
    userId: number | string,
    userEmail: string,
    isActived: boolean | null}
) => {
    return api.post<IOkr>("Okr",request);
};
