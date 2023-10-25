import * as React from "react";
import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import Stack from "@mui/material/Stack";
import TableRow from "@mui/material/TableRow";
import Typography from "@mui/material/Typography";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import { getMemberListOkr, searchOkrByEmail } from "../api/okr.api";
import { useQuery } from "@tanstack/react-query";
import PersistentDrawerLeft from "@/components/main/main";
import { useRouter } from "next/router";
import Cookies from "js-cookie";
import Pagination from "@mui/material/Pagination";
import InputBase from "@mui/material/InputBase";
import InputFiled from "../account/component/inputFiled";
import TextField from "@mui/material/TextField";
import InputLabel from "@mui/material/InputLabel";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import { Objectives, ResponseGetMemberList, memberOkr } from "../types/okr.type";
import { styled, alpha } from "@mui/material/styles";
import SearchIcon from "@mui/icons-material/Search";
import LinearProgressWithLabel from "../home/components/progressbar";
import { relative } from "path";
import SkeletonOkrs from "@/components/skeleton/skeletonOKRs";
import { useDebounce } from "@/hooks/useDebounce";
import Search from "./components/searchBar";

function createData(
  name: string,
  calories: number,
  fat: number,
  carbs: number,
  protein: number,
  price: number
) {
  return {
    name,
    calories,
    fat,
    carbs,
    protein,
    price,
    history: [
      {
        date: "2020-01-05",
        customerId: "11091700",
        amount: 3,
      },
      {
        date: "2020-01-02",
        customerId: "Anonymous",
        amount: 1,
      },
    ],
  };
}

function Row(props: { row: ReturnType<typeof createData> }) {
  const { row } = props;
  const [open, setOpen] = React.useState(false);

  return (
    <React.Fragment>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell component="th" scope="row">
          {row.name}
        </TableCell>
        <TableCell align="right">{row.calories}</TableCell>
        <TableCell align="right">{row.fat}</TableCell>
        <TableCell align="right">{row.carbs}</TableCell>
        <TableCell align="right">{row.protein}</TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                History
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>Customer</TableCell>
                    <TableCell align="right">Amount</TableCell>
                    <TableCell align="right">Total price ($)</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.history.map((historyRow) => (
                    <TableRow key={historyRow.date}>
                      <TableCell component="th" scope="row">
                        {historyRow.date}
                      </TableCell>
                      <TableCell>{historyRow.customerId}</TableCell>
                      <TableCell align="right">{historyRow.amount}</TableCell>
                      <TableCell align="right">
                        {Math.round(historyRow.amount * row.price * 100) / 100}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </React.Fragment>
  );
}

const MainOKRs: React.ElementType = () => {
  const [dtRender, setDtRender] = React.useState<ResponseGetMemberList>()
  const [page, setPage] = React.useState(1);
  const [totalRecord, setTotalCounts] = React.useState<number>(10);
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value)
    setQuery({
      Page: value,
    })
  };
  const [query, setQuery] = React.useState<params>({
    Page: page,
    Email: ''
  })
  // xy ly lay danh sach
  type params = { Page: number | string, Email? : string };

  const handleGetMemberListOkr = async (Page: params) => {
    const res = await getMemberListOkr(Page);
    console.log(res.data, res.data.TotalCounts);
    return res.data;
  };
  const getOKRs = useQuery({
    queryKey: ["listOKR", query],
    queryFn: () => handleGetMemberListOkr(query),
    onSuccess: (data: any) => {
      setDtRender(data)
      setTotalCounts(data.TotalCounts);
    },
    onError: (Ex: any) => console.log(Ex),
  });


  return (
    <>
      <div
        className="border-2"
        style={{
          overflowY: "hidden",
          width: "100%",
          borderRadius: "4px",
          height: "93.5%",
          position: "relative",
        }}
      >
        <div style={{ height: "100%" }} className="mx-2">
          <Stack
            direction={"row"}
            width={"29%"}
            justifyContent={"space-between"}
            padding={"15px"}
          >
            <label className="mt-2 font-bold">Tìm kiếm theo Email</label>
          <Search callback={(query: { Page: number,Email: string}) => setQuery(query)} />
          </Stack>
          <Stack className="h-full">
            <Stack
              className="overflow-y-scroll"
              height={"88%"}
              border={"1px solid"}
              borderRadius={"4px"}
            >
              <Stack
                paddingLeft={"60px"}
                paddingRight={"10px"}
                width={"100%"}
                direction={"row"}
                justifyContent={"space-between"}
              >
                <div className="font-bold">Họ và tên</div>
                <Stack
                  direction={"row"}
                  width={"35%"}
                  justifyContent={"space-around"}
                >
                  <div className="font-bold">Email</div>
                  <div className="font-bold">Bộ phận</div>
                </Stack>
                <Stack
                  direction={"row"}
                  width={"15%"}
                  justifyContent={"space-around"}
                >
                  <div className="font-bold">Chức vụ</div>
                </Stack>
              </Stack>
              {getOKRs.isLoading ? (
                <SkeletonOkrs />
              ) : (
                getOKRs.data?.Data.map((item: memberOkr) => (
                  <Accordion
                    sx={{
                      border: "1px solid",
                      borderRadius: "4px",
                      margin: "10px",
                    }}
                  >
                    <AccordionSummary
                      expandIcon={<ExpandMoreIcon />}
                      aria-controls="panel1a-content"
                      id="panel1a-header"
                    >
                      <Stack
                        width={"100%"}
                        direction={"row"}
                        justifyContent={"space-between"}
                      >
                        <div>{item.FullName}</div>
                        <Stack
                          direction={"row"}
                          width={"35%"}
                          justifyContent={"space-around"}
                        >
                          <div>{item.Email}</div>
                          <div>{item.DepartmentName}</div>
                        </Stack>
                        <Stack
                          direction={"row"}
                          width={"15%"}
                          justifyContent={"space-around"}
                        >
                          <div
                            className={
                              item.Role === "Developer"
                                ? "border-2 p-1 border-violet-800 w-1/2"
                                : " w-1/2 border-2 p-1 border-red-700"
                            }
                          >
                            {item.Role}
                          </div>
                          {item.IsManager ? <button>Check-in</button> : ""}
                        </Stack>
                      </Stack>
                    </AccordionSummary>
                    <AccordionDetails
                      sx={{ borderTop: "1px solid", marginBottom: "5px" }}
                    >
                      <div
                        className="border-2"
                        style={{ overflowY: "hidden", width: "100%" }}
                      >
                        <div className="border-b-2">
                          <Stack
                            direction={"row"}
                            justifyContent={"space-between"}
                            sx={{ margin: "1%", borderBottom: "1px solid" }}
                          >
                            <div className="w-1/2 flex justify-center">
                              <InputLabel
                                sx={{
                                  color: "black",
                                  fontWeight: "600",
                                  paddingRight: "35px",
                                }}
                              >
                                Name
                              </InputLabel>
                            </div>
                            <Stack
                              direction="row"
                              spacing={2}
                              justifyContent={"space-around"}
                              width={"50%"}
                            >
                              <div className="w-1/3 flex justify-between">
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý I
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý II
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý III
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý IV
                                </InputLabel>
                              </div>
                              <div className="w-2/3 flex justify-around">
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Tiến độ
                                </InputLabel>
                              </div>
                            </Stack>
                          </Stack>
                          {item.Objectives.map((objective) => (
                            <>
                              {" "}
                              <Stack
                                direction={"row"}
                                justifyContent={"space-between"}
                                sx={{
                                  margin: "1%",
                                  borderBottom: "1px solid",
                                }}
                              >
                                <div className="w-1/2 ml-0">
                                  <InputLabel
                                    sx={{
                                      marginLeft: "5px",
                                      color: "black",
                                      fontWeight: "600",
                                    }}
                                  >
                                    Objective {objective.ObjectiveName}
                                  </InputLabel>
                                </div>
                                <Stack
                                  direction="row"
                                  spacing={2}
                                  justifyContent={"space-around"}
                                  width={"50%"}
                                >
                                  <div className="w-1/3 flex justify-between">
                                    <InputLabel>v</InputLabel>
                                    <InputLabel>v</InputLabel>
                                    <InputLabel>v</InputLabel>
                                    <InputLabel>v</InputLabel>
                                  </div>
                                  <div className="w-2/3 flex justify-around">
                                    <div className="w-1/3">
                                      <LinearProgressWithLabel
                                        value={objective.ObjectivePercent}
                                      />
                                    </div>
                                  </div>
                                </Stack>
                              </Stack>
                              {objective.KeyResults.map((kr) => (
                                <>
                                  <Stack
                                    direction={"row"}
                                    justifyContent={"space-between"}
                                    sx={{
                                      margin: "1%",
                                      borderBottom: "1px solid",
                                    }}
                                  >
                                    <div className="w-1/2 ml-0">
                                      <InputLabel
                                        sx={{
                                          marginLeft: "20px",
                                          fontWeight: "600",
                                        }}
                                      >
                                        Keyresult {kr.KeyResultName}
                                      </InputLabel>
                                    </div>
                                    <Stack
                                      direction="row"
                                      spacing={2}
                                      justifyContent={"space-around"}
                                      width={"50%"}
                                    >
                                      <div className="w-1/3 flex justify-between">
                                        <InputLabel>v</InputLabel>
                                        <InputLabel>v</InputLabel>
                                        <InputLabel>v</InputLabel>
                                        <InputLabel>v</InputLabel>
                                      </div>
                                      <div className="w-2/3 flex justify-around">
                                        <div className="w-1/3">
                                          <LinearProgressWithLabel
                                            value={kr.KeyResultPercent}
                                          />
                                        </div>
                                      </div>
                                    </Stack>
                                  </Stack>
                                  {kr.KeyResultActions.map((kra) => (
                                    <Stack
                                      direction={"row"}
                                      justifyContent={"space-between"}
                                      sx={{
                                        margin: "1%",
                                        borderBottom: "1px solid",
                                      }}
                                    >
                                      <div className="w-1/2 ml-0">
                                        <InputLabel
                                          sx={{
                                            marginLeft: "30px",
                                            fontWeight: "400",
                                          }}
                                        >
                                          Keyresult {kra.ActionName}
                                        </InputLabel>
                                      </div>
                                      <Stack
                                        direction="row"
                                        spacing={2}
                                        justifyContent={"space-around"}
                                        width={"50%"}
                                      >
                                        <div className="w-1/3 flex justify-between">
                                          <InputLabel>v</InputLabel>
                                          <InputLabel>v</InputLabel>
                                          <InputLabel>v</InputLabel>
                                          <InputLabel>v</InputLabel>
                                        </div>
                                        <div className="w-2/3 flex justify-around">
                                          <div className="w-1/3">
                                            <LinearProgressWithLabel
                                              value={kra.ActionPercent}
                                            />
                                          </div>
                                        </div>
                                      </Stack>
                                    </Stack>
                                  ))}
                                </>
                              ))}
                            </>
                          ))}
                        </div>
                      </div>
                    </AccordionDetails>
                  </Accordion>
                ))
              )}
            </Stack>
          </Stack>
          <div className="absolute  bottom-1 right-0">
            {" "}
            <Stack justifyContent={"center"} alignItems={"center"} spacing={2}>
              <Pagination
                count={Math.ceil(totalRecord / 10)}
                variant="outlined"
                page={page}
                onChange={handleChange}
              />
            </Stack>
          </div>
        </div>
      </div>
    </>
  );
};
export default function CollapsibleTable() {
  const [rows, setRow] = React.useState<memberOkr[]>();

  const [domLoaded, setDomLoaded] = React.useState(false);
  const router = useRouter();
  const isAuthenticated =
    typeof window !== "undefined" && !!Cookies.get("Token");

  React.useEffect(() => {
    setDomLoaded(true);
    if (!isAuthenticated) {
      router.push("/account/login");
    }
  }, [isAuthenticated, router]);

  //main

  if (isAuthenticated && domLoaded) {
    return <PersistentDrawerLeft title="OKRS" children={<MainOKRs />} />;
  }
}
