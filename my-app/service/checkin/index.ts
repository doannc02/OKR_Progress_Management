import { authApi } from "@/utils/baseHttp";
import { RequestBody, Response } from "./type";
import { useQuery } from "@tanstack/react-query";


export const GetOkrsWithQuarter = async ( 
    params: RequestBody['GET']
) : Promise<Response['GET']> => {
 const { data } = await authApi(
    {
        method: 'get',
        url: 'checkIn/get-data-okr-with-quarter',
        params: params
    }
 )
 return data;
}

export const useQueryGetOkrsWithQuarter = (
    params: RequestBody['GET'],
    options?: any
  ) => {
    return useQuery<Response['GET']>(
      ['api/get-data-okr-with-quarter', params],
      () => GetOkrsWithQuarter(params),
      {  ...options }
    )
  }