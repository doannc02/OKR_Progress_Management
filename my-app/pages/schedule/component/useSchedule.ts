import { useQueryGetManagers } from "@/service/checkin/getListManager/indext";
import { useForm } from "react-hook-form";

const defaultValues = {
  SelectManager: "",
  StartDate: "",
  EndDate: "",
};
export const useSchedules = () => {
  const methodForm = useForm({
    defaultValues,
  });
  const { data : lstManagers} = useQueryGetManagers();
  const managers = lstManagers?.Data
  const onSubmit = methodForm.handleSubmit(async (input) => {
    console.log(input,"input")
    return input;
  });
  return [{ methodForm, managers }, { onSubmit }] as const;
};
