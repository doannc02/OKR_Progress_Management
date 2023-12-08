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
   
    const totalsKr = data?.Data?.Okrs[0]?.Objectives.TotalsKr??0;
    const krsUnFinish = data?.Data?.Okrs?.Objectives?.KrsUnFinish ?? 0;
    
    return [ {isLoading, data, methodForm, totalsKr, krsUnFinish}, { onSubmit,onChangeValue } ] as const
}