import PersistentDrawerLeft from "@/components/main/main";
import { Grid, Stack, TextField } from "@mui/material";
import dynamic from "next/dynamic";

const { BarBasic } = {
    BarBasic: dynamic(
      () =>
        import("./components/chartLine").then((component) => component.BarBasic),
      { ssr: false, loading: () => <div>Loading ...</div> }
    ),
  };

const dtChart = [
  {
    label: "nameA",
    value: 10,
  },
  {
    label: "nameA",
    value: 50,
  },
  {
    label: "nameA",
    value: 30,
  },
  {
    label: "nameA",
    value: 70,
  },
  {
    label: "nameA",
    value: 10,
  },
  {
    label: "nameA",
    value: 50,
  },
  {
    label: "nameA",
    value: 90,
  },
  {
    label: "nameA",
    value: 70,
  },
  {
    label: "nameA",
    value: 10,
  },
  {
    label: "namec",
    value: 50,
  },
  {
    label: "namea",
    value: 30,
  },
  {
    label: "nameb",
    value: 90,
  },
];
const dtBarChart = {
  height: 450,
  data: dtChart,
};

const Main: React.ElementType = () => {
  return (
    <div 
    className="flex flex-col">
       <Stack direction="row" spacing={2}>
        <div className="w-1/2">
            Text
        </div>
        <div className="w-1/2 overflow-hidden">
        <BarBasic props={dtBarChart} />
        </div>
        </Stack> 
        
    </div>
  );
};

const useCheckinPerson = () => {
  return <PersistentDrawerLeft title="Checkin cá nhân" children={<Main />} />;
};

export default useCheckinPerson;
