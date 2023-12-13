import { useQueryGetOkrsWithQuarter } from "@/service/checkin";
import { RequestBody } from "@/service/checkin/type";
import { defaultOption } from "@/utils/config";
import { useState } from "react";
import { useForm } from "react-hook-form";

const defaultValues : RequestBody['GET'] = {
    QuarterId: 0,
}
export const useCheckinPerson = () => {
 
    const methodForm = useForm<RequestBody['GET']>({
        defaultValues,
    })

    const [queryPage, setQueryPage] = useState<RequestBody['GET']>(defaultValues)
    const onChangeValue = (value : any) => {
        setQueryPage({
            QuarterId: value
        });
        console.log(value,"vl")
    }
    const onSubmit = methodForm.handleSubmit(async(input) => {
        console.log(input, "mtF")
        setQueryPage(input)
    })
    
    const { data, isLoading } = useQueryGetOkrsWithQuarter(
             queryPage,
            defaultOption
    )
   
  const dt = data?.Data?.Okrs??[];
const dataOkr1 = dt[0];
const NextTimeCheckIn = data?.Data.NextTimeCheckIn
const countSchedule = data?.Data.CountCheckInSchedule?? 0 
const listCheckInOkr = data?.Data.ListCheckInOKr ?? []
    
    return [ {isLoading, dataOkr1,NextTimeCheckIn,countSchedule,listCheckInOkr, methodForm}, { onSubmit,onChangeValue } ] as const
}