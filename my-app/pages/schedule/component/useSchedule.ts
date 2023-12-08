import { useForm } from "react-hook-form"

const defaultValues = {
    SelectManager: "",
    StartDate: "",
    EndDate: ""
}
export const useSchedules = () => {
    const methodForm = useForm({
        defaultValues
    })

    const onSubmit = methodForm.handleSubmit(async(input) => {
        return input
    })
    return [ {methodForm}, {onSubmit} ] as const 
}