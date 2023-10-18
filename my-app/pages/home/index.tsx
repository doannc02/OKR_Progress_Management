import Header from "@/components/header";
import { Grid } from "@mui/material";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";
import { useDemoData } from "@mui/x-data-grid-generator";
import * as React from "react";
import CollapsibleTable from "../okrs";
import { IUser } from "../types/user.type";
import dynamic from "next/dynamic";
import User from "../user";
import Cookies from "js-cookie";
import { useRouter } from "next/router";

const { BarBasic } = {
  BarBasic: dynamic(
    () =>
      import("./components/barchart").then((component) => component.BarBasic),
    { ssr: false, loading: () => <div>Loading ...</div> }
  ),
};

const columns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 90 },
  {
    field: "fullName",
    headerName: "Họ Tên",
    width: 250,
    editable: true,
  },
  {
    field:
      "https://www.kkday.com/vi/blog/wp-content/uploads/chup-anh-dep-bang-dien-thoai-25.jpg",
    headerName: "avatar",
    width: 150,
    type: "image",
    editable: true,
  },
  {
    field: "email",
    headerName: "Email",
    type: "string",
    width: 200,
    editable: true,
  },
  {
    field: "role",
    headerName: "Role",
    description: "This column has a value getter and is not sortable.",
    sortable: false,
    width: 160,
    valueGetter: (params: GridValueGetterParams) =>
      `${params.row.firstName || ""} ${params.row.lastName || ""}`,
  },
];
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
 if(isAuthenticated && domLoaded){
  return (
    <div style={{ overflowY: "hidden" }}>
      <div style={{ width: "100%", position: "fixed", zIndex: "999"}}>
        <Header />
      </div>
      <div style={{position: "relative", height: "80%", marginTop: "3%" }}>
        <Grid container spacing={2} zIndex={10000}>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
            <div style={{zIndex: 999,overflowX: "hidden", overflowY: "hidden", height: "100%" }}>
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
               {/* <ListData props={data} />  */}
              </div>
            </div>
          </Grid>
          <Grid item xs={6}>
            <div style={boxShadowStyle}>
              <div style={{ overflowY: "auto", height: "98%" }}>
                <CollapsibleTable />
              </div>
            </div>
          </Grid>
        </Grid>
      </div>
    </div>
  );
 }
}
