
import { Grid } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { useDemoData } from "@mui/x-data-grid-generator";
import * as React from "react";
import { IUser } from "../types/user.type";
import dynamic from "next/dynamic";
import User from "../user";
import Cookies from "js-cookie";
import { useRouter } from "next/router";
import ProjectTabs from "./components/projectsTap";
import ListRanking from "./components/listRanking";
import PersistentDrawerLeft from "@/components/main/main";

const { BarBasic } = {
  BarBasic: dynamic(
    () =>
      import("./components/barchart").then((component) => component.BarBasic),
    { ssr: false, loading: () => <div>Loading ...</div> }
  ),
};

// list data rank user
export function ListData({ props }: { props: IUser }) {
  console.log(props, "hehe");
  const { data } = useDemoData({
    dataSet: 'Commodity',
    rowLength: 100,
    maxColumns: 6,
  });
  return (
    <div style={{ height: "50vh", width: "100%" }}>
      <DataGrid
        style={{ height: "100%", width: "100%" }}
        {...data}
        initialState={{
          ...data.initialState,
          pagination: { paginationModel: { pageSize: 5 } },
        }}
        pageSizeOptions={[5, 10, 25]}
      />
    </div>
  );
}

// chart rank
export default function Home() {
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

  const [domLoaded, setDomLoaded] = React.useState(false);
  const [data, setData] = React.useState<IUser>();
  const router = useRouter();
  const isAuthenticated = typeof window !== "undefined" && !!Cookies.get("Token");

  React.useEffect(() => {
    setDomLoaded(true);
    if (!isAuthenticated) {
      router.push("/account/login");
    }
  }, [isAuthenticated, router]);

  
  const boxShadowStyle = {
    borderRadius: "10px",
    margin: "3%",
    height: "60vh",
    padding: "20px",
    boxShadow: "10px 10px 10px 10px rgba(0.2, 0.2, 0.2, 0.2)", 
    background: "white", 
  };

  const dtBarChart = {
    height: 450, data: dtChart
  }
  
const MainHome : React.ElementType  =() => {
  return (
     <div>

      <div style={{position: "relative", height: "80%" }}>
        <Grid container spacing={2} zIndex={10000}>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
            <div style={{zIndex: 999,overflowX: "hidden", overflowY: "hidden", height: "100%", width:"100%" }}>
              <BarBasic props={ dtBarChart } />
            </div>
            </div>
          </Grid>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
            <div style={{ overflowY: "auto", height: "100%" }}>
              <User />
              </div>
            </div>
          </Grid>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
              <div style={{ overflowY: "auto", height: "98%" }}>
                <ListRanking/>
              </div>
            </div>
          </Grid>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
              <div style={{ overflowY: "auto", height: "98%" }}>
                <ProjectTabs />
              </div>
            </div>
          </Grid>
        </Grid>
      </div>
    </div>
  )
  }
 if(isAuthenticated && domLoaded){
  return (
   
    <PersistentDrawerLeft title="HOME" children={<MainHome/>}/>
  );
 }
}

